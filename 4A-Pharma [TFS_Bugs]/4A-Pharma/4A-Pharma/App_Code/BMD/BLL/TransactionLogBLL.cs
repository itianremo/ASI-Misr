using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using dsTransactionLogTableAdapters;

namespace Pharma.BMD.BLL
{
    public class TransactionLogBLL : MasterClass
    {
        int? RowsCount;

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsTransactionLog.dtTransactionslogDataTable GetTransactions(int startRowIndex, int maximumRows, string OrderBy, string OrderByDirection)
        {
            daTransactionslog da = new daTransactionslog();
            dsTransactionLog.dtTransactionslogDataTable dt = null;
            bool ShowAll = false;
            RowsCount = 0;

            if (!CurrentUserInfo.IsUserRank)
            {
                bool ShowDeleted = CurrentUserInfo.UserRole == UsersRoles.SuperAdmin;
                bool ShowEmployees = CurrentUserInfo.IsAdminRank;
                dt = da.GetData(ShowDeleted, ShowEmployees, (startRowIndex) / maximumRows, maximumRows, OrderBy, OrderByDirection, ref RowsCount);
            }
            else if (CurrentUserInfo.UserRole == UsersRoles.User)
            {
                dt = da.GetTransactionsByUserID(ShowAll, CurrentUserInfo.EmpID, (startRowIndex) / maximumRows, maximumRows, OrderBy, OrderByDirection, ref RowsCount);
            }
            else if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
            {
                // Super User
                dt = da.GetTransactionsByAdmin(ShowAll, CurrentUserInfo.UserName, (startRowIndex) / maximumRows, maximumRows, OrderBy, OrderByDirection, ref RowsCount);
            }
            da.Dispose();
            return dt;
        }

        public int GetCertainPageByID(int TransID, bool ShowAll, int PageSize)
        {
            daTransactionslog da = new daTransactionslog();
            int PageNo = Convert.ToInt32(da.GetCertainTransactionPage(ShowAll, TransID, "-1", PageSize));
            da.Dispose();
            return PageNo;
        }

        public int GetCertainPageByName(string TransName, bool ShowAll, int PageSize)
        {
            daTransactionslog da = new daTransactionslog();
            int PageNo = Convert.ToInt32(da.GetCertainTransactionPage(ShowAll, -1, TransName, PageSize));
            da.Dispose();
            return PageNo;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int MaxRowCount(int startRowIndex, int maximumRows, string OrderBy, string OrderByDirection)
        {
            //return RowsCount.Value;
            int result = 0;
            if (RowsCount != null)
                result = RowsCount.Value;
            return result;

        }
    }
}