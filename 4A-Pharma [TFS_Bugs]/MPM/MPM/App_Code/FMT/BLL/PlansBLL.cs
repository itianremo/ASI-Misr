using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using dsPlansTableAdapters;
using dsEmployeesTableAdapters;
using dsSearchTableAdapters;
using dsPhysiciansTableAdapters;
using dsRel_Distributors_BranchesTableAdapters;
using dsPlanModulesTableAdapters;
using dsBricksTableAdapters;
using dsSubCodeTableAdapters;

namespace Pharma.FMT.BLL
{
    public class PlansBLL : Pharma.BMD.BLL.MasterClass 
    {
        public dsEmployees.dtRoleEmployeesDataTable GetMRList(bool ShowAll)
        {
            daRoleEmployees da = new daRoleEmployees();
            dsEmployees.dtRoleEmployeesDataTable dt;

            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                dt = da.GetRoleEmployees("user", ShowAll);
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    dt = da.GetAdminEmployees(CurrentUserInfo.UserName, ShowAll);

                }
                else
                {
                    // Normal User
                    dt = new dsEmployees.dtRoleEmployeesDataTable();
                    dt.AdddtRoleEmployeesRow(CurrentUserInfo.EmpID,CurrentUserInfo.UserName, CurrentUserInfo.UserName, true, true);
                }
            }
            da.Dispose();
            return dt;

        }

        public dsPlans.dtPlanDetailsDataTable SelectPlanVisits(DateTime PlanDate, int EmpID, bool ShowAll)
        {
            daPlanDetails da = new daPlanDetails();
            dsPlans.dtPlanDetailsDataTable dt;
            dt = da.GetCertainPlan(PlanDate, EmpID, ShowAll);
            da.Dispose();
            return dt;
        }

        public bool UpdatePlanSPST(int PlanID, string StartPoint, DateTime StartTime)
        {
            daPlanDetails da = new daPlanDetails();
            bool Result = Convert.ToInt32(da.Update(PlanID, StartPoint, StartTime)) > 0;
            da.Dispose();
            return Result;
        }

        public dsPlans.dtVisitsDataTable SelectVisits(int PlanID, bool PMShift)
        {
            daVisits da = new daVisits();
            dsPlans.dtVisitsDataTable dt;
            dt = da.GetVisits(PlanID, PMShift);
            da.Dispose();
            return dt;
        }

        public dsPlans.dtVisitItemsDataTable SelectVisitsItems(int VisitID, string ItemType)
        {
            daVisitItems da = new daVisitItems();
            dsPlans.dtVisitItemsDataTable dt;
            dt = da.GetVisitItems(VisitID, ItemType); //ItemType=: 'Products' or 'MarketingMaterials'
            da.Dispose();
            return dt;
        }

        public dsPlans.dtSubModulesDataTable SelectSubModules(int VisitID)
        {
            daSubModules da = new daSubModules();
            dsPlans.dtSubModulesDataTable dt;
            dt = da.GetSubModules(VisitID); 
            da.Dispose();
            return dt;
        }

        public dsSearch.dtEntitiesNamesDataTable SelectEntitiesList(string EntityType, string EmpID)
        {
            daEntitiesNames da = new daEntitiesNames();
            dsSearch.dtEntitiesNamesDataTable dt = da.GetDataByEmpID(EntityType, EmpID, false);
            da.Dispose();
            return dt;
        }

        public dsEmployees.dtEmployeesRow GetEmployeeInfo(int EmpID)
        {
            daEmployees da = new daEmployees();
            dsEmployees.dtEmployeesDataTable dt = da.GetEmployeeByEmpID(EmpID, false);
            da.Dispose();
            return dt[0];
        }

        public dsPhysicians.dtPhysiciansNamesDataTable GetPhysiciansNamesByMedicalAccount(int MedicalAccountID)
        {
            daPhysiciansNames da = new daPhysiciansNames();
            dsPhysicians.dtPhysiciansNamesDataTable dt = da.GetDataByMedicalAccount(MedicalAccountID, false);
            da.Dispose();
            return dt;
        }

        public dsRel_Distributors_Branches.dtBranchesNamesDataTable GetBranchesNamesByDistributor(int DistributorID, int EmpID)
        {
            string UserName = GetUserNameByEmpID(EmpID);

            daBranchesNames da = new daBranchesNames();
            dsRel_Distributors_Branches.dtBranchesNamesDataTable dt = new dsRel_Distributors_Branches.dtBranchesNamesDataTable();
            dt = da.GetDataByDistributorByUser(DistributorID, UserName, false);
            da.Dispose();
            return dt;
        }

        private string GetUserNameByEmpID(int EmpID)
        {
            daEmployees daEmp = new daEmployees();
            string UserName = daEmp.GetUserNameByEmpID(EmpID, false).ToString();
            daEmp.Dispose();
            return UserName;
        }

        public dsPlanModules.dtPlanModulesDataTable SelectModulesForVisits()
        {
            daPlanModules da = new daPlanModules();
            dsPlanModules.dtPlanModulesDataTable dt;
            dt = da.GetDataForVisits();
            da.Dispose();
            return dt;
        }

        public bool IsPlanExists(DateTime PlanDate, int EmpID, out int PlanID)
        {
            daPlanDetails da = new daPlanDetails();
            object ReturnValue = da.IsPlanExists(PlanDate, EmpID);
            bool Result = false;
            PlanID = -1;

            if (ReturnValue != null)
            {
                Result = true;
                PlanID = Convert.ToInt32(ReturnValue);
            }
            da.Dispose();
            return Result;
        }
       
        public bool AddPlan(int PlanType, DateTime PlanDate, int EmpID, string StartPoint, DateTime StartTime, DateTime RequestDate, bool IsPlanned, out int NewPlanID)
        {
            bool result = false;
            NewPlanID = 0;
            try
            {
                daPlanDetails daPD = new daPlanDetails();
                //int Commit = (CurrentUserInfo.UserRole != UsersRoles.User) ? 1 : 0;
                if (IsPlanned)
                    NewPlanID = Convert.ToInt32(daPD.Insert(PlanType, PlanDate, EmpID, StartPoint, StartTime, RequestDate));
                else
                    NewPlanID = Convert.ToInt32(daPD.InsertUnPlanned(PlanType, PlanDate, EmpID, StartPoint, StartTime, RequestDate));
                
                daPD.Dispose();
                if (NewPlanID > 0)
                    result = true;
            }
            catch { }
            return result;
        }

        public bool AddPlan(int PlanType, DateTime PlanDate, int EmpID, string StartPoint, DateTime StartTime, DateTime RequestDate,
            int ModuleID, int ModuleRefID, int VisitTypeID, bool PM, string OtherDetails, bool IsPlanned, bool DoubleVisit,
            out int NewPlanID, out int NewVisitID)
        {
            bool result = false;
            NewPlanID = 0;
            NewVisitID = 0;

            try
            {
                daPlanDetails daPD = new daPlanDetails();
                //int Commit = (CurrentUserInfo.UserRole != UsersRoles.User) ? 1 : 0;
                if (IsPlanned)
                    NewPlanID = Convert.ToInt32(daPD.Insert(PlanType, PlanDate, EmpID, StartPoint, StartTime, RequestDate));
                else
                    NewPlanID = Convert.ToInt32(daPD.InsertUnPlanned(PlanType, PlanDate, EmpID, StartPoint, StartTime, RequestDate));

                daPD.Dispose();
                if (NewPlanID > 0)
                {
                    daVisits daV = new daVisits();
                    if (IsPlanned)
                        NewVisitID = Convert.ToInt32(daV.Insert(NewPlanID, ModuleID, ModuleRefID, VisitTypeID, PM, OtherDetails, DoubleVisit));
                    else
                        NewVisitID = Convert.ToInt32(daV.InsertUnPlanned(NewPlanID, ModuleID, ModuleRefID, VisitTypeID, PM, OtherDetails, DoubleVisit));
                    daV.Dispose();
                    if (NewVisitID > 0)
                        result = true;
                }
            }
            catch { }

            return result;
        }

        public bool AddVisit(int PlanID, int ModuleID, int ModuleRefID, int VisitTypeID, bool PM,
            string OtherDetails, bool IsPlanned, bool DoubleVisit, out int NewID)
        {
            bool result = false;
            NewID = 0;

            try
            {
                daVisits daV = new daVisits();
                if (IsPlanned)
                    NewID = Convert.ToInt32(daV.Insert(PlanID, ModuleID, ModuleRefID, VisitTypeID, PM, OtherDetails, DoubleVisit));
                else
                    NewID = Convert.ToInt32(daV.InsertUnPlanned(PlanID, ModuleID, ModuleRefID, VisitTypeID, PM, OtherDetails, DoubleVisit));
                daV.Dispose();
                if (NewID > 0)
                    result = true;
            }
            catch { }

            return result;
        }

        public bool AddSubModule(int VisitID, int ModuleID, int SubModuleRefID, out int NewID)
        {
            bool result = false;
            NewID = 0;

            try
            {
                daSubModules da = new daSubModules();
                NewID = Convert.ToInt32(da.Insert(VisitID, ModuleID, SubModuleRefID));
                da.Dispose();
                if (NewID > 0)
                    result = true;
            }
            catch { }

            return result;
        }

        public bool AddVisitItem(int VisitID, string ItemType, int ItemCodeID, int Quantity, out int NewID)
        {
            bool result = false;
            NewID = 0;

            try
            {
                daVisitItems da = new daVisitItems();
                NewID = Convert.ToInt32(da.Insert(VisitID, ItemType, ItemCodeID, Quantity));
                da.Dispose();
                if (NewID > 0)
                    result = true;
            }
            catch { }

            return result;
        }

        public bool IsWeekPlanCommitted(DateTime WeekStart, int EmpID)
        {
            daPlans da = new daPlans();
            bool result = Convert.ToInt32(da.IsWeekPlanCommitted(WeekStart, EmpID)) > 0;
            da.Dispose();
            return result;
        }

        public dsBricks.dtBricksDataTable SelectBricksForUser(int EmpID)
        {
            daBricks da = new daBricks();
            dsBricks.dtBricksDataTable dt = da.GetDataByEmpID(EmpID, false);
            da.Dispose();
            return dt;
        }

        public bool CommittWeekPlan(DateTime WeekStart, int EmpID, CommitCommand Command)
        {
            daPlans da = new daPlans();
            bool result = Convert.ToInt32(da.CommittWeekPlan(WeekStart, EmpID, Convert.ToInt32(Command))) > 0;
            da.Dispose();
            return result;
        }

        public dsPlans.dtWeekPlanBricksDataTable SelectBricksForUserPlan(DateTime WeekStart, int EmpID)
        {
            daWeekPlanBricks da = new daWeekPlanBricks();
            dsPlans.dtWeekPlanBricksDataTable dt = da.GetData(WeekStart, EmpID);
            da.Dispose();
            return dt;
        }

        public bool DeleteVisit(int VisitID)
        {
            daVisits da = new daVisits();
            bool Result = Convert.ToInt32(da.Delete(VisitID)) > 0;
            da.Dispose();
            return Result;
        }

        public dsPlans.dtVisitFeedBackDataTable GetVisitFeedBack(int PlanID)
        {
            daVisitFeedBack da = new daVisitFeedBack();
            dsPlans.dtVisitFeedBackDataTable dt = da.GetVisitsFeedBack(PlanID);
            da.Dispose();
            return dt;
        }

        public bool SaveVisitFeedBack(int VisitID, string VisitFeedBack, bool IsVisited)
        {
            daVisitFeedBack da = new daVisitFeedBack();
            bool Result = Convert.ToInt32(da.SetData(VisitID, VisitFeedBack, IsVisited)) > 0;
            da.Dispose();
            return Result;
        }

        public CommitCommand GetWeekPlanCommittionStatus(DateTime WeekStart, int EmpID)
        {
            daPlans da = new daPlans();
            int result = Convert.ToInt32(da.GetWeekPlanCommittionStatus(WeekStart, EmpID));
            da.Dispose();
            return (CommitCommand)result;
        }

        public dsPlans GetUserVisits(DateTime StartDate, DateTime EndDate, int EmpID)
        {
            dsPlans ds = new dsPlans();
            
            daPlans da = new daPlans();
            daSubModules daSM = new daSubModules();
            daPlanDetails daPD = new daPlanDetails();
            daVisits daV = new daVisits();
            daVisitItems daVI = new daVisitItems();
            daVisitFeedBack daVFB = new daVisitFeedBack();

            DateTime TempDate = StartDate;

            ds.dtPlans.Merge(da.GetCertainData(EmpID, StartDate, EndDate, true), true);

            while (TempDate <= EndDate)
            {
                ds.dtPlanDetails.Merge(daPD.GetCertainPlan(TempDate, EmpID, true), true);
                TempDate = TempDate.AddDays(1);
            }

            for (int i = 0; i < ds.dtPlanDetails.Rows.Count; i++)
            {
                ds.dtVisits.Merge(daV.GetVisits(ds.dtPlanDetails[i].PlanID, true), true);
                ds.dtVisits.Merge(daV.GetVisits(ds.dtPlanDetails[i].PlanID, false), true);
            }

            for (int i = 0; i < ds.dtVisits.Rows.Count; i++)
            {
                ds.dtVisitFeedBack.Merge(daVFB.GetData(ds.dtVisits[i].VisitID), true);
                ds.dtVisitItems.Merge(daVI.GetVisitItems(ds.dtVisits[i].VisitID, "Products"), true);
                ds.dtVisitItems.Merge(daVI.GetVisitItems(ds.dtVisits[i].VisitID, "MarketingMaterials"), true);
                ds.dtSubModules.Merge(daSM.GetSubModules(ds.dtVisits[i].VisitID), true);
            }

            daSM.Dispose();
            daPD.Dispose();
            daV.Dispose();
            daVI.Dispose();

            return ds;
        }

        public dsSubCode.dtSubCodeDataTable GetDayTypes()
        {
            daSubCode da = new daSubCode();
            dsSubCode.dtSubCodeDataTable dt = da.GetSCodeByGCode("PlanTypes", false);
            da.Dispose();
            return dt;
        }
    }
}