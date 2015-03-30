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
using dsPhysiciansTableAdapters;
using dsGeneralCodeTableAdapters;
using dsSubCodeTableAdapters;
using dsRel_Pharmacy_PhysciansTableAdapters;
using dsRel_Physicians_MedicalAccountsTableAdapters;
using dsPhysicianScoreTableAdapters;

namespace Pharma.BMD.BLL
{
    public class PhysiciansBLL : MasterClass
    {
        int? RowsCount;
        public PhysiciansBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        // For Custom Paging //
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsPhysicians.dtPhysiciansDataTable SelectPhysicians(int startRowIndex, int maximumRows, bool ShowAll)
        {
            daPhysicians da = new daPhysicians();
            dsPhysicians.dtPhysiciansDataTable dt;
            RowsCount = 0;
            if (!CurrentUserInfo.IsUserRank || ShowAll)
            {
                // SuperAdmin
                dt = da.GetData(ShowAll, startRowIndex, ref RowsCount);
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    dt = da.GetPhysiciansByAdmin(CurrentUserInfo.UserName, ShowAll, startRowIndex, ref RowsCount);
                }
                else
                {
                    // Normal User
                    dt = da.GetPhysiciansByUser(CurrentUserInfo.UserName, ShowAll, startRowIndex, ref RowsCount);
                }
            }
            da.Dispose();
            //if (dt.Rows.Count == 0)
            //{
            //    dsSubCode.dtSubCodeDataTable dtTitles = new LookupsBLL().GetSCodeByGCode("PhysicianTitles");
            //    dsSubCode.dtSubCodeDataTable dtSpecialities = new LookupsBLL().GetSCodeByGCode("PhysicianSpecialities");
            //    dt.AdddtPhysiciansRow("", "", dtTitles[0].SID, dtSpecialities[0].SID, false, "", "", "", "",
            //        dtTitles[0].SubCode, dtSpecialities[0].SubCode, true);
            //}
            return dt;
        }

        public dsPhysicians.dtPhysiciansChangesDataTable SelectPhysiciansChanges(int OldID, int NewID)
        {
            daPhysiciansChanges da = new daPhysiciansChanges();
            dsPhysicians.dtPhysiciansChangesDataTable dt = da.GetData(OldID, NewID);
            da.Dispose();
            return dt;
        }

        public int GetCertainPageByID(int PhysicianID, bool ShowAll)
        {
            daPhysicians da = new daPhysicians();
            int PageNo;
            if (!CurrentUserInfo.IsUserRank || ShowAll)
            {
                // SuperAdmin
                PageNo = Convert.ToInt32(da.GetCertainPhysicianPage(ShowAll, PhysicianID, "-1"));
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    PageNo = Convert.ToInt32(da.GetCertainPhysicianPageByAdmin(CurrentUserInfo.UserName, ShowAll, PhysicianID, "-1"));
                }
                else
                {
                    // Normal User
                    PageNo = Convert.ToInt32(da.GetCertainPhysicianPageByUser(CurrentUserInfo.UserName, ShowAll, PhysicianID, "-1"));
                }
            }
            da.Dispose();
            return PageNo;
        }

        public int GetCertainPageByName(string PhysicianName, bool ShowAll)
        {
            daPhysicians da = new daPhysicians();
            int PageNo;
            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                PageNo = Convert.ToInt32(da.GetCertainPhysicianPage(ShowAll, -1, PhysicianName));
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    PageNo = Convert.ToInt32(da.GetCertainPhysicianPageByAdmin(CurrentUserInfo.UserName, ShowAll, -1, PhysicianName));
                }
                else
                {
                    // Normal User
                    PageNo = Convert.ToInt32(da.GetCertainPhysicianPageByUser(CurrentUserInfo.UserName, ShowAll, -1, PhysicianName));
                }
            }
            da.Dispose();
            return PageNo;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int MaxRowCount(int startRowIndex, int maximumRows, bool ShowAll)
        {
            //daPhysicians da = new daPhysicians();
            //int Count = Convert.ToInt32(da.GetPhysiciansCount(ShowAll));
            //return RowsCount.Value;
            int result = 0;
            if (RowsCount != null)
                result = RowsCount.Value;
            return result;

        }
        
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsPhysicians.dtFilteredPhysiciansDataTable SelectFilteredPhysicians(string physicianName, string AKA, int titleID, int specialityID, string privateClinic, string Score)
        {
            daFilteredPhysicians da = new daFilteredPhysicians();
            string AdminName = CurrentUserInfo.UserRole == UsersRoles.SuperUser ? CurrentUserInfo.UserName : "";
            string UserName = CurrentUserInfo.UserRole == UsersRoles.User ? CurrentUserInfo.UserName : "";
            dsPhysicians.dtFilteredPhysiciansDataTable dt = da.GetFilteredPhysicians(physicianName, AKA, titleID, specialityID, privateClinic, Score, AdminName, UserName, false);
            da.Dispose();
            return dt;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsSubCode.dtSubCodeDataTable SelectPhysicianSpecialities()
        {
            daSubCode da = new daSubCode();
            return da.GetSCodeByGCode("PhysicianSpecialities", CurrentUserInfo.UserRole == UsersRoles.SuperAdmin);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsSubCode.dtSubCodeDataTable SelectPhysicianTitles()
        {
            daSubCode da = new daSubCode();
            return da.GetSCodeByGCode("PhysicianTitles", CurrentUserInfo.UserRole == UsersRoles.SuperAdmin);
        }

        public string[] GetAllPhysiciansNames(string Prefix, out string ErrMsg)
        {
            ErrMsg = "";
            string[] Names = new string[0];
            try
            {
                dsPhysicians.dtPhysiciansDataTable dtNames = new dsPhysicians.dtPhysiciansDataTable();
                dtNames = new daPhysicians().GetIncrementalPhysiciansNames(Prefix);
                Names = new string[dtNames.Rows.Count];
                for (int i = 0; i < dtNames.Rows.Count; i++)
                {
                    Names[i] = dtNames.Rows[i]["PhysicianName"].ToString();
                }
            }
            catch (Exception Exp)
            {
                ErrMsg = Exp.Message;
            }
            return Names;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsRel_Pharmacy_Physcians.dtPharmacyPhysciansDataTable GetRxPhysicians(int PharmacyID, bool ShowAll)
        {
            daPharmacyPhyscians da = new daPharmacyPhyscians();
            dsRel_Pharmacy_Physcians.dtPharmacyPhysciansDataTable dt;

            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
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
        public dsPhysicians.dtPhysiciansNamesDataTable GetPhysicianNameList()
        {
            
            //// Normal User and Normal Admin do not show Un-Commeted Records //
            //bool ShowAll = CurrentUserInfo.UserRole != UsersRoles.User;

            daPhysiciansNames da = new daPhysiciansNames();
            dsPhysicians.dtPhysiciansNamesDataTable dt;

            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                dt = da.GetData(false);
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    dt = da.GetDataByAdmin(CurrentUserInfo.UserName, false);
                }
                else
                {
                    // Normal User
                    dt = da.GetDataByUser(CurrentUserInfo.UserName, false);
                }
            }
            da.Dispose();

            return dt;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsRel_Physicians_MedicalAccounts.dtRel_Physicians_MedicalAccountsDataTable GetMedicalAccountsAssociatedWithPhysicians(int PhysicianID, bool ShowAll, bool Changes)
        {
            daRel_Physicians_MedicalAccounts da = new daRel_Physicians_MedicalAccounts();
            if (!CurrentUserInfo.IsUserRank)
            {
                return da.GetMedicalAccountsBelongToPhysician(PhysicianID, ShowAll, Changes);
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    return da.GetMedicalAccountsBelongToPhysicianByAdmin(PhysicianID, CurrentUserInfo.UserName, ShowAll, Changes);
                }
                else
                {
                    // Normal User
                    return da.GetMedicalAccountsBelongToPhysicianByUser(PhysicianID, CurrentUserInfo.UserName, ShowAll, Changes);
                }
            }
        }

        public int AddMedicalAccountRels(int PhysicianID, int MedAccountID, bool PrescribingCapable, bool Internal, bool Consultant)
        {
            //New
            int result = 0;
            try
            {
                daRel_Physicians_MedicalAccounts da = new daRel_Physicians_MedicalAccounts();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(PhysicianID, MedAccountID, PrescribingCapable, Internal, Consultant).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestInsert(PhysicianID, MedAccountID, PrescribingCapable, Internal, Consultant).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;

            ////Old
            //daRel_Physicians_MedicalAccounts da = new daRel_Physicians_MedicalAccounts();
            //return (int)da.Insert(PhysicianID, MedAccountID, PrescribingCapable, Internal, Consultant) > 0;
        }

        public int UpdateMedicalAccountRels(int PhysicianID, int MedAccountID, bool PrescribingCapable, bool Internal, bool Consultant)
        {
            //New
            int result = 0;
            try
            {
                daRel_Physicians_MedicalAccounts da = new daRel_Physicians_MedicalAccounts();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Update(PhysicianID, MedAccountID, PhysicianID, MedAccountID, PrescribingCapable, Internal, Consultant).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestUpdate(PhysicianID, MedAccountID, PrescribingCapable, Internal, Consultant).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;

            ////Old
            //daRel_Physicians_MedicalAccounts da = new daRel_Physicians_MedicalAccounts();
            //return (int)da.Update(PhysicianID, MedAccountID, PhysicianID, MedAccountID, PrescribingCapable, Internal, Consultant) > 0;
        }

        public int DeleteMedicalAccountRels(int PhysicianID, int MedAccountID)
        {
            //New
            int result = 0;
            try
            {
                daRel_Physicians_MedicalAccounts da = new daRel_Physicians_MedicalAccounts();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Delete(PhysicianID, MedAccountID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestDelete(PhysicianID, MedAccountID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;

            ////Old
            //daRel_Physicians_MedicalAccounts da = new daRel_Physicians_MedicalAccounts();
            //return (int)da.Delete(PhysicianID, MedAccountID) > 0;
        }

        //[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        //public bool DeletePhysician(int PhysicianID)
        //{
        //    daPhysicians da = new daPhysicians();
        //    return Convert.ToInt32(da.Delete(PhysicianID)) > 0;
        //}

        public int AddNewPhysician(string PhysicianName, string AKA, int BrickID, int TitleID, int SpecialityID, bool OwnsPrivateClinic, string Mobile, string Email, string PostalCode, string Comment, out int NewID)
        {
            int result = 0;
            NewID = 0;
            try
            {
                daPhysicians da = new daPhysicians();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(PhysicianName, AKA, BrickID, TitleID, SpecialityID, OwnsPrivateClinic, Mobile, Email, PostalCode, Comment).ToString());
                    if (result > 0)
                    {
                        NewID = result;
                        result = 1;
                        //daPhysicianScore daPS = new daPhysicianScore();
                        //daPS.Insert(NewID, 0, 0, 0, 0, DateTime.Today, DateTime.Today.ToShortDateString());
                    }
                    else
                        result = 0;
                }
                else
                {
                    // Request to Add new record in database
                    result = int.Parse(da.RequestInsert(PhysicianName, AKA, BrickID, TitleID, SpecialityID, OwnsPrivateClinic, Mobile, Email, PostalCode, Comment, CurrentUserInfo.EmpID).ToString());
                    if (result > 0)
                    {
                        NewID = result;
                        result = 2;
                        //daPhysicianScore daPS = new daPhysicianScore();
                        //daPS.RequestInsert(NewID, 0, 0, 0, 0, DateTime.Today, DateTime.Today.ToShortDateString(), CurrentUserInfo.EmpID);
                    }
                    else
                        result = 0;
                }
            }
            catch { }

            return result;
        }
        public static int ResponseAddPhysician(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daPhysicians da = new daPhysicians();
                return int.Parse(da.ResponseInsert(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public bool IsPhysicianNameAndAKADuplicated(string PhysicianName, string AKA)
        {
            daPhysicians da = new daPhysicians();
            int Existance = Convert.ToInt32(da.IsPhysicianExistByNameAndAKA(PhysicianName, AKA));
            da.Dispose();
            return Existance > 0;
        }

        public bool IsUpdatedPhysicianNameAndAKADuplicated(int PhysicianID, string PhysicianName, string AKA)
        {
            daPhysicians da = new daPhysicians();
            int Existance = Convert.ToInt32(da.IsUpdatedPhysicianExistByNameAndAKA(PhysicianID, PhysicianName, AKA));
            da.Dispose();
            return Existance > 0;
        }

        public int UpdatePhysician(int PhysicianID, string PhysicianName, string AKA, int BrickID, int TitleID, int SpecialityID, bool OwnsPrivateClinic, string Mobile, string Email, string PostalCode, string Comment, out string Msg)
        {
            Msg = "";
            int result = 0;
            try
            {
                daPhysicians da = new daPhysicians();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Update in database
                    result = int.Parse(da.Update(PhysicianID, PhysicianName, AKA, BrickID, TitleID, SpecialityID, OwnsPrivateClinic, Mobile, Email, PostalCode, Comment).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    dsTransactionLogTableAdapters.daTransactionslog daT = new dsTransactionLogTableAdapters.daTransactionslog();
                    int Existance = Convert.ToInt32(daT.IsUpdatedTransactionExist(PhysicianID, "BMD_Physicians"));
                    da.Dispose();
                    if (Existance == 0)
                        // Request to Update record in database
                        result = int.Parse(da.RequestUpdate(PhysicianID, PhysicianName, AKA, BrickID, TitleID, SpecialityID, OwnsPrivateClinic, Mobile, Email, PostalCode, Comment, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                    else
                        Msg = msgErrMoreUpdateRequest;
                }
            }
            catch (Exception Exp) { Msg = Exp.Message; }

            return result;
        }
        public static int ResponseUpdatePhysician(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daPhysicians da = new daPhysicians();
                return int.Parse(da.ResponseUpdate(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int DeletePhysician(int PhysicianID)
        {
            int result = 0;
            try
            {
                daPhysicians da = new daPhysicians();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin Manager // Direct Delete in database
                    result = int.Parse(da.Delete(PhysicianID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Delete a record in database
                    result = int.Parse(da.RequestDelete(PhysicianID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }
        public static int ResponseDelete(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daPhysicians da = new daPhysicians();
                return int.Parse(da.ResponseDelete(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public dsPhysicianScore.dtPhysicianScoreDataTable SelectPhysicianScores(int PhysicianID, bool ShowAll)
        {
            return new daPhysicianScore().GetPhysicianScoresByPhysicianDesc(PhysicianID, ShowAll);
        }

        public dsPhysicianScore.dtPhysicianScoreDataTable SelectPhysicianScoresChart(int PhysicianID, bool ShowAll)
        {
            return new daPhysicianScore().GetPhysicianScoresByPhysicianAsc(PhysicianID, ShowAll);
        }

        public dsPhysicianScore.dtPhysicianScoreChangesDataTable SelectPhysicianScoresChanges(int PhysicianID)
        {
            daPhysicianScoreChanges da = new daPhysicianScoreChanges();
            dsPhysicianScore.dtPhysicianScoreChangesDataTable dt = da.GetData(PhysicianID);
            da.Dispose();
            return dt;
        }

        public int AddPhysicianScores(int PhysicianID, decimal Potential, decimal Grade, decimal Inference, decimal Additional, DateTime ScoreDate, out int NewID)
        {
            int result = 0;
            NewID = 0;
            try
            {
                daPhysicianScore da = new daPhysicianScore();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(PhysicianID, Potential, Grade, Inference, Additional, ScoreDate).ToString());
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
                    // Request to Add new Product in database
                    result = int.Parse(da.RequestInsert(PhysicianID, Potential, Grade, Inference, Additional, ScoreDate, CurrentUserInfo.EmpID).ToString());
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
        public static int ResponseAddPhysicianScores(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daPhysicianScore da = new daPhysicianScore();
                return int.Parse(da.ResponseInsert(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int UpdatePhysicianScores(int ScoreID, decimal Potential, decimal Grade, decimal Inference, decimal Additional, int PhysicianID)
        {
            int result = 0;
            try
            {
                daPhysicianScore da = new daPhysicianScore();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Update(ScoreID, Potential, Grade, Inference, Additional).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update Product in database
                    result = int.Parse(da.RequestUpdate(ScoreID, Potential, Grade, Inference, Additional, PhysicianID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch(Exception Ex) { }

            return result;
        }
        public static int ResponseUpdatePhysicianScores(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daPhysicianScore da = new daPhysicianScore();
                return int.Parse(da.ResponseUpdate(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int DeletePhysicianScores(int ScoreID)
        {
            int result = 0;
            try
            {
                daPhysicianScore da = new daPhysicianScore();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Delete(ScoreID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Add new Product in database
                    result = int.Parse(da.RequestDelete(ScoreID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }
        public static int ResponseDeleteScores(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daPhysicianScore da = new daPhysicianScore();
                return int.Parse(da.ResponseDelete(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public static int GetPhysicianIDByScoreID(int ScoreID)
        {
            daPhysicianScore da = new daPhysicianScore();
            int PhysicianID = Convert.ToInt32(da.GetPhysicianIDByScoreID(ScoreID));
            da.Dispose();
            return PhysicianID;
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public int GetPhysicianIDByName(string physicianName)
        {
            daPhysicians da = new daPhysicians();
            int physicianID = 0;
            dsPhysicians.dtPhysiciansDataTable dtPhysician = da.GetPhysicianIDByName(physicianName, false);
            if (dtPhysician.Rows.Count != 0)
                physicianID = Convert.ToInt32(dtPhysician.Rows[0]["PhysicianID"]);
            return physicianID;
        }
    }
}