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
using dsEmployeesTableAdapters;
using dsSubCodeTableAdapters;
using dsBricksTableAdapters;
using dsRel_Bricks_UsersTableAdapters;
using dsProductsTableAdapters;

namespace Pharma.BMD.BLL
{
    [System.ComponentModel.DataObject]
    public class ManageUsersBLL : MasterClass
    {
        int? RowsCount;
        public ManageUsersBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public dsEmployees.dtEmployeesDataTable SelectAllUsers(int startRowIndex, int maximumRows, bool ShowAll)
        {
            daEmployees da = new daEmployees();
            dsEmployees.dtEmployeesDataTable dt;
            RowsCount = 0;

            dt = da.GetData(ShowAll, startRowIndex, ref RowsCount);
            if (dt.Rows.Count == 0)
            {
                dt.AdddtEmployeesRow("", "No Records.", "", 0, true, "", "", true, 0, "", "", "", "");
            }
            da.Dispose();
            return dt;
        }

        public string SelectUserNameByEmpName(string LoweredEmpName, bool ShowAll)
        {
            daEmployees da = new daEmployees();
            dsEmployees.dtEmployeesDataTable dt;
            string UserName = "";

            dt = da.GetEmployeeByEmpName(LoweredEmpName, ShowAll);

            if (dt.Rows.Count > 0)
                UserName = dt[0].UserName;

            da.Dispose();
            return UserName;
        }

        public int SelectEmpIDByUserName(string UserName, bool ShowAll)
        {
            daEmployees da = new daEmployees();
            dsEmployees.dtEmployeesDataTable dt;
            int EmpID = -1;

            dt = da.GetEmployeeByUser(UserName, ShowAll);

            if (dt.Rows.Count > 0)
                EmpID = dt[0].EmpID;

            da.Dispose();
            return EmpID;
        }

        public int GetCertainPageByID(int EmployeeID, bool ShowAll)
        {
            daEmployees da = new daEmployees();
            int PageNo = Convert.ToInt32(da.GetCertainEmployeePage(ShowAll, EmployeeID, "-1"));
            da.Dispose();
            return PageNo;
        }
        
        public int GetCertainPageByName(string EmpName, bool ShowAll)
        {
            daEmployees da = new daEmployees();
            int PageNo = Convert.ToInt32(da.GetCertainEmployeePage(ShowAll, -1, EmpName));
            da.Dispose();
            return PageNo;
        }

        public int GetCertainPageByUserName(string UserName, bool ShowAll)
        {
            daEmployees da = new daEmployees();
            int PageNo = Convert.ToInt32(da.GetCertainEmployeePageByUserName(ShowAll, -1, UserName));
            da.Dispose();
            return PageNo;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int MaxRowCount(int startRowIndex, int maximumRows, bool ShowAll)
        {
            //daEmployees da = new daEmployees();
            //int Count = Convert.ToInt32(da.GetEmployeesCount(ShowAll));
            return RowsCount.Value;
        }

        public dsEmployees.dtEmployeesDataTable SelectEmployeeByID(int EmpID, bool ShowAll)
        {
            daEmployees da = new daEmployees();
            dsEmployees.dtEmployeesDataTable dt = da.GetEmployeeByEmpID(EmpID, ShowAll);
            da.Dispose();
            return dt;
        }

        //public dsEmployees.dtEmployeesDataTable SelectUsersUnderCurrentUser()
        //{
        //    dsEmployees.dtEmployeesDataTable dt = new dsEmployees.dtEmployeesDataTable();

        //    //if (!CurrentUserInfo.IsUserRank)
        //    //{
        //    // SuperAdmin: Get all users
        //    dt = new daEmployees().GetData(false);
        //    if (dt.Rows.Count == 0)
        //    {
        //        dt.AdddtEmployeesRow("", "No Records.", "", 0, true, "", "", true, 0);
        //    }
        //    //}
        //    //else
        //    //{
        //    //    if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
        //    //    {
        //    //        // Admin: Get all users belong to this admin
        //    //        dt = new daEmployees().GetEmployeesByRole(CurrentUserInfo.UserName.ToLower(), false);
        //    //        if (dt.Rows.Count == 0)
        //    //        {
        //    //            dt.AdddtEmployeesRow("", "No Records.", "", 0, true, "", "", true);
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        // Normal User: Get this user data only.
        //    //        dt = new daEmployees().GetEmployeeByUser(CurrentUserInfo.UserName.ToLower(), false);
        //    //        if (dt.Rows.Count == 0)
        //    //        {
        //    //            dt.AdddtEmployeesRow("", "No Records.", "", 0, true, "", "", true);
        //    //        }
        //    //    }
        //    //}

        //    return dt;
        //}

        public dsEmployees.dtRoleEmployeesDataTable SelectAdmins()
        {
            dsEmployees.dtRoleEmployeesDataTable dt = new dsEmployees.dtRoleEmployeesDataTable();

            dt = new daRoleEmployees().GetRoleEmployees("SuperUser", false);
            if (dt.Rows.Count == 0)
            {
                dt.AdddtRoleEmployeesRow(1,"No Records.", "", true, false);
            }

            return dt;
        }

        public dsEmployees.dtRoleEmployeesDataTable SelectAdmins(string AdminToExeclude)
        {
            dsEmployees.dtRoleEmployeesDataTable dt = new dsEmployees.dtRoleEmployeesDataTable();

            dt = new daRoleEmployees().GetRoleEmployees("SuperUser", false);
            if (dt.Rows.Count == 0)
            {
                dt.AdddtRoleEmployeesRow(1, "No Records.", "", true, false);
            }
            else
            {
                int i = 0;
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt[i].UserName == AdminToExeclude)
                        break;
                }
                i = (i == dt.Rows.Count) ? i - 1 : i;
                dt.Rows.RemoveAt(i);
            }
            return dt;
        }

        public dsEmployees.dtRoleEmployeesDataTable SelectNormalUsers()
        {
            dsEmployees.dtRoleEmployeesDataTable dt = new dsEmployees.dtRoleEmployeesDataTable();

            dt = new daRoleEmployees().GetRoleEmployees("user", false);

            return dt;
        }

        public dsEmployees.dtRoleEmployeesDataTable SelectAdminUsers(string AdminName)
        {
            dsEmployees.dtRoleEmployeesDataTable dt = new dsEmployees.dtRoleEmployeesDataTable();

            dt = new daRoleEmployees().GetAdminEmployees(AdminName, false);

            return dt;
        }
        public dsEmployees.dtRoleEmployeesDataTable SelectEmployeesByAdminToSuperAdmin(string AdminName)
        {
            dsEmployees.dtRoleEmployeesDataTable dt = new dsEmployees.dtRoleEmployeesDataTable();

            dt = new daRoleEmployees().GetEmployeesNamesByAdminToSuperAdmin(AdminName, false);

            return dt;
        }

        public string GetAdminEmpIDForUser(string UserName)
        {
            daEmployees da = new daEmployees();
            string[] RolesNames = Roles.GetRolesForUser(UserName);
            string AdminName = (RolesNames[0] != "User") ? RolesNames[0] : RolesNames[1];
            return da.GetEmployeeByUser(AdminName, false)[0].EmpID.ToString();
        }

        public string GetAdminEmpNameForUser(string UserName)
        {
            daEmployees da = new daEmployees();
            string[] RolesNames = Roles.GetRolesForUser(UserName);
            string AdminName = (RolesNames[0] != "User") ? RolesNames[0] : RolesNames[1];
            return da.GetEmployeeByUser(AdminName, false)[0].EmpName;
        }

        public string GetAdminRoleNameForUser(string UserName)
        {
            daEmployees da = new daEmployees();
            string[] RolesNames = Roles.GetRolesForUser(UserName);
            string AdminName = (RolesNames[0] != "User") ? RolesNames[0] : RolesNames[1];
            return da.GetEmployeeByUser(AdminName, false)[0].UserName;
        }

        public bool IsEmpHasBricks(int EmpID)
        {
            daBricks da = new daBricks();
            return (Convert.ToInt32(da.IsEmployeeHasBricks(EmpID, true)) > 0);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsSubCode.dtSubCodeDataTable SelectUsersTitles()
        {
            dsSubCode.dtSubCodeDataTable dt = new dsSubCode.dtSubCodeDataTable();

            if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                dt = new daSubCode().GetSCodeByGCode("EmployeeTitles", true);
            else
                dt = new daSubCode().GetSCodeByGCode("EmployeeTitles", false);

            if (dt.Rows.Count == 0)
            {
                dt.AdddtSubCodeRow("No Records.", 0, "", true);
            }
            return dt;
        }

        public bool IsTitleExist(string TitleName)
        {
            daSubCode da = new daSubCode();
            return (int)da.IsSubCodeExistByCode(TitleName, "EmployeeTitles") > 0;
        }

        public bool AddUserTitle(string TitleName)
        {
            daSubCode da = new daSubCode();
            return (int)da.InsertSCodeByGCode(TitleName, "EmployeeTitles") > 0;
        }

        public bool IsTitleAssignedToAnyEmployee(int TitleID)
        {
            daEmployees da = new daEmployees();
            return (int)da.IsEmployeeExistByTitle(TitleID) > 0;
        }

        public bool DeleteUserTitle(int TitleID)
        {
            daSubCode da = new daSubCode();
            return (int)da.Delete(TitleID) > 0;
        }

        public bool IsNIDExist(decimal NID)
        {
            daEmployees da = new daEmployees();
            return int.Parse(da.IsNIDExist(NID).ToString()) > 0;
        }

        public bool IsUpdatedNIDExist(int EmpID, decimal NID)
        {
            daEmployees da = new daEmployees();
            int Existance = Convert.ToInt32(da.IsUpdatedNIDExist(EmpID, NID));
            da.Dispose();
            return Existance > 0;
        }

        public bool IsUpdatedTitleExist(int TitleID, string TitleName)
        {
            daSubCode da = new daSubCode();
            return (int)da.IsUpdatedSubCodeExistByCode(TitleID, TitleName, "EmployeeTitles") > 0;
        }

        public bool UpdateUserTitle(int TitleID, string TitleName)
        {
            daSubCode da = new daSubCode();
            return (int)da.UpdateCode(TitleID, TitleName) > 0;
        }

        public dsRel_Bricks_Users.dtEmployeeBricksDataTable SelectUsersBricks(int EmpID, bool ShowAll, bool Select)
        {
            dsRel_Bricks_Users.dtEmployeeBricksDataTable dt = new dsRel_Bricks_Users.dtEmployeeBricksDataTable();
            dt = new daEmployeeBricks().GetData(EmpID, ShowAll, Select);
            //if (dt.Rows.Count == 0)
            //{
            //    dt.AdddtEmployeeBricksRow(0, 0, "No Records.", true, DateTime.MinValue, false);
            //    dt[0].SetExpireDateNull();
            //}
            return dt;
        }

        public int UpdateExpireDate(int EmpID, int BrickID, DateTime? ExpireDate)
        {
            daEmployeeBricks da = new daEmployeeBricks();
            return int.Parse(da.UpdateExpireDate(EmpID, BrickID, ExpireDate).ToString());
        }

        public bool IsBrickExist(string BrickName)
        {
            daBricks da = new daBricks();
            return (int)da.IsBrickExistByName(BrickName) > 0;
        }

        public int AddUserBrick(string BrickName)
        {
            daBricks da = new daBricks();
            return int.Parse(da.Insert(BrickName).ToString());
        }

        public int AssignBrickToUser(int BrickID, int EmpID)
        {
            int result = 0;
            try
            {
                daRel_Bricks_Users da = new daRel_Bricks_Users();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(BrickID, EmpID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestInsert(BrickID, EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }

        public int DeAssignBrickFromUser(int BrickID, int EmpID)
        {
            int result = 0;
            try
            {
                daRel_Bricks_Users da = new daRel_Bricks_Users();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Delete(BrickID, EmpID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestDelete(BrickID, EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch (Exception ex) { }

            return result;
        }

        public int DeAssignBrickFromSuperUser(int BrickID, int EmpID)
        {
            int result = 0;
            try
            {
                daRel_Bricks_Users da = new daRel_Bricks_Users();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.DeleteAdminRelations(BrickID, EmpID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestDeleteAdminRelations(BrickID, EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch (Exception ex) { }

            return result;
        }

        public int DeAssignAllBrickFromSuperUser(int EmpID)
        {
            int result = 0;
            try
            {
                daRel_Bricks_Users da = new daRel_Bricks_Users();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.DeleteAllAdminRelations(EmpID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse("0") > 0 ? 2 : 0;
                }
            }
            catch (Exception ex) { }

            return result;
        }

        public int DeAssignAllBricksFromUser(int EmpID)
        {
            int result = 0;
            try
            {
                daRel_Bricks_Users da = new daRel_Bricks_Users();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.DeleteUserRelations(EmpID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Update record in database
                    result = int.Parse(da.RequestDeleteUserRelations(EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch (Exception ex) { }

            return result;
        }

        public bool DeleteUserBrickRelations(int BrickID)
        {
            daRel_Bricks_Users da = new daRel_Bricks_Users();
            return (int)da.DeleteBrickRelations(BrickID) > 0;
        }

        public bool DeleteUserBrick(int BrickID)
        {
            daBricks da = new daBricks();
            return (int)da.Delete(BrickID) > 0;
        }

        public static bool IsEmpHasRels(int EmpID)
        {
            daEmployees da = new daEmployees();
            bool Result = (Convert.ToInt32(da.IsEmployeeHasRels(EmpID, false)) > 0);
            da.Dispose();
            return Result;
        }

        public bool IsRelBrickUserExist(int BrickID, int EmpID)
        {
            daRel_Bricks_Users da = new daRel_Bricks_Users();
            return (int)da.IsRelBricksUsersExist(BrickID, EmpID) > 0;
        }

        public bool IsBrickHasRelations(int BrickID)
        {
            daRel_Bricks_Users da = new daRel_Bricks_Users();
            return (int)da.IsBrickHasRelations(BrickID) > 0;
        }

        public bool IsUpdatedBrickExist(int BrickID, string BrickName)
        {
            daBricks da = new daBricks();
            return (int)da.IsUpdatedBrickExistByName(BrickID, BrickName) > 0;
        }

        public bool UpdateUserBrick(int BrickID, string BrickName)
        {
            daBricks da = new daBricks();
            return (int)da.Update(BrickID, BrickName) > 0;
        }

        public int AddUser(string UserName, string EmpName, int TitleID, bool Active, decimal NID, string Address, string Mobile, string Email, string HomeTel, string Comment, string MembershipAndRolesInfo, out int NewID)
        {
            int result = 0;
            NewID = 0;
            try
            {
                if (IsNIDExist(NID))
                    return -1;
                if (IsEmpNameExist(EmpName, UserName))
                    return 0;
                daEmployees da = new daEmployees();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(UserName, EmpName, EmpName.ToLower(), TitleID, Active, NID, Address, Mobile, Email, HomeTel, Comment).ToString());
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
                    result = int.Parse(da.RequestInsert(UserName, EmpName, EmpName.ToLower(), TitleID, Active, NID, Address, Mobile, Email, HomeTel, Comment, MembershipAndRolesInfo, CurrentUserInfo.EmpID).ToString());
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
        public static int ResponseAddUser(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daEmployees da = new daEmployees();
                string MembershipAndRolesInfo = "";
                int Result = int.Parse(da.ResponseInsert(TransID, TransStatus, EmpID, ref MembershipAndRolesInfo).ToString());
                if (Result == 1)
                {
                    MembershipAndRolesInfo = MembershipAndRolesInfo.Remove(0, 14); // Removiong 'BMD-Employees '
                    string[] Infos = MembershipAndRolesInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    
                    for (int i = 0; i < Infos.Length; i++)
                    {
                        switch (Infos[i])
                        {
                            case "0":
                                Roles.CreateRole(Infos[++i]);
                                break;
                            case "1":
                                Roles.AddUserToRole(Infos[++i], Infos[++i]);
                                break;
                            case "2":
                                Roles.RemoveUserFromRole(Infos[++i], Infos[++i]);
                                break;
                            case "3":
                                Roles.DeleteRole(Infos[++i]);
                                break;
                            case "4":
                                Membership.GetUser(Infos[++i]).ChangePassword(Infos[++i], Infos[++i]);
                                break;
                            case "5":
                                MembershipUser memb = Membership.GetUser(Infos[++i]);
                                memb.ChangePassword(memb.GetPassword(), "123456");
                                break;
                            case "6":
                                Membership.CreateUser(Infos[++i], Infos[++i]);
                                break;
                            case "7":
                                Membership.DeleteUser(Infos[++i]);
                                break;
                            default:
                                return 3;
                                break;
                        }
                    }
                }

                return Result;
            }
            catch
            {
                return 3;
            }
        }

        public int UpdateUser(int EmpID, string UserName, string EmpName, int TitleID, bool Active, decimal NID, string Address, string Mobile, string Email, string HomeTel, string Comment, string MembershipAndRolesInfo, out string Msg)
        {
            Msg = "";
            int result = 0;
            try
            {
                if (IsUpdatedNIDExist(EmpID, NID))
                {
                    Msg = "Failed to perform this operation... National ID already exists in the database !";
                    return 0;
                }
                if (IsUpdatedEmpNameExist(EmpID, EmpName))
                {
                    Msg = "Failed to perform this operation... User Name already exists in the database !";
                    return 0;
                }
                daEmployees da = new daEmployees();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin or SuperVisor // Direct Insert in database
                    result = int.Parse(da.Update(EmpID, EmpName, EmpName.ToLower(), TitleID, Active, NID, Address, Mobile, Email, HomeTel, Comment).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    dsTransactionLogTableAdapters.daTransactionslog daT = new dsTransactionLogTableAdapters.daTransactionslog();
                    int Existance = Convert.ToInt32(daT.IsUpdatedTransactionExist(EmpID, "BMD_Employees%"));
                    da.Dispose();
                    if (Existance == 0)
                        // Request to Update Product in database
                        result = int.Parse(da.RequestUpdate(EmpID, UserName, EmpName, EmpName.ToLower(), TitleID, Active, NID, Address, Mobile, Email, HomeTel, Comment, MembershipAndRolesInfo, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                    else
                        Msg = msgErrMoreUpdateRequest;
                }
            }
            catch (Exception Exp) { Msg = Exp.Message; }

            return result;
        }
        public static int ResponseUpdateUser(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daEmployees da = new daEmployees();
                string MembershipAndRolesInfo = "";
                int Result = int.Parse(da.ResponseUpdate(TransID, TransStatus, EmpID, ref MembershipAndRolesInfo).ToString());
                if (Result == 1)
                {
                    MembershipAndRolesInfo = MembershipAndRolesInfo.Remove(0, 14); // Removiong 'BMD-Employees '
                    string[] Infos = MembershipAndRolesInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < Infos.Length; i++)
                    {
                        switch (Infos[i])
                        {
                            case "0":
                                Roles.CreateRole(Infos[++i]);
                                break;
                            case "1":
                                Roles.AddUserToRole(Infos[++i], Infos[++i]);
                                break;
                            case "2":
                                Roles.RemoveUserFromRole(Infos[++i], Infos[++i]);
                                break;
                            case "3":
                                Roles.DeleteRole(Infos[++i]);
                                break;
                            case "4":
                                Membership.GetUser(Infos[++i]).ChangePassword(Infos[++i], Infos[++i]);
                                break;
                            case "5":
                                MembershipUser memb = Membership.GetUser(Infos[++i]);
                                memb.ChangePassword(memb.GetPassword(), "123456");
                                break;
                            case "6":
                                Membership.CreateUser(Infos[++i], Infos[++i]);
                                break;
                            case "7":
                                Membership.DeleteUser(Infos[++i]);
                                break;
                            default:
                                return 3;
                                break;
                        }
                    }
                }

                return Result;
            }
            catch
            {
                return 3;
            }
        }

        public int DeleteUser(int EmpID, string MembershipAndRolesInfo)
        {
            int result = 0;
            try
            {
                daEmployees da = new daEmployees();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin or SuperVisor// Direct Insert in database
                    result = int.Parse(da.Delete(EmpID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Add new Product in database
                    result = int.Parse(da.RequestDelete(EmpID, MembershipAndRolesInfo, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }
        public static int ResponseDelete(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daEmployees da = new daEmployees();
                string MembershipAndRolesInfo = "";
                int Result = int.Parse(da.ResponseDelete(TransID, TransStatus, EmpID, ref MembershipAndRolesInfo).ToString());
                if (Result == 1)
                {
                    MembershipAndRolesInfo = MembershipAndRolesInfo.Remove(0, 14); // Removiong 'BMD-Employees '
                    string[] Infos = MembershipAndRolesInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < Infos.Length; i++)
                    {
                        switch (Infos[i])
                        {
                            case "0":
                                Roles.CreateRole(Infos[++i]);
                                break;
                            case "1":
                                Roles.AddUserToRole(Infos[++i], Infos[++i]);
                                break;
                            case "2":
                                Roles.RemoveUserFromRole(Infos[++i], Infos[++i]);
                                break;
                            case "3":
                                Roles.DeleteRole(Infos[++i]);
                                break;
                            case "4":
                                Membership.GetUser(Infos[++i]).ChangePassword(Infos[++i], Infos[++i]);
                                break;
                            case "5":
                                MembershipUser memb = Membership.GetUser(Infos[++i]);
                                memb.ChangePassword(memb.GetPassword(), "123456");
                                break;
                            case "6":
                                Membership.CreateUser(Infos[++i], Infos[++i]);
                                break;
                            case "7":
                                Membership.DeleteUser(Infos[++i]);
                                break;
                            default:
                                return 3;
                                break;
                        }
                    }
                }

                return Result;
            }
            catch
            {
                return 3;
            }
        }

        public bool IsEmpNameExist(string EmpName , string UserName)
        {
            daEmployees da = new daEmployees();
            return da.IsEmployeeExist(EmpName.ToLower(), UserName.ToLower()) != null;
        }

        public static bool IsValidEmployee(string Username)
        {
            daEmployees da = new daEmployees();
            return da.IsEmployeeExistByUserName(Username) != null;
        }

        public bool IsUpdatedEmpNameExist(int EmpID, string EmpName)
        {
            daEmployees da = new daEmployees();
            return da.IsUpdatedEmployeeExist(EmpID, EmpName.ToLower()) != null;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsEmployees.dtFilteredEmployeesDataTable SelectFilteredEmployees(string empName, int empID, decimal NationalID, int titleID, int brickID)
        {
            daFilteredEmployees da = new daFilteredEmployees();
            string AdminName = CurrentUserInfo.UserRole == UsersRoles.SuperUser ? CurrentUserInfo.UserName : "";
            string UserName = CurrentUserInfo.UserRole == UsersRoles.User ? CurrentUserInfo.UserName : "";
            return da.GetFilteredUsers(empName, empID, NationalID, titleID, brickID, AdminName, UserName, false);
        }
    }
}