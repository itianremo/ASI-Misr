using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using dsMedicalAccountsTableAdapters;
using dsProductFeedbackTableAdapters;
using dsRel_Pharmacy_MedicalAccountsTableAdapters;

namespace Pharma.BMD.BLL
{
    [System.ComponentModel.DataObject]
    public class MedicalAccountsBLL : MasterClass
    {
        int? RowsCount;
        public MedicalAccountsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsMedicalAccounts.dtMedicalAccountsDataTable SelectMedicalAccounts(int startRowIndex, int maximumRows, bool ShowAll)
        {
            daMedicalAccounts da = new daMedicalAccounts();
            dsMedicalAccounts.dtMedicalAccountsDataTable dt;
            RowsCount = 0;
            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                dt = da.GetData(ShowAll, startRowIndex, ref RowsCount);
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    dt = da.GetMedicalAccountsByAdmin(CurrentUserInfo.UserName, ShowAll, startRowIndex,ref RowsCount);
                }
                else
                {
                    // Normal User
                    dt = da.GetMedicalAccountsByUser(CurrentUserInfo.UserName, ShowAll, startRowIndex, ref RowsCount);
                }
            }
            da.Dispose();
            //if (dt.Rows.Count == 0)
            //{
            //    dsBricks.dtBricksDataTable dtBricks = new LookupsBLL().SelectBricks();
            //    dt.AdddtMedicalAccountsRow("", dtBricks[0].BrickID, dtTitles[0].SID, dtSpecialities[0].SID, false, "", "", "", "",
            //        dtTitles[0].SubCode, dtSpecialities[0].SubCode, true);
            //}
            return dt;
        }

        public int GetCertainPageByID(int MedicalAccountID, bool ShowAll)
        {
            daMedicalAccounts da = new daMedicalAccounts();
            int PageNo;
            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                PageNo = Convert.ToInt32(da.GetCertainMedicalAccountPage(ShowAll, MedicalAccountID, "-1"));
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    PageNo = Convert.ToInt32(da.GetCertainMedicalAccountPageByAdmin(CurrentUserInfo.UserName, ShowAll, MedicalAccountID, "-1"));
                }
                else
                {
                    // Normal User
                    PageNo = Convert.ToInt32(da.GetCertainMedicalAccountPageByUser(CurrentUserInfo.UserName, ShowAll, MedicalAccountID, "-1"));
                } 
            }
            da.Dispose();
            return PageNo;
        }

        public int GetCertainPageByName(string MedicalAccountName, bool ShowAll)
        {
            daMedicalAccounts da = new daMedicalAccounts();
            int PageNo;
            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                PageNo = Convert.ToInt32(da.GetCertainMedicalAccountPage(ShowAll, -1, MedicalAccountName));
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    PageNo = Convert.ToInt32(da.GetCertainMedicalAccountPageByAdmin(CurrentUserInfo.UserName, ShowAll, -1, MedicalAccountName));
                }
                else
                {
                    // Normal User
                    PageNo = Convert.ToInt32(da.GetCertainMedicalAccountPageByUser(CurrentUserInfo.UserName, ShowAll, -1, MedicalAccountName));
                }
            }
            da.Dispose();
            return PageNo;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int MaxRowCount(int startRowIndex, int maximumRows, bool ShowAll)
        {
            //daMedicalAccounts da = new daMedicalAccounts();
            //int Count = Convert.ToInt32(da.GetMedicalAccountsCount(ShowAll));
            //return RowsCount.Value;
            int result = 0;
            if (RowsCount != null)
                result = RowsCount.Value;
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsMedicalAccounts.dtFilteredMedicalAccountsDataTable SelectFilteredMedAccounts(string medAccName, int subOrdinationID, int GovID, int CityID, int BrickID)
        {
            daFilteredMedicalAccounts da = new daFilteredMedicalAccounts();
            string AdminName = CurrentUserInfo.UserRole == UsersRoles.SuperUser ? CurrentUserInfo.UserName : "";
            string UserName = CurrentUserInfo.UserRole == UsersRoles.User ? CurrentUserInfo.UserName : "";
            return da.GetFilteredMedicalAccounts(medAccName, subOrdinationID, GovID, CityID, BrickID, AdminName, UserName, false);
        }

        public bool IsMedicalAccountNameExist(string MedicalAccountName)
        {
            daMedicalAccounts da = new daMedicalAccounts();
            return int.Parse(da.IsMedicalAccountExistByName(MedicalAccountName).ToString()) > 0;
        }

        public bool IsUpdatedMedicalAccountNameExist(int MedicalAccountID, string MedicalAccountName)
        {
            daMedicalAccounts da = new daMedicalAccounts();
            int Existance = Convert.ToInt32(da.IsUpdatedMedicalAccountExistByName(MedicalAccountID, MedicalAccountName));
            da.Dispose();
            return Existance > 0;
        }

        public int AddMedicalAccount(string MedicalAccountsName, int BrickID, int SubordinationID, int GovID, int CityID, string Area, string Address, string Phone1, string Mobile, string PostalCode, int ICUNO, int NoMedicalyServedPts, decimal RxFinancialLimits, decimal MonRxFinancialLimits, decimal AnnualRxFinancialLimits, bool DrugDeliveryInternal, bool DrugDeliveryExternal, bool DrugDirectOrders, bool DrugPurchaseTender, int TotalRxDay, int TotalRxWeek, int TotalRxMonth, out int NewID)
        {
            int result = 0;
            NewID = 0;
            try
            {
                daMedicalAccounts da = new daMedicalAccounts();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(MedicalAccountsName, BrickID, SubordinationID, GovID, CityID, Area, Address, Phone1, Mobile, PostalCode, ICUNO, NoMedicalyServedPts, RxFinancialLimits, MonRxFinancialLimits, AnnualRxFinancialLimits, DrugDeliveryInternal, DrugDeliveryExternal, DrugDirectOrders, DrugPurchaseTender, TotalRxDay, TotalRxWeek, TotalRxMonth).ToString());
                    if (result > 0)
                    {
                        NewID = result;
                        result = 1;
                    }
                    else
                        result = 0;
                }
                else
                {
                    // Request to Add new record in database
                    result = int.Parse(da.RequestInsert(MedicalAccountsName, BrickID, SubordinationID, GovID, CityID, Area, Address, Phone1, Mobile, PostalCode, ICUNO, NoMedicalyServedPts, RxFinancialLimits, MonRxFinancialLimits, AnnualRxFinancialLimits, DrugDeliveryInternal, DrugDeliveryExternal, DrugDirectOrders, DrugPurchaseTender, TotalRxDay, TotalRxWeek, TotalRxMonth, CurrentUserInfo.EmpID).ToString());
                    if (result > 0)
                    {
                        NewID = result;
                        result = 2;
                    }
                    else
                        result = 0;
                }
            }
            catch { }

            return result;
        }
        public static int ResponseAddMedicalAccount(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daMedicalAccounts da = new daMedicalAccounts();
                return int.Parse(da.ResponseInsert(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int UpdateMedicalAccount(int MedicalAccountID, string MedicalAccountsName, int BrickID, int SubordinationID, int GovID, int CityID, string Area, string Address, string Phone1, string Mobile, string PostalCode, int ICUNO, int NoMedicalyServedPts, decimal RxFinancialLimits, decimal MonRxFinancialLimits, decimal AnnualRxFinancialLimits, bool DrugDeliveryInternal, bool DrugDeliveryExternal, bool DrugDirectOrders, bool DrugPurchaseTender, int TotalRxDay, int TotalRxWeek, int TotalRxMonth, out string Msg)
        {
            Msg = "";
            int result = 0;
            try
            {
                daMedicalAccounts da = new daMedicalAccounts();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Update(MedicalAccountID, MedicalAccountsName, BrickID, SubordinationID, GovID, CityID, Area, Address, Phone1, Mobile, PostalCode, ICUNO, NoMedicalyServedPts, RxFinancialLimits, MonRxFinancialLimits, AnnualRxFinancialLimits, DrugDeliveryInternal, DrugDeliveryExternal, DrugDirectOrders, DrugPurchaseTender, TotalRxDay, TotalRxWeek, TotalRxMonth).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    dsTransactionLogTableAdapters.daTransactionslog daT = new dsTransactionLogTableAdapters.daTransactionslog();
                    int Existance = Convert.ToInt32(daT.IsUpdatedTransactionExist(MedicalAccountID, "BMD_MedicalAccounts"));
                    da.Dispose();
                    if (Existance == 0)
                        // Request to Update record in database
                        result = int.Parse(da.RequestUpdate(MedicalAccountID, MedicalAccountsName, BrickID, SubordinationID, GovID, CityID, Area, Address, Phone1, Mobile, PostalCode, ICUNO, NoMedicalyServedPts, RxFinancialLimits, MonRxFinancialLimits, AnnualRxFinancialLimits, DrugDeliveryInternal, DrugDeliveryExternal, DrugDirectOrders, DrugPurchaseTender, TotalRxDay, TotalRxWeek, TotalRxMonth, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                    else
                        Msg = msgErrMoreUpdateRequest;
                }
            }
            catch (Exception Exp) { Msg = Exp.Message; }

            return result;
        }
        public static int ResponseUpdateMedicalAccount(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daMedicalAccounts da = new daMedicalAccounts();
                return int.Parse(da.ResponseUpdate(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int DeleteMedicalAccount(int MedicalAccountID)
        {
            int result = 0;
            try
            {
                daMedicalAccounts da = new daMedicalAccounts();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Delete(MedicalAccountID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Add new Product in database
                    result = int.Parse(da.RequestDelete(MedicalAccountID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }
        public static int ResponseDelete(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daMedicalAccounts da = new daMedicalAccounts();
                return int.Parse(da.ResponseDelete(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsProductFeedback.dtProductFeedbackDataTable GetProductFeedback(int ProductID, int MedicalAccountID, bool ShowAll)
        {
            daProductFeedback da = new daProductFeedback();
            return da.GetProductFeedbackByProductAndMedicalAccount(ProductID, MedicalAccountID, ShowAll);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public bool UpdateProductFeedback(int ProductFeedbackID, int ProductID, int MedicalAccountID, int Group_Total_Average_day, int Group_Total_Average_Week, int Group_Total_Average_Month, int Product_Competitors_Average_Day, int Product_Competitors_Average_Week, int Product_Competitors_Average_Month, int Product_Total_Day, int Product_Total_Week, int Product_Total_Month)
        {
            daProductFeedback da = new daProductFeedback();
            if (CurrentUserInfo.UserRole != UsersRoles.User)
            {
                return int.Parse(da.Update(ProductFeedbackID, ProductID, MedicalAccountID, Group_Total_Average_day, Group_Total_Average_Week, Group_Total_Average_Month, Product_Competitors_Average_Day, Product_Competitors_Average_Week, Product_Competitors_Average_Month, Product_Total_Day, Product_Total_Week, Product_Total_Month).ToString()) > 0;
            }
            else
            {
                return int.Parse(da.RequestUpdate(ProductFeedbackID, ProductID, MedicalAccountID, Group_Total_Average_day, Group_Total_Average_Week, Group_Total_Average_Month, Product_Competitors_Average_Day, Product_Competitors_Average_Week, Product_Competitors_Average_Month, Product_Total_Day, Product_Total_Week, Product_Total_Month).ToString()) > 0;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public bool InsertProductFeedback(int ProductID, int MedicalAccountID, int Group_Total_Average_day, int Group_Total_Average_Week, int Group_Total_Average_Month, int Product_Competitors_Average_Day, int Product_Competitors_Average_Week, int Product_Competitors_Average_Month, int Product_Total_Day, int Product_Total_Week, int Product_Total_Month)
        {
            daProductFeedback da = new daProductFeedback();
            if (CurrentUserInfo.UserRole != UsersRoles.User)
            {
                return int.Parse(da.Insert(ProductID, MedicalAccountID, Group_Total_Average_day, Group_Total_Average_Week, Group_Total_Average_Month, Product_Competitors_Average_Day, Product_Competitors_Average_Week, Product_Competitors_Average_Month, Product_Total_Day, Product_Total_Week, Product_Total_Month).ToString()) > 0;
            }
            else 
            {
                return int.Parse(da.RequestInsert(ProductID, MedicalAccountID, Group_Total_Average_day, Group_Total_Average_Week, Group_Total_Average_Month, Product_Competitors_Average_Day, Product_Competitors_Average_Week, Product_Competitors_Average_Month, Product_Total_Day, Product_Total_Week, Product_Total_Month).ToString()) > 0;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsRel_Pharmacy_MedicalAccounts.dtPharmacyMedicalAccountsDataTable GetPharmaciesBelongToMedicalAccount(int MedicalAccountID, bool ShowAll)
        {
            daPharmacyMedicalAccounts da = new daPharmacyMedicalAccounts();

            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                return da.GetPharmaciesBelongToMedicalAccount(MedicalAccountID, ShowAll);
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    return da.GetPharmaciesBelongToMedicalAccountByAdmin(MedicalAccountID, CurrentUserInfo.UserName, ShowAll);
                }
                else
                {
                    // Normal User
                    return da.GetPharmaciesBelongToMedicalAccountByUser(MedicalAccountID, CurrentUserInfo.UserName, ShowAll);
                }
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int GetMedicalAccountIDByName(string medicalAccountName)
        {
            daMedicalAccounts da = new daMedicalAccounts();
            int medicalAccountID = 0;
            dsMedicalAccounts.dtMedicalAccountsDataTable dtMedicalAccount = da.GetMedicalAccountIDByName(medicalAccountName, false);
            if (dtMedicalAccount.Rows.Count != 0)
                medicalAccountID = Convert.ToInt32(dtMedicalAccount.Rows[0]["MedicalAccountID"]);
            return medicalAccountID;
        }

    }
}