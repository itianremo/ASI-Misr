using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Office.DAL.ApplicationBlocks;
using Office.DAL;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
/// <summary>
/// Summary description for History
/// </summary>
namespace Office.DAL
{
    [Serializable]
    public class Registration
    {
        public Registration()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        string StrCon = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ToString();
              
        #region Get Registration

        public  DataRow mGetRegisterationByEmail(string Email)
        {

            try
            {
               // string[] parms = new string[1];
                object[] parms = new object[1];
                parms[0] = Email.Trim();
                //string SQLCommand = "SELECT top 1 Registration.Email,CheckList,Agrement,UpdateBy,updateDate,Note from Registration inner join Key_CheckListMainInfo on Registration.Email= Key_CheckListMainInfo.Email  where Key_CheckListMainInfo.Email='" + Email + "'";
                DataSet dsReg = SqlHelper.ExecuteDataset(StrCon, "SP_GetRegisterationByEmail", parms);
                if (dsReg.Tables[0].Rows.Count > 0)
                {
                    return dsReg.Tables[0].Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string vsMessage = ex.Message;
                return null;
            }

        }
        #endregion
        #region Get Registration
        public  DataSet mGetRegisteration()
        {
            try
            {
                string SQLCommand = "SELECT  Email,CheckList,Agrement from Registration ";
                DataSet dsReg = SqlHelper.ExecuteDataset(StrCon, CommandType.Text, SQLCommand);
                return dsReg;
            }
            catch (Exception ex)
            {
                string vsMessage = ex.Message;
                return null;
            }

        }
        #endregion

        #region Add Registration
        public int mAddRegisteration(string Email, int Checklist, int Agrement)
        {
            int result = -1;
            try
            {
                string SQLCommand = "exec SP_SetCheckList '" + Email + "'," + Checklist + "," + Agrement;
                result = SqlHelper.ExecuteNonQuery(StrCon, CommandType.Text, SQLCommand);
                return result;
            }
            catch (Exception ex)
            {
                string vsMessage = ex.Message;
                return -1;
            }

        }
        #endregion
        #region Update Registration
        public int mUpdateRegisteration(string Email, bool Checklist, bool Agrement, bool Visible)
        {
            int result = -1;
            try
            {
                int _checklist = 0;
                if (Checklist)
                {
                    _checklist = 1;
                }

                int _Agrement = 0;
                if (Agrement)
                {
                    _Agrement = 1;
                }

                int _visible = 0;
                if (Visible)
                {
                    _visible = 1;
                }

                string SQLCommand = "delete from   Registration  where Email='" + Email + "'";
                result = SqlHelper.ExecuteNonQuery(StrCon, CommandType.Text, SQLCommand);
                SQLCommand = "insert into Registration (CheckList,Agrement,Visible,Email ) values(" + _checklist + "," + _Agrement + ", " + _visible + ",'" + Email + "')";
                result = SqlHelper.ExecuteNonQuery(StrCon, CommandType.Text, SQLCommand);
                return result;
            }
            catch (Exception ex)
            {
                string vsMessage = ex.Message;
                return -1;
            }

        }
        #endregion

        #region Delete Registration
        public int mDeleteRegisteration(string Email)
        {
            int result = -1;
            try
            {
                string SQLCommand = "DELETE FROM Registration   where Email'" + Email + "'";
                result = SqlHelper.ExecuteNonQuery(StrCon, CommandType.Text, SQLCommand);
                return result;
            }
            catch (Exception ex)
            {
                string vsMessage = ex.Message;
                return -1;
            }

        }
        #endregion

       
    }
}