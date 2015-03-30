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
using dsRel_Pharmacy_DistributorsTableAdapters;
using dsDistributorsTableAdapters;
using dsRel_Distributors_BranchesTableAdapters;

namespace Pharma.BMD.BLL
{
    [System.ComponentModel.DataObject]
    public class DistributorsBLL : MasterClass
    {
        int? RowsCount;
        public DistributorsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsRel_Pharmacy_Distributors.dtPharmacyDistributorsDataTable GetRxDistributors(int PharmacyID, bool ShowAll)
        {
            daPharmacyDistributors da = new daPharmacyDistributors();
            dsRel_Pharmacy_Distributors.dtPharmacyDistributorsDataTable dt;
            if (!CurrentUserInfo.IsUserRank)
            {
                dt = da.GetData(PharmacyID, ShowAll);
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    dt = da.GetDataByAdmin(PharmacyID, CurrentUserInfo.UserName, ShowAll);
                }
                else
                {
                    // Normal User
                    dt = da.GetDataByUser(PharmacyID, CurrentUserInfo.UserName, ShowAll);
                }
            }
            da.Dispose();
            return dt;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsDistributors.dtFilteredDistributorsDataTable GetFilteredDistributors(string DistributorName, string BranchName)
        {
            daFilteredDistributors da = new daFilteredDistributors();
            string AdminName = CurrentUserInfo.UserRole == UsersRoles.SuperUser ? CurrentUserInfo.UserName : "";
            string UserName = CurrentUserInfo.UserRole == UsersRoles.User ? CurrentUserInfo.UserName : "";
            return da.GetData(DistributorName, BranchName, AdminName, UserName, false);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsDistributors.dtDistributorsDataTable GetAllDistributors(int startRowIndex, int maximumRows, bool ShowAll)
        {
            daDistributors da = new daDistributors();
            dsDistributors.dtDistributorsDataTable dt;
            RowsCount = 0;

            if (ShowAll)
            {
                dt = da.GetData(ShowAll, startRowIndex, ref RowsCount);
            }
            else
            {
                if (!CurrentUserInfo.IsUserRank)
                {
                    dt = da.GetData(ShowAll, startRowIndex, ref RowsCount);
                }
                else
                {
                    if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                    {
                        // Admin
                        dt = da.GetDistributorsByAdmin(CurrentUserInfo.UserName, ShowAll, startRowIndex, ref RowsCount);
                    }
                    else
                    {
                        // Normal User
                        dt = da.GetDistributorsByUser(CurrentUserInfo.UserName, ShowAll, startRowIndex, ref RowsCount);
                    }
                }
            }
            da.Dispose();
            return dt;
        }

        public int GetCertainPageByID(int DistributorID, bool ShowAll)
        {
            daDistributors da = new daDistributors();
            //return Convert.ToInt32(da.GetCertainDistributorPage(ShowAll, DistributorID, "-1"));
            
            //---Commented By Fawzi to get all Distributors --
            int PageNo;
            if (!CurrentUserInfo.IsUserRank || ShowAll)
            {
                // SuperAdmin
                PageNo = Convert.ToInt32(da.GetCertainDistributorPage(ShowAll, DistributorID, "-1"));
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    PageNo = Convert.ToInt32(da.GetCertainDistributorPageByAdmin(CurrentUserInfo.UserName, ShowAll, DistributorID, "-1"));
                }
                else
                {
                    // Normal User
                    PageNo = Convert.ToInt32(da.GetCertainDistributorPageByUser(CurrentUserInfo.UserName, ShowAll, DistributorID, "-1"));
                }
            }
            da.Dispose();
            return PageNo;

        }

        public int GetCertainPageByName(string DistributorName, bool ShowAll)
        {
            daDistributors da = new daDistributors();
            int PageNo;
            if (!CurrentUserInfo.IsUserRank || ShowAll)
            {
                // SuperAdmin
                PageNo = Convert.ToInt32(da.GetCertainDistributorPage(ShowAll, -1, DistributorName));
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    PageNo = Convert.ToInt32(da.GetCertainDistributorPageByAdmin(CurrentUserInfo.UserName, ShowAll, -1, DistributorName));
                }
                else
                {
                    // Normal User
                    PageNo = Convert.ToInt32(da.GetCertainDistributorPageByUser(CurrentUserInfo.UserName, ShowAll, -1, DistributorName));
                }
            }
            da.Dispose();
            return PageNo;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int MaxRowCount(int startRowIndex, int maximumRows, bool ShowAll)
        {
            //daDistributors da = new daDistributors();
            //int Count = Convert.ToInt32(da.GetDistributorsCount(ShowAll));
            //return RowsCount.Value;
            int result = 0;
            if (RowsCount != null)
                result = RowsCount.Value;
            return result;

        }

        public dsDistributors.dtDistributorsChangesDataTable SelectDistributorsChanges(int OldID, int NewID)
        {
            daDistributorsChanges da = new daDistributorsChanges();
            dsDistributors.dtDistributorsChangesDataTable dt = da.GetData(OldID, NewID);
            da.Dispose();
            return dt;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsRel_Distributors_Branches.dtRel_Distributors_BranchesDataTable GetDistributorBranches(int DistributorID, bool ShowAll)
        {
            daRel_Distributors_Branches da = new daRel_Distributors_Branches();
            if (!CurrentUserInfo.IsUserRank)
            {
                return da.GetData(DistributorID, ShowAll);
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    return da.GetDistributorBranchesByAdmin(DistributorID, CurrentUserInfo.UserName, ShowAll);
                }
                else
                {
                    // Normal User
                    return da.GetDistributorBranchesByUser(DistributorID, CurrentUserInfo.UserName, ShowAll);
                }
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsRel_Distributors_Branches.dtBranchBricksDataTable GetBranchBricks(int BranchID, bool ShowAll)
        {
            daBranchBricks da = new daBranchBricks();
            if (!CurrentUserInfo.IsUserRank)
            {
                return da.GetData(BranchID, ShowAll);
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    return da.GetBranchBricksByAdmin(BranchID, CurrentUserInfo.UserName, ShowAll);
                }
                else
                {
                    // Normal User
                    return da.GetBranchBricksByUser(BranchID, CurrentUserInfo.UserName, ShowAll);
                }
            }
        }

        public bool IsBranchNameExist(string BranchName)
        {
            daRel_Distributors_Branches da = new daRel_Distributors_Branches();
            return int.Parse(da.IsBranchExistBYName(BranchName).ToString()) > 0;
        }

        public int AddNewBranch(int DistributorID, string DistributorName, string BranchName, string BranchAddress)
        {
            int result = 0;
            try
            {
                daRel_Distributors_Branches da = new daRel_Distributors_Branches();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(DistributorID, BranchName, BranchAddress).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestInsert(DistributorID, BranchName, BranchAddress, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                    daDistributors daD = new daDistributors();
                    result = int.Parse(daD.RequestUpdate(DistributorID, DistributorName, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                    da.Dispose();
                    daD.Dispose();
                }
            }
            catch { }

            return result;
        }
        
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int UpdateBranch(int DistributorID, int BranchID, string BranchName, string BranchAddress)
        {
            int result = 0;
            try
            {
                daRel_Distributors_Branches da = new daRel_Distributors_Branches();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Update(BranchID, BranchName, BranchAddress).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestUpdate(DistributorID, BranchID, BranchName, BranchAddress).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }

        public int DeleteBranch(int DistributorID, int BranchID, out string Msg)
        {
            int result = 0;
            Msg = "";
            try
            {
                daRel_Distributors_Branches da = new daRel_Distributors_Branches();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin // Direct Delete in database
                    result = int.Parse(da.Delete(BranchID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Delete a record in database
                    dsTransactionLogTableAdapters.daTransactionslog daT = new dsTransactionLogTableAdapters.daTransactionslog();
                    int Existance = Convert.ToInt32(daT.IsUpdatedTransactionExist(DistributorID, "BMD-Distributors"));
                    da.Dispose();
                    if (Existance == 0)
                        // Request to Update record in database
                        result = int.Parse(da.RequestDelete(BranchID).ToString()) > 0 ? 2 : 0;
                    else
                        Msg = msgErrMoreDeleteUpdateRequest;
                }
            }
            catch (Exception Exp) { Msg = Exp.Message; }
            
            return result;
        }

        public bool IsDistributorNameExist(string DistributorName)
        {
            daDistributors da = new daDistributors();
            return int.Parse(da.IsDistributorExistByName(DistributorName).ToString()) > 0;
        }

        public bool IsUpdatedDistributorNameExist(int DistributorID, string DistributorName)
        {
            daDistributors da = new daDistributors();
            int Existance = Convert.ToInt32(da.IsUpdatedDistributorExistByName(DistributorID, DistributorName));
            da.Dispose();
            return Existance > 0;
        }

        public int AddNewDistributor(string DistributorName, out int NewID)
        {
            int result = 0;
            NewID = 0;
            try
            {
                daDistributors da = new daDistributors();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(DistributorName).ToString());
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
                    result = int.Parse(da.RequestInsert(DistributorName, CurrentUserInfo.EmpID).ToString());
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
        public static int ResponseAddDistributor(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daDistributors da = new daDistributors();
                return int.Parse(da.ResponseInsert(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int UpdateDistributor(int DistributorID, string DistributorName, out string Msg)
        {
            Msg = "";
            int result = 0;
            try
            {
                daDistributors da = new daDistributors();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Update in database
                    result = int.Parse(da.Update(DistributorID, DistributorName).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    dsTransactionLogTableAdapters.daTransactionslog daT = new dsTransactionLogTableAdapters.daTransactionslog();
                    int Existance = Convert.ToInt32(daT.IsUpdatedTransactionExist(DistributorID, "BMD_Distributors"));
                    da.Dispose();
                    if (Existance == 0)
                        // Request to Update record in database
                        result = int.Parse(da.RequestUpdate(DistributorID, DistributorName, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                    else
                        Msg = msgErrMoreUpdateRequest;
                }
            }
            catch (Exception Exp) { Msg = Exp.Message; }

            return result;
        }
        public static int ResponseUpdateDistributor(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daDistributors da = new daDistributors();
                return int.Parse(da.ResponseUpdate(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int DeleteDistributor(int DistributorID)
        {
            int result = 0;
            try
            {
                daDistributors da = new daDistributors();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin // Direct Delete in database
                    result = int.Parse(da.Delete(DistributorID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Delete a record in database
                    result = int.Parse(da.RequestDelete(DistributorID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }
        public static int ResponseDelete(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daDistributors da = new daDistributors();
                return int.Parse(da.ResponseDelete(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int AssignBranchToBrick(int BranchID, int BrickID)
        {
            int result = 0;
            try
            {
                daBranchBricks da = new daBranchBricks();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(BranchID, BrickID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestInsert(BranchID, BrickID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int UnAssignBranchToBrick(int BranchID, int BrickID)
        {
            int result = 0;
            try
            {
                daBranchBricks da = new daBranchBricks();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Delete(BranchID, BrickID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestDelete(BranchID, BrickID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }


    }
}