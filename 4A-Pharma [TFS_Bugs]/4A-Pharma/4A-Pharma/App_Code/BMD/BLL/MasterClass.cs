using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using dsSearchTableAdapters;
using TSHAK.Components;
using dsReportsTableAdapters;

namespace Pharma.BMD.BLL
{
    public class MasterClass :  System.Web.UI.Page 
    {
        public string msgErrDuplicatedRecord;
        public string msgErrMoreUpdateRequest;
        public string msgErrMoreDeleteUpdateRequest;

        public MasterClass() 
        {
            msgErrDuplicatedRecord = "Duplicated record!";
            msgErrMoreUpdateRequest = "You can't make any more update request to this record before your manager response to old update request.";
            msgErrMoreDeleteUpdateRequest = "You can't make any more delete request to this record before your manager response to old update request.";
        }

        public enum ApplicationDayOfWeek
        {
            Saturday = 0,
            Sunday = 1,
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6
        }

        public static DayOfWeek ApplicationToSystemDay(ApplicationDayOfWeek Day)
        {
            switch (Day)
            {
                case ApplicationDayOfWeek.Saturday:
                    return DayOfWeek.Sunday;
                case ApplicationDayOfWeek.Sunday:
                    return DayOfWeek.Monday;
                case ApplicationDayOfWeek.Monday:
                    return DayOfWeek.Tuesday;
                case ApplicationDayOfWeek.Tuesday:
                    return DayOfWeek.Wednesday;
                case ApplicationDayOfWeek.Wednesday:
                    return DayOfWeek.Thursday;
                case ApplicationDayOfWeek.Thursday:
                    return DayOfWeek.Friday;
                case ApplicationDayOfWeek.Friday:
                    return DayOfWeek.Saturday;
                default:
                    return DayOfWeek.Saturday;
            }
        }

        public static ApplicationDayOfWeek SystemToApplicationDay(DayOfWeek Day)
        {
            switch (Day)
            {
                case DayOfWeek.Friday:
                    return ApplicationDayOfWeek.Friday;
                case DayOfWeek.Monday:
                    return ApplicationDayOfWeek.Monday;
                case DayOfWeek.Saturday:
                    return ApplicationDayOfWeek.Saturday;
                case DayOfWeek.Sunday:
                    return ApplicationDayOfWeek.Sunday;
                case DayOfWeek.Thursday:
                    return ApplicationDayOfWeek.Thursday;
                case DayOfWeek.Tuesday:
                    return ApplicationDayOfWeek.Tuesday;
                case DayOfWeek.Wednesday:
                    return ApplicationDayOfWeek.Wednesday;
                default:
                    return ApplicationDayOfWeek.Saturday;
            }
        }

        public enum CommitCommand
        {
            Pending,
            Approve,
            Reject,
            Invalid,
            UnPlanned
        }

        public enum UsersRoles
        {
            SuperAdmin,
            Admin,
            Manager,
            SuperUser,
            User
        }

        public struct UserInfo
        {
            private UsersRoles _UserRole;
            private bool _IsAdminRank;
            private bool _IsUserRank;
            private string _UserName;
            private string _FullUserName;
            private int _EmpID;

            public UsersRoles UserRole
            {
                get 
                {
                    if (this._EmpID < 1)
                    {
                        if ((new Page().Session["CurrentUserInfo"]) != null)
                        {
                            this = (UserInfo)new Page().Session["CurrentUserInfo"];
                        }
                    }
                    
                    return _UserRole; 
                }
                set { _UserRole = value; }
            }
            public bool IsAdminRank
            {
                get
                {
                    if (this._EmpID < 1)
                    {
                        if ((new Page().Session["CurrentUserInfo"]) != null)
                        {
                            this = (UserInfo)new Page().Session["CurrentUserInfo"];
                        }
                    }

                    return _IsAdminRank;
                }
                set { _IsAdminRank = value; }
            }
            public bool IsUserRank
            {
                get
                {
                    if (this._EmpID < 1)
                    {
                        if ((new Page().Session["CurrentUserInfo"]) != null)
                        {
                            this = (UserInfo)new Page().Session["CurrentUserInfo"];
                        }
                    }

                    return _IsUserRank;
                }
                set { _IsUserRank = value; }
            }
            public string UserName
            {
                get
                {
                    if (this._EmpID < 1)
                    {
                        if ((new Page().Session["CurrentUserInfo"]) != null)
                        {
                            this = (UserInfo)new Page().Session["CurrentUserInfo"];
                        }
                    }

                    return _UserName;
                }
                set { _UserName = value; }
            }
            public string FullUserName
            {
                get
                {
                    if (this._EmpID < 1)
                    {
                        if ((new Page().Session["CurrentUserInfo"]) != null)
                        {
                            this = (UserInfo)new Page().Session["CurrentUserInfo"];
                        }
                    }

                    return _FullUserName;
                }
                set { _FullUserName = value; }
            }
            public int EmpID
            {
                get
                {
                    if (this._EmpID < 1)
                    {
                        if ((new Page().Session["CurrentUserInfo"]) != null)
                        {
                            this = (UserInfo)new Page().Session["CurrentUserInfo"];
                        }
                    }

                    return _EmpID;
                }
                set { _EmpID = value; }
            }
        }
        public UserInfo CurrentUserInfo;

        public struct QueryStringsValues
        {
            private string _ID;
            private string _TransType;
            private string _oldRefID;
            private string _TransModule;

            public string ID
            {
                get { return _ID; }
                set { _ID = value; }
            }
            public string TransType
            {
                get { return _TransType; }
                set { _TransType = value; }
            }
            public string oldRefID
            {
                get { return _oldRefID; }
                set { _oldRefID = value; }
            }
            public string TransModule
            {
                get { return _TransModule; }
                set { _TransModule = value; }
            }
        }
        public QueryStringsValues CurrentQueryStringsValues;

        private void GetEncryptedQueryStrings()
        {
            CurrentQueryStringsValues.TransModule = "";
            if (!String.IsNullOrEmpty(HttpContext.Current.Request["Data"]))
            {
                try
                {
                    TSHAK.Components.SecureQueryString qs = new TSHAK.Components.SecureQueryString(HttpContext.Current.Request["Data"]);
                    if (qs != null)
                    {
                        CurrentQueryStringsValues.ID = qs["ID"];
                        CurrentQueryStringsValues.TransType = qs["TransType"];
                        CurrentQueryStringsValues.oldRefID = qs["oldRefID"];
                        CurrentQueryStringsValues.TransModule = (qs["TransModule"] != null) ? qs["TransModule"] : "";
                    }
                }
                catch (Exception)
                {
                    Response.Write("Access Denied, Invalid Entry");
                    Response.End();
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Page objCurrentPage = this.Page;
            string LoginPageName = objCurrentPage.GetType().ToString();
            if (LoginPageName != "ASP.login_aspx" && LoginPageName != "ASP.fmtlogin_aspx")
            {
                AuthenticateUser();
            }
            if (Session["CurrentUserInfo"] != null)
                CurrentUserInfo = (UserInfo)Session["CurrentUserInfo"];
            base.OnLoad(e);
        }
        
        protected override void OnPreInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEncryptedQueryStrings();
                if (CurrentQueryStringsValues.TransType != null)
                {
                    base.OnPreInit(e);
                    this.MasterPageFile = "~/BlankMasterPage.master";
                }
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            base.OnLoadComplete(e);
        }

        public bool IsValidEmployee(string Username, string Password)
        {
            if (ManageUsersBLL.IsValidEmployee(Username) && Membership.ValidateUser(Username, Password))
                return true;
            else
                return false;
        }

        public bool IsValidBrickRelations(int EmpID)
        {
            return ManageUsersBLL.IsEmpHasRels(EmpID);
        }

        public string AuthenticateUser()
        {
            if (Session["User"] != null)
            {
                return Session["User"].ToString();
            }
            else
            {
                Page objCurrentPage = this.Page;
                string CurrentPageName = objCurrentPage.GetType().ToString();
                HttpContext.Current.Response.Redirect("~/Login.aspx");
                return "";
            }
        }

        private void SetEmpIDSession(string UserName)
        {
            dsEmployees.dtEmployeesDataTable dt = new dsEmployees.dtEmployeesDataTable();
            dt = new dsEmployeesTableAdapters.daEmployees().GetEmployeeByUser(UserName, false);
            if (dt.Rows.Count != 0)
            {
                CurrentUserInfo.EmpID = (int)dt.Rows[0]["EmpID"];
            }
            else
                CurrentUserInfo.EmpID = -1;
        }

        private void SetFullUserName(string UserName)
        {
            dsEmployeesTableAdapters.daEmployees da = new dsEmployeesTableAdapters.daEmployees();
            CurrentUserInfo.FullUserName = da.GetEmpNameByUserName(UserName).ToString();
            da.Dispose();
        }

        public void InitiateUserSessions()
        {
            string CurrentUser = AuthenticateUser();
            CurrentUserInfo.UserName = CurrentUser;
            SetFullUserName(CurrentUser);
            SetEmpIDSession(CurrentUser);
            if (Roles.IsUserInRole(CurrentUser, "SuperAdmin"))
            {
                CurrentUserInfo.UserRole = UsersRoles.SuperAdmin;
                CurrentUserInfo.IsAdminRank = true;
                CurrentUserInfo.IsUserRank = false;
            }
            else if (Roles.IsUserInRole(CurrentUser, "Admin"))
            {
                CurrentUserInfo.UserRole = UsersRoles.Admin;
                CurrentUserInfo.IsAdminRank = true;
                CurrentUserInfo.IsUserRank = false;
            }
            else if (Roles.IsUserInRole(CurrentUser, "Manager"))
            {
                CurrentUserInfo.UserRole = UsersRoles.Manager;
                CurrentUserInfo.IsAdminRank = false;
                CurrentUserInfo.IsUserRank = false;
            }
            else if (Roles.IsUserInRole(CurrentUser, "SuperUser"))
            {
                CurrentUserInfo.UserRole = UsersRoles.SuperUser;
                CurrentUserInfo.IsAdminRank = false;
                CurrentUserInfo.IsUserRank = true;
            }
            else
            {
                CurrentUserInfo.UserRole = UsersRoles.User;
                CurrentUserInfo.IsAdminRank = false;
                CurrentUserInfo.IsUserRank = true;
            }

            Session["CurrentUserInfo"] = CurrentUserInfo;
        }


        public string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "DESC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "DESC"))
                    {
                        sortDirection = "ASC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }
       
        /// <summary>
        /// Get All Entities Names For Incremental Search Purpose
        /// </summary>
        /// <returns>Array of strings contains all names</returns>
        public string[] GetAllEntitiesNames(string entityName, string Prefix, out string ErrMsg)
        {
            ErrMsg = "";
            string[] Names = new string[0];
            DataTable dtNames = new DataTable();
            try
            {
                daINC_Names da = new daINC_Names();
                switch (entityName)
                {
                    case "Physicians":                        
                        dtNames = da.Get_Inc_Names(Prefix, entityName, "", "", false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["PhysicianName"].ToString();
                        }
                        break;
                    case "Products":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, "", "", false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["ProductName"].ToString();
                        }
                        break;
                    case "MedicalAccounts":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, "", "", false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["Name"].ToString();
                        }
                        break;
                    case "PrivateClinics":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, "", "", false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["Name"].ToString();
                        }
                        break;
                    case "Pharmacies":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, "", "", false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["Name"].ToString();
                        }
                        break;
                    case "Distributors":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, "", "", false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["Name"].ToString();
                        }
                        break;
                    case "Users":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, "", "", false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["UserName"].ToString();
                        }
                        break;
                    case "Employees":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, "", "", false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["EmpName"].ToString();
                        }
                        break;
                    case "Pharmacists":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, "", "", false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["PharmacistName"].ToString();
                        }
                        break;
                    case "EmployeesID":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, "", "", false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["EmpID"].ToString();
                        }
                        break;
                }
                da.Dispose();
            }
            catch (Exception Exp)
            {
                ErrMsg = Exp.Message;
            }
            return Names;
        }

        /// <summary>
        /// Get All Entities Names For Incremental Search Purpose Filter by User Scope
        /// </summary>
        /// <returns>Array of strings contains all names</returns>
        public string[] GetAllEntitiesNamesByUser(string entityName, string Prefix, out string ErrMsg)
        {
            ErrMsg = "";
            string[] Names = new string[0];
            DataTable dtNames = new DataTable();
            string AdminName = CurrentUserInfo.UserRole == UsersRoles.SuperUser ? CurrentUserInfo.UserName : "";
            string UserName = CurrentUserInfo.UserRole == UsersRoles.User ? CurrentUserInfo.UserName : "";
            
            try
            {
                daINC_Names da = new daINC_Names();
                switch (entityName)
                {
                    case "Physicians":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, AdminName, UserName, false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["PhysicianName"].ToString();
                        }
                        break;
                    case "Products":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, AdminName, UserName, false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["ProductName"].ToString();
                        }
                        break;
                    case "MedicalAccounts":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, AdminName, UserName, false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["Name"].ToString();
                        }
                        break;
                    case "PrivateClinics":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, AdminName, UserName, false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["Name"].ToString();
                        }
                        break;
                    case "Pharmacies":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, AdminName, UserName, false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["Name"].ToString();
                        }
                        break;
                    case "Distributors":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, AdminName, UserName, false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["Name"].ToString();
                        }
                        break;
                    case "Users":
                        dtNames = da.Get_Inc_Names(Prefix, "Employees", AdminName, UserName, false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["EmpName"].ToString();
                        }
                        break;
                    case "Pharmacists":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, AdminName, UserName, false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["PharmacistName"].ToString();
                        }
                        break;
                    case "EmployeesID":
                        dtNames = da.Get_Inc_Names(Prefix, entityName, AdminName, UserName, false);
                        Names = new string[dtNames.Rows.Count];
                        for (int i = 0; i < dtNames.Rows.Count; i++)
                        {
                            Names[i] = dtNames.Rows[i]["EmpID"].ToString();
                        }
                        break;
                }
                da.Dispose();
            }
            catch (Exception Exp)
            {
                ErrMsg = Exp.Message;
            }
            return Names;
        }

        public string mEncryptQueryString(string strData)
        {
            this.Culture = "en-US";
            SecureQueryString qs = new SecureQueryString();
            qs["data"] = strData;
            return qs.ToString();
        }

        public bool SafeMerge(System.Data.DataSet MainDataSet, System.Data.DataSet SeconderyDataSet)
        {
            if (SeconderyDataSet != null)
            {
                MainDataSet.Clear();
                MainDataSet.Merge(SeconderyDataSet);
                MainDataSet.AcceptChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public dsReports GetAnnualVisitsReport(string EmpName, string Username, DateTime StartDate, DateTime EndDate)
        {
            dsReports ds = new dsReports();
            daAnnualVisitsByUser da = new daAnnualVisitsByUser();
            ds.dtAnnualVisitsByUser.Merge(da.GetData(Username, StartDate, EndDate));
            ds.dtReportInputs.AdddtReportInputsRow(DateTime.MinValue, DateTime.MaxValue, EmpName);
            da.Dispose();
            return ds;
        }

        public dsReports GetSamplesConsumedReport(string EmpName, int EmpID, DateTime StartDate, DateTime EndDate)
        {
            dsReports ds = new dsReports();
            daSamplesConsumedByUser da = new daSamplesConsumedByUser();
            ds.dtSamplesConsumedByUser.Merge(da.GetData(EmpID, StartDate, EndDate));
            ds.dtReportInputs.AdddtReportInputsRow(StartDate, EndDate, EmpName);
            da.Dispose();
            return ds;
        }

        public dsReports GetAccompaniedVisitsReport(DateTime StartDate, DateTime EndDate)
        {
            int Calls = 0;
            dsReports ds = new dsReports();
            daAccompaniedVisitsByUser da = new daAccompaniedVisitsByUser();

            dsEmployees.dtRoleEmployeesDataTable UsersDt = new dsEmployees.dtRoleEmployeesDataTable();
            dsEmployees.dtRoleEmployeesDataTable AdminsDt = new ManageUsersBLL().SelectAdmins();
            
            foreach (dsEmployees.dtRoleEmployeesRow AdminDr in AdminsDt)
            {
                UsersDt.Clear();
                UsersDt = new ManageUsersBLL().SelectAdminUsers(AdminDr.UserName);
                foreach (dsEmployees.dtRoleEmployeesRow UserDr in UsersDt)
                {
                    Calls += Convert.ToInt32(da.GetAccompaniedVisitsByUser(UserDr.EmpID, StartDate, EndDate));
                }
                ds.dtAccompaniedVisitsByUser.AdddtAccompaniedVisitsByUserRow(Calls, AdminDr.EmpName);
                Calls = 0;
            }

            ds.dtReportInputs.AdddtReportInputsRow(StartDate, EndDate, "");

            da.Dispose();
            return ds;
        }

        public dsReports GetAvarageDailyCallsReport(DateTime StartDate, DateTime EndDate)
        {
            int Calls = 0;
            int Days = 0;
            int Total = 0;
            TimeSpan Ts;
            dsReports ds = new dsReports();
            daAvarageDailyCallsByUser da = new daAvarageDailyCallsByUser();
            dsReports.dtAvarageDailyCallsByUserDataTable dtTemp = new dsReports.dtAvarageDailyCallsByUserDataTable();
            
            dsEmployees.dtRoleEmployeesDataTable UsersDt = new ManageUsersBLL().SelectNormalUsers();

            foreach (dsEmployees.dtRoleEmployeesRow UserDr in UsersDt)
            {
                dtTemp.Clear();
                dtTemp = da.GetData(UserDr.EmpID, StartDate, EndDate);
                Total = Convert.ToInt32(dtTemp.Compute("Sum(Calls)", string.Empty));
                Ts = EndDate.Subtract(StartDate);
                Days = Ts.Days;

                foreach (dsReports.dtAvarageDailyCallsByUserRow drTemp in dtTemp)
                {
                    drTemp.Avarage = (decimal) drTemp.Calls / ((Days != 0) ? Days : 1);
                    drTemp.ClassPercent = (decimal) drTemp.Calls / ((Total != 0) ? Total : 1);
                    drTemp.Total = Total;
                    drTemp.EmpName = UserDr.EmpName;
                }
                ds.dtAvarageDailyCallsByUser.Merge(dtTemp);
                ds.dtAvarageDailyCallsHeader.AdddtAvarageDailyCallsHeaderRow(UserDr.EmpName, Total);
            }

            ds.dtReportInputs.AdddtReportInputsRow(StartDate, EndDate, "");

            da.Dispose();
            return ds;
        }
    }
}