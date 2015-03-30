using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Office.DAL.ApplicationBlocks;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Security.Principal;

namespace Office.DAL
{
	[Serializable]
	public class SecurityUserLogin 
	{
		#region ------------------Constructors------------------

		public SecurityUserLogin()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		//public SecurityUserLogin(string _UserName, string _Password, bool _Administrator, bool _Active, int? _AccountabilityID, string _JobTitle, string _EMail)
		//{
		//   UserName = _UserName;
		//   Password = _Password;
		//   Administrator = _Administrator;
		//   Active = _Active;
		//   AccountabilityID = _AccountabilityID;
		//   JobTitle = _JobTitle;
		//   EMail = _EMail;
		//}

		#endregion

		#region -------------------Properties--------------------

		public int? UserID
		{
			get { return _UserID; }
			set { _UserID = value; }
		}
		public string UserName
		{
			get { return _UserName; }
			set { _UserName = value; }
		}
		public string Password
		{
			get { return _Password; }
			set { _Password = value; }
		}
		public bool? Administrator
		{
			get { return _Administrator; }
			set { _Administrator = value; }
		}
		public bool? Active
		{
			get { return _Active; }
			set { _Active = value; }
		}
		public int? AccountabilityID
		{
			get { return _AccountabilityID; }
			set { _AccountabilityID = value; }
		}
		public string JobTitle
		{
			get { return _JobTitle; }
			set { _JobTitle = value; }
		}
		public string EMail
		{
			get { return _EMail; }
			set { _EMail = value; }
		}

		#endregion

		#region -----------------Private Variables----------------

		private int? _UserID;
		private string _UserName;
		private string _Password;
		private bool? _Administrator;
		private bool? _Active;
		private int? _AccountabilityID;
		private string _JobTitle;
		private string _EMail;



		string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

		#endregion

		#region ---------------General Functions-----------------
		/// <summary>
		/// Get all roles that are related to this use
		/// </summary>
		/// <returns>ArrayList of all roles names that are assigned to this user</returns>
		public ArrayList GetUserRoles()
		{
			SqlConnection RCon = new SqlConnection(StrCon);
			ArrayList RolesList = new ArrayList();
			try
			{
				SqlDataReader rdrRoles = SqlHelper.ExecuteReader(RCon, "SP_Get_User_Related_Roles", this.UserID);
				while (rdrRoles.Read())
				{
					RolesList.Add(rdrRoles["RoleName"].ToString());
				}
			}
			catch (Exception Exp)
			{
				string ErrMsg = Exp.Message;
			}
			finally
			{
				RCon.Close();
			}
			return RolesList;
		}

		/// <summary>
		/// Get all user date according to the user name and password that was supplied
		/// </summary>
		/// <returns>True in case user exist, otherwise false</returns>
		public bool GetUserData()
		{
			SqlConnection RCon = new SqlConnection(StrCon);
			bool ValidUser = false;
			try
			{
				SqlDataReader rdrData = SqlHelper.ExecuteReader(RCon, "SP_Get_User_Data", this._UserName, this._Password);
				if (rdrData.HasRows)
				{
					while (rdrData.Read())
					{
						this.UserID = int.Parse(rdrData["UID"].ToString());
						if (rdrData["Administrator"] != null || rdrData["Administrator"].ToString() != "")
							this.Administrator = Convert.ToBoolean(rdrData["Administrator"]);
						if (rdrData["Active"] != null || rdrData["Active"].ToString() != "")
							this.Active = Convert.ToBoolean(rdrData["Active"]);
						if (rdrData["AccountabilityID"] != DBNull.Value || rdrData["AccountabilityID"].ToString() != "")
							this.AccountabilityID = int.Parse(rdrData["AccountabilityID"].ToString());
						if (rdrData["JobTitle"] != null || rdrData["JobTitle"].ToString() != "")
							this.JobTitle = rdrData["JobTitle"].ToString();
						if (rdrData["Email"] != null || rdrData["Email"].ToString() != "")
							this.EMail = rdrData["Email"].ToString();
					}
					ValidUser = true;
				}
			}
			catch (Exception Exp)
			{
				string ErrMsg = Exp.Message;
			}
			finally
			{
				RCon.Close();
			}
			return ValidUser;
		}

		/// <summary>
		/// Update existing record in table Sec_UserLogin
		/// Fill in all properties of the Sec_UserLogin Object before calling the function
		/// </summary>
		/// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
		public int AddNewSecurityUserLogin()
		{
			int result = -1;
			try
			{
				BaseClass.InsertCommand("SP_INSERT_INTO_Sec_UserLogin", this._UserName, this._Password, this._Administrator, this._Active, this._AccountabilityID, this._JobTitle, this._EMail);
				result = 1;
			}
			catch (Exception Ex)
			{
				string ErrMsg = Ex.Message;
			}
			return result;
		}

		/// <summary>
		/// Update existing record in table Sec_UserLogin
		/// Fill in all properties of the Sec_UserLogin Object before calling the function
		/// </summary>
		/// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
		public int UpdateSecurityUserLogin()
		{
			int result = -1;
			try
			{
				BaseClass.UpdateCommand("SP_UPDATE_Sec_UserLogin", this._UserID, this._UserName, this._Password, this._Administrator, this._Active, this._AccountabilityID, this._JobTitle, this._EMail);
				result = 1;
			}
			catch (Exception Ex)
			{
				string ErrMsg = Ex.Message;
			}
			return result;
		}

		/// <summary>
		/// Return all users that are Account Manager Users
		/// </summary>
		/// <returns>List of SecuirtyUserLogin</returns>
		public List<SecurityUserLogin> GetAccountManagerUsers()
		{
			List<SecurityUserLogin> UsersList = new List<SecurityUserLogin>();
			SqlConnection conMngr = new SqlConnection(StrCon);
			try
			{
				SqlDataReader rdrMng = SqlHelper.ExecuteReader(conMngr, "SP_Get_Account_Managers");
				SecurityUserLogin SUL;
				while (rdrMng.Read())
				{
					SUL = new SecurityUserLogin();

					SUL.UserID = int.Parse(rdrMng["UID"].ToString());
					SUL.UserName = rdrMng["UserName"].ToString();

					UsersList.Add(SUL);
				}
			}
			catch (Exception Ecp)
			{
				string ErrMsg = Ecp.Message;
			}
			return UsersList;
		}

		/// <summary>
		/// Check if this user is Account Manager or not
		/// Fill in the UserID property first before calling the function
		/// </summary>
		/// <returns>True if the user is account manager, false otherwise</returns>
		public bool IsAccountManagerUser()
		{
			bool AccMngr = false;
			try
			{
				DataSet dsUser = new DataSet();
				dsUser = SqlHelper.ExecuteDataset(StrCon, "SP_Check_Account_Manager_User", this.UserID);
				if (dsUser.Tables[0].Rows.Count > 0)
					AccMngr = true;
				else
					AccMngr = false;
			}
			catch (Exception Exp)
			{
				string ErrMsg = Exp.Message;
				AccMngr = false;
			}
			return AccMngr;
		}
		/// <summary>
		/// //////////////
		/// </summary>
		/// <returns></returns>
		public bool GetUserPassword()
		{
			SqlConnection RCon = new SqlConnection(StrCon);
			bool ValidUser = false;
			try
			{
				SqlDataReader rdrData = SqlHelper.ExecuteReader(RCon, "SP_Get_User_Password", this._EMail);
				if (rdrData.HasRows)
				{
					while (rdrData.Read())
					{
						if (rdrData["Email"] != null || rdrData["Email"].ToString() != "")
						{
							this.EMail = rdrData["Email"].ToString();
							this.Password = rdrData["Password"].ToString();
							return true;
						}
						else
						{
							return false;
						}
					}
					ValidUser = true;
				}
			}
			catch (Exception Exp)
			{
				string ErrMsg = Exp.Message;
			}
			finally
			{
				RCon.Close();
			}
			return ValidUser;
		}


		#endregion

				
	}
}