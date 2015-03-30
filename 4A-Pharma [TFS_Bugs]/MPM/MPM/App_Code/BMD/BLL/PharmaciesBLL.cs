using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Pharma.DAL;
using dsPharmaciesTableAdapters;
using dsRel_Pharmacy_MedicalAccountsTableAdapters;
using dsRel_Govs_CitiesTableAdapters;
using dsRel_Pharmacy_PhysciansTableAdapters;
using dsRel_Pharmacy_DistributorsTableAdapters;

namespace Pharma.BMD.BLL
{
    public class PharmaciesBLL : MasterClass
    {
        int? RowsCount;
        public PharmaciesBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsPharmacies.dtPharmaciesDataTable SelectPharmacies(int startRowIndex, int maximumRows, bool ShowAll)
        {
            daPharmacies da = new daPharmacies();
            dsPharmacies.dtPharmaciesDataTable dt;
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
                    dt = da.GetPharmaciesByAdmin(CurrentUserInfo.UserName, ShowAll, startRowIndex, ref RowsCount);
                }
                else
                {
                    // Normal User
                    dt = da.GetPharmaciesByUser(CurrentUserInfo.UserName, ShowAll, startRowIndex, ref RowsCount);
                }
            }
            da.Dispose();
            return dt;
        }

        public int GetCertainPageByID(int PharmacyID, bool ShowAll)
        {
            daPharmacies da = new daPharmacies();
            int PageNo;
            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                PageNo = Convert.ToInt32(da.GetCertainPharmacyPage(ShowAll, PharmacyID, "-1"));
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    PageNo = Convert.ToInt32(da.GetCertainPharmacyPageByAdmin(CurrentUserInfo.UserName, ShowAll, PharmacyID, "-1"));
                }
                else
                {
                    // Normal User
                    PageNo = Convert.ToInt32(da.GetCertainPharmacyPageByUser(CurrentUserInfo.UserName, ShowAll, PharmacyID, "-1"));
                }
            }
            da.Dispose();
            return PageNo;
        }

        public int GetCertainPageByName(string PharmacyName, bool ShowAll)
        {
            daPharmacies da = new daPharmacies();
            int PageNo;
            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                PageNo = Convert.ToInt32(da.GetCertainPharmacyPage(ShowAll, -1, PharmacyName));
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    PageNo = Convert.ToInt32(da.GetCertainPharmacyPageByAdmin(CurrentUserInfo.UserName, ShowAll, -1, PharmacyName));
                }
                else
                {
                    // Normal User
                    PageNo = Convert.ToInt32(da.GetCertainPharmacyPageByUser(CurrentUserInfo.UserName, ShowAll, -1, PharmacyName));
                }
            }
            da.Dispose();
            return PageNo;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int MaxRowCount(int startRowIndex, int maximumRows, bool ShowAll)
        {
            //daPharmacies da = new daPharmacies();
            //int Count = Convert.ToInt32(da.GetPharmaciesCount(ShowAll));
            //return RowsCount.Value;
            int result = 0;
            if (RowsCount != null)
                result = RowsCount.Value;
            return result;

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsPharmacies.dtFilteredPharmaciesDataTable SelectFilteredPharmacies(string pharmacyName, string pharmacistName, int GovID, int CityID, int BrickID)
        {
            daFilteredPharmacies da = new daFilteredPharmacies();
            string AdminName = CurrentUserInfo.UserRole == UsersRoles.SuperUser ? CurrentUserInfo.UserName : "";
            string UserName = CurrentUserInfo.UserRole == UsersRoles.User ? CurrentUserInfo.UserName : "";
            return da.GetFilteredPharmacies(pharmacyName, pharmacistName, GovID, CityID, BrickID, AdminName, UserName, false);
        }

        public dsPharmacies.dtPharmaciesChangesDataTable SelectPharmaciesChanges(int OldID, int NewID)
        {
            daPharmaciesChanges da = new daPharmaciesChanges();
            dsPharmacies.dtPharmaciesChangesDataTable dt = da.GetData(OldID, NewID);
            da.Dispose();
            return dt;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsRel_Pharmacy_MedicalAccounts.dtPharmacyMedicalAccountsDataTable GetRxMedicalAccount(int PharmacyID, bool ShowAll)
        {
            daPharmacyMedicalAccounts da = new daPharmacyMedicalAccounts();
            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                return da.GetData(PharmacyID, ShowAll);
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    return da.GetDataByAdmin(PharmacyID, CurrentUserInfo.UserName, ShowAll);
                }
                else
                {
                    // Normal User
                    return da.GetDataByUser(PharmacyID, CurrentUserInfo.UserName, ShowAll);
                }
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int UnAssignPharmacyToMedicalAccount(int PharmacyID, int MedicalAccountID)
        {
            //New
            int result = 0;
            try
            {
                daPharmacyMedicalAccounts da = new daPharmacyMedicalAccounts();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Delete(PharmacyID, MedicalAccountID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestDelete(PharmacyID, MedicalAccountID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch(Exception ex) { }

            return result;

            //////Old
            ////daPharmacyMedicalAccounts da = new daPharmacyMedicalAccounts();
            ////return int.Parse(da.Delete(PharmacyID, MedicalAccountID).ToString()) > 0;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int UnAssignPharmacyToPhysician(int PharmacyID, int PhysicianID)
        {
            //New
            int result = 0;
            try
            {
                daRel_Pharmacy_Physcians da = new daRel_Pharmacy_Physcians();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Delete(PharmacyID, PhysicianID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestDelete(PharmacyID, PhysicianID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;

            ////Old
            //daRel_Pharmacy_Physcians da = new daRel_Pharmacy_Physcians();
            //return int.Parse(da.Delete(PharmacyID, PhysicianID).ToString()) > 0;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int UnAssignPharmacyToDistributors(int PharmacyID, int DistributorsID)
        {
            int result = 0;
            try
            {
                daPharmacyDistributors da = new daPharmacyDistributors();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Delete(PharmacyID, DistributorsID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestDelete(PharmacyID, DistributorsID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }

        public int AssignPharmacyToMedicalAccount(int PharmacyID, int MedicalAccountID)
        {
            //New
            int result = 0;
            try
            {
                daPharmacyMedicalAccounts da = new daPharmacyMedicalAccounts();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(PharmacyID, MedicalAccountID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestInsert(PharmacyID, MedicalAccountID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;


            //////Old
            ////daPharmacyMedicalAccounts da = new daPharmacyMedicalAccounts();
            ////return int.Parse(da.Insert(PharmacyID, MedicalAccountID).ToString()) > 0;
        }

        public int AssignPharmacyToPhysician(int PharmacyID, int PhysicianID)
        {
            //New
            int result = 0;
            try
            {
                daRel_Pharmacy_Physcians da = new daRel_Pharmacy_Physcians();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(PharmacyID, PhysicianID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestInsert(PharmacyID, PhysicianID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }

        public int AssignPharmacyToDistributors(int PharmacyID, int DistributorID)
        {
            int result = 0;
            try
            {
                daPharmacyDistributors da = new daPharmacyDistributors();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(PharmacyID, DistributorID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestInsert(PharmacyID, DistributorID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }

        public bool IsPharmacyNameExist(string PharmacyName)
        {
            daPharmacies da = new daPharmacies();
            return int.Parse(da.IsPharmacyExistByName(PharmacyName).ToString()) > 0;
        }

        public bool IsUpdatedPharmacyNameExist(int PharmacyID, string PharmacyName)
        {
            daPharmacies da = new daPharmacies();
            int Existance = Convert.ToInt32(da.IsUpdatedPharmacyExistByName(PharmacyID, PharmacyName));
            da.Dispose();
            return Existance > 0;
        }

        public int AddNewPharmacy(string PharmacyName, int BrickID, string PharmacistName, int GovID, int CityID, string Area, string Address, string Phone1, string Phone2, string Mobile, string PostalCode, string Comment, out int NewID)
        {
            int result = 0;
            NewID = 0;
            try
            {
                daPharmacies da = new daPharmacies();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(PharmacyName, BrickID, PharmacistName, GovID, CityID, Area, Address, Phone1, Phone2, Mobile, PostalCode, Comment).ToString());
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
                    result = int.Parse(da.RequestInsert(PharmacyName, BrickID, PharmacistName, GovID, CityID, Area, Address, Phone1, Phone2, Mobile, PostalCode, Comment, CurrentUserInfo.EmpID).ToString());
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
        public static int ResponseAddPharmacy(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daPharmacies da = new daPharmacies();
                return int.Parse(da.ResponseInsert(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int UpdatePharmacy(int PharmacyID, string PharmacyName, int BrickID, string PharmacistName, int GovID, int CityID, string Area, string Address, string Phone1, string Phone2, string Mobile, string PostalCode, string Comment, out string Msg)
        {
            Msg = "";
            int result = 0;
            try
            {
                daPharmacies da = new daPharmacies();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Update in database
                    result = int.Parse(da.Update(PharmacyID, PharmacyName, BrickID, PharmacistName, GovID, CityID, Area, Address, Phone1, Phone2, Mobile, PostalCode, Comment).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    dsTransactionLogTableAdapters.daTransactionslog daT = new dsTransactionLogTableAdapters.daTransactionslog();
                    int Existance = Convert.ToInt32(daT.IsUpdatedTransactionExist(PharmacyID, "BMD_Pharmacies"));
                    da.Dispose();
                    if (Existance == 0)
                        // Request to Update record in database
                        result = int.Parse(da.RequestUpdate(PharmacyID, PharmacyName, BrickID, PharmacistName, GovID, CityID, Area, Address, Phone1, Phone2, Mobile, PostalCode, Comment, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                    else
                        Msg = msgErrMoreUpdateRequest;
                }
            }
            catch (Exception Exp) { Msg = Exp.Message; }

            return result;
        }
        public static int ResponseUpdatePharmacy(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daPharmacies da = new daPharmacies();
                return int.Parse(da.ResponseUpdate(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int DeletePharmacy(int PharmacyID)
        {
            int result = 0;
            try
            {
                daPharmacies da = new daPharmacies();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin Manager // Direct Delete in database
                    result = int.Parse(da.Delete(PharmacyID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Delete a record in database
                    result = int.Parse(da.RequestDelete(PharmacyID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }
        public static int ResponseDelete(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daPharmacies da = new daPharmacies();
                return int.Parse(da.ResponseDelete(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int GetPharmacyIDByName(string pharmacyName)
        {
            daPharmacies da = new daPharmacies();
            int pharmacyID = 0;
            dsPharmacies.dtPharmaciesDataTable dtPharmacy = da.GetPharmacyIDByName(pharmacyName, false);
            if (dtPharmacy.Rows.Count != 0)
                pharmacyID = Convert.ToInt32(dtPharmacy.Rows[0]["PharmacyID"]);
            return pharmacyID;
        }

    }
}