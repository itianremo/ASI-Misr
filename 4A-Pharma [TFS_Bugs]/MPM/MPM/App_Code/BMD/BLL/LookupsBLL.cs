using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using dsBricksTableAdapters;
using dsSubCodeTableAdapters;
using dsRel_Govs_CitiesTableAdapters;

namespace Pharma.BMD.BLL
{
    [System.ComponentModel.DataObject]
    public class LookupsBLL : MasterClass
    {
        public LookupsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
            //RefreshCurrentUserInfo();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsBricks.dtBricksDataTable SelectBricks()
        {
            daBricks da = new daBricks();
            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                return da.GetData(CurrentUserInfo.UserRole == UsersRoles.SuperAdmin);
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    return da.GetDataByAdmin(CurrentUserInfo.UserName, false);
                }
                else
                {
                    // Normal User
                    return da.GetDataByUser(CurrentUserInfo.UserName, false);
                }
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, false)]
        public int InsertBrick(string BrickName, out int NewID)
        {
            int result = 0;
            NewID = 0;
            try
            {
                daBricks da = new daBricks();
                if (Convert.ToInt32(da.IsBrickExistByName(BrickName)) > 0)
                    return -1;

                //if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                //{
                    result = Convert.ToInt32(da.Insert(BrickName));
                    if (result > 0)
                    {
                        NewID = result;
                        result = 1;
                    }
                    else
                        result = 0;
                //}
                //else if (CurrentUserInfo.UserRole == UsersRoles.Admin)
                //{
                //    result = Convert.ToInt32(da.RequestInsert(BrickName, CurrentUserInfo.EmpID));
                //    if (result > 0)
                //    {
                //        NewID = result;
                //        result = 2;
                //    }
                //    else
                //        result = 0;
                //}
            }
            catch { }

            return result;
        }
        public int ResponseInsertBrick(int TransID, int TransStatus)
        {
            try
            {
                daBricks da = new daBricks();
                return int.Parse(da.ResponseInsert(TransID, TransStatus, CurrentUserInfo.EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
        public int UpdateBrick(int BrickID, string BrickName, ref string Msg)
        {            
            int result = 0;
            Msg = "";
            try
            {
                daBricks da = new daBricks();
                if (Convert.ToInt32(da.IsUpdatedBrickExistByName(BrickID, BrickName)) > 0)
                {
                    Msg = msgErrDuplicatedRecord;
                    return 0;
                }

                //if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                //{
                // SuperAdmin or Admin or SuperVisor // Direct Insert in database
                result = int.Parse(da.Update(BrickID, BrickName).ToString()) > 0 ? 1 : 0;

                da.Dispose();
                //}
                //else
                //{
                //    // Request to Update Product in database
                //    result = int.Parse(da.RequestUpdate(BrickID, BrickName, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                //}
            }
            catch { }

            return result;
        }
        public int ResponseUpdateBrick(int TransID, int TransStatus)
        {
            try
            {
                daBricks da = new daBricks();
                return int.Parse(da.ResponseUpdate(TransID, TransStatus, CurrentUserInfo.EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, false)]
        public int DeleteBrick(int BrickID)
        {
            int result = 0;
            try
            {
                daBricks da = new daBricks();
                //if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                //{
                    result = int.Parse(da.Delete(BrickID).ToString()) > 0 ? 1 : 0;
                //}
                //else
                //{
                //    result = int.Parse(da.RequestDelete(BrickID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                //}
            }
            catch { }

            return result;
        }
        public int ResponseDeleteBrick(int TransID, int TransStatus)
        {
            try
            {
                daBricks da = new daBricks();
                return int.Parse(da.ResponseDelete(TransID, TransStatus, CurrentUserInfo.EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }
        
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsSubCode.dtSubCodeDataTable GetSCodeByGCode(string GeneralCode)
        {
            daSubCode da = new daSubCode();
            
            if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
            {
                // SuperAdmin
                return da.GetSCodeByGCode(GeneralCode, true);
            }
            else
            {
                return da.GetSCodeByGCode(GeneralCode, false);
            }
        }
        public int GetSIDByGCodeAndSCode(string GeneralCode, string SubCode)
        {
            daSubCode da = new daSubCode();
            int SID = Convert.ToInt32(da.GetSIDByGeneralCodeAndSubCode(GeneralCode, SubCode, false));
            return SID;
        }
        
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, false)]
        public int AddSCodeToGCode(string GeneralCode, string SubCode, out int NewID, ref string Msg)
        {
            int result = 0;
            NewID = 0;
            Msg = "";
            try
            {
                daSubCode da = new daSubCode();
                if (Convert.ToInt32(da.IsSubCodeExistByCode(SubCode, GeneralCode)) > 0)
                {
                    Msg = msgErrDuplicatedRecord;
                    return 0;
                }

                //if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                //{
                result = Convert.ToInt32(da.InsertSCodeByGCode(SubCode, GeneralCode));
                if (result > 0)
                {
                    NewID = result;
                    result = 1;
                }
                else
                    result = 0;

                da.Dispose();
                //}
                //else if (CurrentUserInfo.UserRole == UsersRoles.Admin)
                //{
                //    result = Convert.ToInt32(da.RequestInsertByGCode(SubCode, GeneralCode, CurrentUserInfo.EmpID));
                //    if (result > 0)
                //    {
                //        NewID = result;
                //        result = 2;
                //    }
                //    else
                //        result = 0;
                //}
            }
            catch { }

            return result;
        }
        public int ResponseAddSCodeToGCode(int TransID, int TransStatus)
        {
            try
            {
                daSubCode da = new daSubCode();
                return int.Parse(da.ResponseInsertByGCode(TransID, TransStatus, CurrentUserInfo.EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int UpdateSCode(int SID, string SubCode, string GeneralCode, ref string Msg)
        {
            int result = 0;
            Msg = "";
            try
            {
                daSubCode da = new daSubCode();
                if (Convert.ToInt32(da.IsUpdatedSubCodeExistByCode(SID, SubCode, GeneralCode)) > 0)
                {
                    Msg = msgErrDuplicatedRecord;
                    return 0;
                }

                //if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                //{
                // SuperAdmin or Admin or SuperVisor // Direct Insert in database
                result = int.Parse(da.UpdateCode(SID, SubCode).ToString()) > 0 ? 1 : 0;

                da.Dispose();
                //}
                //else
                //{
                //    // Request to Update Product in database
                //    result = int.Parse(da.RequestUpdateCode(SID, SubCode, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                //}
            }
            catch { }

            return result;
        }
        public int ResponseUpdateSCode(int TransID, int TransStatus)
        {
            try
            {
                daSubCode da = new daSubCode();
                return int.Parse(da.ResponseUpdateCode(TransID, TransStatus, CurrentUserInfo.EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, false)]
        public int DeleteSCode(int SID)
        {
            int result = 0;
            try
            {
                daSubCode da = new daSubCode();
                //if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                //{
                if (Convert.ToInt32(da.IsSubCodeHasRelations(SID)) == 0)
                {
                    result = int.Parse(da.Delete(SID).ToString()) > 0 ? 1 : 0;
                }
                else
                    result = -3;
                //}
                //else
                //{
                //    result = int.Parse(da.RequestDelete(SID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                //}
                    da.Dispose();
            }
            catch { }

            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, false)]
        public int DeleteCity(int SID)
        {
            int result = 0;
            try
            {
                daSubCode da = new daSubCode();
                //if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                //{
                if (Convert.ToInt32(da.IsCityHasRelations(SID)) == 0)
                {
                    if (Convert.ToInt32(da.IsUniqueCityInGov(SID)) > 1)
                        result = int.Parse(da.Delete(SID).ToString()) > 0 ? 1 : 0;
                    else
                        result = -2;
                }
                else
                    result = -3;
                //}
                //else
                //{
                //    result = int.Parse(da.RequestDelete(SID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                //}
                da.Dispose();
            }
            catch { }

            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, false)]
        public int DeleteGov(int SID)
        {
            int result = 0;
            try
            {
                daSubCode da = new daSubCode();
                //if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                //{
                if (Convert.ToInt32(da.IsGovHasRelations(SID)) == 0)
                {
                    result = int.Parse(da.Delete(SID).ToString()) > 0 ? 1 : 0;
                    if (result == 1)
                    {
                        da.DeleteGovCities(SID);
                        da.DeleteGovCitiesRels(SID);
                    }
                }
                else
                    result = -3;
                //}
                //else
                //{
                //    result = int.Parse(da.RequestDelete(SID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                //}
                da.Dispose();
            }
            catch { }

            return result;
        }

        public int ResponseDeleteSCode(int TransID, int TransStatus)
        {
            try
            {
                daSubCode da = new daSubCode();
                return int.Parse(da.ResponseDelete(TransID, TransStatus, CurrentUserInfo.EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int AddGovRelCity(int Gov, int City)
        {
            daRel_Govs_Cities da = new daRel_Govs_Cities();
            return Convert.ToInt32(da.Insert(Gov, City));
        }
        public int AddRequestGovRelCity(int Gov, int City)
        {
            daRel_Govs_Cities da = new daRel_Govs_Cities();
            return Convert.ToInt32(da.RequestInsert(Gov, City, CurrentUserInfo.EmpID));
        }
        public int ResponseAddGovRelCity(int TransID, int TransStatus)
        {
            try
            {
                daRel_Govs_Cities da = new daRel_Govs_Cities();
                return int.Parse(da.ResponseInsert(TransID, TransStatus, CurrentUserInfo.EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int DeleteCityFromGov(int Gov, int City)
        {
            daRel_Govs_Cities da = new daRel_Govs_Cities();
            return Convert.ToInt32(da.Delete(Gov, City));
        }
        public int DeleteRequestGovRelCity(int Gov, int City)
        {
            daRel_Govs_Cities da = new daRel_Govs_Cities();
            return Convert.ToInt32(da.RequestDelete(Gov, City, CurrentUserInfo.EmpID));
        }
        public int ResponseDeleteGovRelCity(int TransID, int TransStatus)
        {
            try
            {
                daRel_Govs_Cities da = new daRel_Govs_Cities();
                return int.Parse(da.ResponseDelete(TransID, TransStatus, CurrentUserInfo.EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }
        
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public MembershipUserCollection GetAllUsers()
        {
            return Membership.GetAllUsers();
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsRel_Govs_Cities.dtRel_Govs_CitiesDataTable GetCitiesByGov(int GovID)
        {
            daRel_Govs_Cities da = new daRel_Govs_Cities();
            return da.GetCitiesByGov(GovID, false);
        }


    }
}