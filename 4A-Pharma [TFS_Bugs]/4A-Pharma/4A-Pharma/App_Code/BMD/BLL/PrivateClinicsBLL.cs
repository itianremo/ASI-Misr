using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using dsPrivateClinicsTableAdapters;

namespace Pharma.BMD.BLL
{

    [System.ComponentModel.DataObject]
    public class PrivateClinicsBLL : MasterClass
    {
        int? RowsCount;
        public PrivateClinicsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsPrivateClinics.dtPrivateClinicsDataTable SelectPrivateClinics(int startRowIndex, int maximumRows, bool ShowAll)
        {
            daPrivateClinics da = new daPrivateClinics();
            dsPrivateClinics.dtPrivateClinicsDataTable dt;
            RowsCount = 0;
            if (!CurrentUserInfo.IsUserRank)
            {
                
                dt =  da.GetData(ShowAll, startRowIndex, ref RowsCount);
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // SuperUser 
                    dt = da.GetPrivateClinicsByAdmin(CurrentUserInfo.UserName, ShowAll, startRowIndex, ref RowsCount);
                }
                else
                {
                    // Normal User
                    dt = da.GetPrivateClinicsByUser(CurrentUserInfo.UserName, ShowAll, startRowIndex, ref RowsCount);
                }
            }
            da.Dispose();
            return dt;

        }

        public int GetCertainPageByID(int PrivateClinicID, bool ShowAll)
        {
            daPrivateClinics da = new daPrivateClinics();
            int PageNo;
            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                PageNo = Convert.ToInt32(da.GetCertainPrivateClinicPage(ShowAll, PrivateClinicID, "-1"));
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    PageNo = Convert.ToInt32(da.GetCertainPrivateClinicPageByAdmin(CurrentUserInfo.UserName, ShowAll, PrivateClinicID, "-1"));
                }
                else
                {
                    // Normal User
                    PageNo = Convert.ToInt32(da.GetCertainPrivateClinicPageByUser(CurrentUserInfo.UserName, ShowAll, PrivateClinicID, "-1"));
                }
            }
            da.Dispose();
            return PageNo;
        }

        public int GetCertainPageByName(string PrivateClinicName, bool ShowAll)
        {
            daPrivateClinics da = new daPrivateClinics();
            int PageNo;
            if (!CurrentUserInfo.IsUserRank)
            {
                // SuperAdmin
                PageNo = Convert.ToInt32(da.GetCertainPrivateClinicPage(ShowAll, -1, PrivateClinicName));
            }
            else
            {
                if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
                {
                    // Admin
                    PageNo = Convert.ToInt32(da.GetCertainPrivateClinicPageByAdmin(CurrentUserInfo.UserName, ShowAll, -1, PrivateClinicName));
                }
                else
                {
                    // Normal User
                    PageNo = Convert.ToInt32(da.GetCertainPrivateClinicPageByUser(CurrentUserInfo.UserName, ShowAll, -1, PrivateClinicName));
                }
            }
            da.Dispose();
            return PageNo;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int MaxRowCount(int startRowIndex, int maximumRows, bool ShowAll)
        {
            //daPrivateClinics da = new daPrivateClinics();
            //int Count = Convert.ToInt32(da.GetPrivateClinicsCount(ShowAll));
            //return Count;
            //return RowsCount.Value;
            int result = 0;
            if (RowsCount != null)
                result = RowsCount.Value;
            return result;

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsPrivateClinics.dtFilteredPrivateClinicsDataTable SelectFilteredPrivateClinics(string privateClinicName, string PhysicianName, int GovID, int CityID, int BrickID)
        {
            //RefreshCurrentUserInfo();
            daFilteredPrivateClinics da = new daFilteredPrivateClinics();
            string AdminName = CurrentUserInfo.UserRole == UsersRoles.SuperUser ? CurrentUserInfo.UserName : "";
            string UserName = CurrentUserInfo.UserRole == UsersRoles.User ? CurrentUserInfo.UserName : "";
            dsPrivateClinics.dtFilteredPrivateClinicsDataTable dt = da.GetFilteredPrivateClinics(privateClinicName, PhysicianName, GovID, CityID, BrickID, AdminName, UserName, false);
            da.Dispose();
            return dt;
        }

        public bool IsPrivateClinicNameExist(string PrivateClinicName)
        {
            daPrivateClinics da = new daPrivateClinics();
            return int.Parse(da.IsPrivateClinicExistByName(PrivateClinicName).ToString()) > 0;
        }

        public bool IsUpdatedPrivateClinicNameExist(int PrivateClinicID, string PrivateClinicName)
        {
            daPrivateClinics da = new daPrivateClinics();
            int Existance = Convert.ToInt32(da.IsUpdatedPrivateClinicExistByName(PrivateClinicID, PrivateClinicName));
            da.Dispose();
            return Existance > 0;
        }

        public int AddPrivateClinic(string PrivateClinicName, int PhysicianID, int BrickID, int GovID, int CityID, string Area, string Address, string Phone1, string Phone2, string Mobile, string PostalCode, string Email, string Comment, out int NewID)
        {
            int result = 0;
            NewID = 0;
            try
            {
                daPrivateClinics da = new daPrivateClinics();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(PrivateClinicName, BrickID, PhysicianID, GovID, CityID, Area, Address, Phone1, Phone2, Mobile, PostalCode, Email, Comment).ToString());
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
                    result = int.Parse(da.RequestInsert(PrivateClinicName, BrickID, PhysicianID, GovID, CityID, Area, Address, Phone1, Phone2, Mobile, PostalCode, Email, Comment, CurrentUserInfo.EmpID).ToString());
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
        public static int ResponseAddPrivateClinic(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daPrivateClinics da = new daPrivateClinics();
                return int.Parse(da.ResponseInsert(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int UpdatePrivateClinic(int PrivateClinicID, string PrivateClinicName, int PhysicianID, int BrickID, int GovID, int CityID, string Area, string Address, string Phone1, string Phone2, string Mobile, string PostalCode, string Email, string Comment, out string Msg)
        {
            Msg = "";
            int result = 0;
            try
            {
                daPrivateClinics da = new daPrivateClinics();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Update in database
                    result = int.Parse(da.Update(PrivateClinicID, PrivateClinicName, BrickID, PhysicianID, GovID, CityID, Area, Address, Phone1, Phone2, Mobile, PostalCode, Email, Comment).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    dsTransactionLogTableAdapters.daTransactionslog daT = new dsTransactionLogTableAdapters.daTransactionslog();
                    int Existance = Convert.ToInt32(daT.IsUpdatedTransactionExist(PrivateClinicID, "BMD_PrivateClinics"));
                    da.Dispose();
                    if (Existance == 0)
                        // Request to Update record in database
                        result = int.Parse(da.RequestUpdate(PrivateClinicID, PrivateClinicName, BrickID, PhysicianID, GovID, CityID, Area, Address, Phone1, Phone2, Mobile, PostalCode, Email, Comment, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                    else
                        Msg = msgErrMoreUpdateRequest;
                }
            }
            catch (Exception Exp) { Msg = Exp.Message; }

            return result;
        }
        public static int ResponseUpdatePrivateClinic(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daPrivateClinics da = new daPrivateClinics();
                return int.Parse(da.ResponseUpdate(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int DeletePrivateClinic(int PrivateClinicID)
        {
            int result = 0;
            try
            {
                daPrivateClinics da = new daPrivateClinics();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin Manager // Direct Delete in database
                    result = int.Parse(da.Delete(PrivateClinicID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Delete a record in database
                    result = int.Parse(da.RequestDelete(PrivateClinicID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }
        public static int ResponseDelete(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daPrivateClinics da = new daPrivateClinics();
                return int.Parse(da.ResponseDelete(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int GetPrivateClinicIDByName(string privateClinicName)
        {
            daPrivateClinics da = new daPrivateClinics();
            int privateclinicID = 0;
            dsPrivateClinics.dtPrivateClinicsDataTable dtPrivateClinic = da.GetPrivateClinicIDByName(privateClinicName, false);
            if (dtPrivateClinic.Rows.Count != 0)
                privateclinicID = Convert.ToInt32(dtPrivateClinic.Rows[0]["PrivateClinicID"]);
            return privateclinicID;
        }

    }
}