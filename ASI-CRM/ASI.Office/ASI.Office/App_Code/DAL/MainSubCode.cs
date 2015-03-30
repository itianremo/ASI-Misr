using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Office.DAL.ApplicationBlocks;
using System.Data.SqlClient;

namespace Office.DAL
{
    [Serializable]
    public class MainSubCode
    {
        #region ------------------Constructors------------------

        public MainSubCode()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region -------------------Properties--------------------

        public int? SubID
        {
            get { return _SubID; }
            set { _SubID = value; }
        }

        public string SubCode
        {
            get { return _SubCode; }
            set { _SubCode = value; }
        }

        public int? GeneralID
        {
            get { return _GeneralID; }
            set { _GeneralID = value; }
        }

        public string GCode
        {
            get { return _GCode; }
            set { _GCode = value; }
        }


        #endregion

        #region -----------------Private Variables----------------

        private int? _SubID;
        private string _SubCode;
        private string _GCode;
        private int? _GeneralID;

        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();

        #endregion

        #region ----------------General Functions----------------
        /// <summary>
        /// Insert new record into table Main_SubCode
        /// Fill in all properties of the Main_SubCode Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int AddNewMainSubCode()
        {
            int result = -1;
            try
            {
                BaseClass.InsertCommand("SP_INSERT_INTO_Main_SubCode", this._SubCode, this._GeneralID);
                result = 1;
            }
            catch (Exception Ex)
            {
                string ErrMsg = Ex.Message;
            }
            return result;
        }
       
        /// <summary>
        /// Update existing record in table Main_SubCode
        /// Fill in all properties of the Main_SubCode Object before calling the function
        /// </summary>
        /// <returns>integer value to indicates number of affected rows. -1 in case of errors</returns>
        public int UpdateMainSubCode()
        {
            int result = -1;
            try
            {
                BaseClass.UpdateCommand("SP_UPDATE_Main_SubCode", this._SubID, this._SubCode, this._GeneralID);
                result = 1;
            }
            catch (Exception Ex)
            {
                string ErrMsg = Ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Return list of sub code names that are related to the given General Code name
        /// Fill in the GCode property before calling this function
        /// </summary>
        /// <returns>List of MainSubCode Objects</returns>
        public List<MainSubCode> GetSCodeList()
        {
            List<MainSubCode> CodeList = new List<MainSubCode>();
            SqlConnection conCode = new SqlConnection(StrCon);
            try
            {
                MainSubCode MSC;
                SqlDataReader rdrCode = SqlHelper.ExecuteReader(conCode, "SP_Get_SCode", this.GCode);
                while (rdrCode.Read())
                {
                    MSC = new MainSubCode();

                    MSC.SubID = int.Parse(rdrCode["SID"].ToString());
                    MSC.SubCode = rdrCode["SCode"].ToString();

                    CodeList.Add(MSC);
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conCode.Close();
            }
            return CodeList;
        }

        public bool GetDefaultCountryAndState(out int CountryID, out string State)
        {
            bool Result = false;
            CountryID = -1;
            State = "";
            SqlConnection conCode = new SqlConnection(StrCon);
            try
            {
                SqlDataReader rdrCode = SqlHelper.ExecuteReader(conCode, "SP_Get_SCode", "Country");
                while (rdrCode.Read())
                {
                    if (rdrCode["SCode"].ToString().Trim().ToLower() == "united states")
                    {
                        CountryID = int.Parse(rdrCode["SID"].ToString());
                        break;
                    }
                }
                rdrCode.Close();

                SqlDataReader rdrCode2 = SqlHelper.ExecuteReader(conCode, "SP_Get_SCode", "State");
                rdrCode2.Read();
                State = rdrCode2["SCode"].ToString();
                rdrCode2.Close();

                Result = true;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conCode.Close();
            }
            return Result;
        }

        /// <summary>
        /// Get specific sub code record accoriding to the given SID
        /// Provide SID before calling this function
        /// </summary>
        /// <returns>object of type MainSubCode</returns>
        public MainSubCode GetSpecificSubCode()
        {
            SqlConnection conSub = new SqlConnection(StrCon);
            MainSubCode objMainSubCode = new MainSubCode();
            try
            {
                SqlDataReader rdrSub = SqlHelper.ExecuteReader(conSub, "SP_Get_Specific_SCode", this.SubCode);
                while (rdrSub.Read())
                {
                    objMainSubCode.SubID = int.Parse(rdrSub["SID"].ToString());
                    objMainSubCode.SubCode = rdrSub["SCode"].ToString();
                    objMainSubCode.GCode = rdrSub["GID"].ToString();
                }
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                conSub.Close();
            }
            return objMainSubCode;
        }

        /// <summary>
        /// Check if the given SCode related to the given GCode exists before or not.
        /// You should set the SCode and GID properties before calling this function
        /// </summary>
        /// <returns>Nullable boolean, true in case of exist true if not and null in case of error</returns>
        public bool? CheckSCodeExistance()
        {
            bool? Exist = null;
            SqlConnection ECon = new SqlConnection(StrCon);
            try
            {
                SqlDataReader drExist = SqlHelper.ExecuteReader(ECon, "SP_Check_SCode_Existance", this._SubCode, this._GeneralID);
                if (drExist.HasRows)
                    Exist = true;
                else
                    Exist = false;
            }
            catch (Exception Exp)
            {
                string ErrMsg = Exp.Message;
            }
            finally
            {
                ECon.Close();
            }
            return Exist;
        }
        #endregion
    }
}