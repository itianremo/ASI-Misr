using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Office.DAL.ApplicationBlocks;

namespace Office.DAL
{
    public sealed class BaseClass
    {
        public static string strConnection = ConfigurationManager.ConnectionStrings["ASI-CRMConnectionString"].ConnectionString;
        static int AffectedRows;
        public static int InsertCommand(string SPName,params object [] InsertParameters)
        {
            return Office.DAL.ApplicationBlocks.SqlHelper.ExecuteNonQuery(strConnection, SPName, InsertParameters);
        }
        // new sclare static function return the new record - mglil
        public static object ScalreInsertCommand(string SPName, params object[] InsertParameters)
        {
            return Office.DAL.ApplicationBlocks.SqlHelper.ExecuteScalar(strConnection, SPName, InsertParameters);
        }
        // end - mglil
        public static int UpdateCommand(string SPName, params object[] InsertParameters)
        {
            return Office.DAL.ApplicationBlocks.SqlHelper.ExecuteNonQuery(strConnection, SPName, InsertParameters);
        }

        public static object ReturnValueCommand(string SPName, params object[] InsertParameters)
        {
            SqlCommand cmd = new SqlCommand(SPName, new SqlConnection(strConnection));
            cmd.CommandType = CommandType.StoredProcedure;

            if ((InsertParameters != null) && (InsertParameters.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(strConnection, SPName);
                SqlHelper.AssignParameterValues(commandParameters, InsertParameters);
                cmd.Parameters.AddRange(commandParameters);
            }
            
            cmd.Connection.Open();
            cmd.ExecuteScalar();
            object result = cmd.Parameters[cmd.Parameters.Count - 1].Value;
            cmd.Connection.Close();
            return result;

            // Old function, commented by Yasser 28/1/2009.
            //return Office.DAL.ApplicationBlocks.SqlHelper.ExecuteNonQuery(strConnection, CommandType.StoredProcedure, SPName, InsertParameters);
        }

        public static void SelectCommand(string SPName, params object[] InsertParameters)
        {
            Office.DAL.ApplicationBlocks.SqlHelper.ExecuteReader(strConnection, SPName, InsertParameters);
        }

        public static string EncodeString(string InputStr)
        {
            if (InputStr == null)
                return null;

            return InputStr.Replace("'", "#q1#").Replace("\"", "#q2#");
        }

        public static string DecodeString(string InputStr)
        {
            if (InputStr == null)
                return null;

            return InputStr.Replace("#q1#", "'").Replace("#q2#", "\"");
        }
    }
}