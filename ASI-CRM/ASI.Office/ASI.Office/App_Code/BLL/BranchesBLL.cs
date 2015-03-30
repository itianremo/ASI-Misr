using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Office.DAL;
using System.Collections.Generic;

/// <summary>
/// Summary description for BranchesBLL
/// </summary>
namespace Office.BLL
{
    [System.ComponentModel.DataObject]
    public class BranchesBLL : System.Web.UI.UserControl
    {
        Office.DAL.ContactBranch Branchobj = new Office.DAL.ContactBranch();
        //private BranchesTableAdapter _branchAdapter = null;
        //protected BranchesTableAdapter Adapter
        //{
        //    get
        //    {
        //        if (_branchAdapter == null)
        //        {
        //            _branchAdapter = new BranchesTableAdapter();

        //        }
        //        return _branchAdapter;
        //    }
        //}

        //private Contact_BranchesTableAdapter _ContactBranchadapter = null;
        //protected Contact_BranchesTableAdapter ContactBranchAdapter
        //{
        //    get
        //    {
        //        if (_ContactBranchadapter == null)
        //        {
        //            _ContactBranchadapter = new Contact_BranchesTableAdapter();

        //        }
        //        return _ContactBranchadapter;
        //    }
        //}



        public BranchesBLL()
        {

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<Branches> GetBranches()
        {
            //return Adapter.GetBrnachesData();
            Branches Br = new Branches();
            return Br.GetBranchesData();
        }


        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public Branches GetBranchByID(int BranchID)
        {
            Branches Br = new Branches();
            Br.BranchID = BranchID;
            return Br.GetSingleBranch();
        }


        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<Branches> GetBranchByAccountID(int AccountID)
        {
            Branches Br = new Branches();
            Br.AccountID = AccountID;
            return Br.GetBranchByAccID();
        }


        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public int AddBranch(string BranchName, int? TypeID, int? BusSector, string Fax,
            string phone, string website, int? IDStatus, string Street1, string City, string ZipCode,
            int? CountryID, string ReferedBy, int EnterByID, DateTime EnterDate,
            string Street2, int? BranchManagerID, DateTime BranchManagerEditDate, int? BranchManagerEditByID,
            DateTime BranchManagerAssignedDate,
            string State, int AccountID, bool MainOffice)
        {
            //DSBranches.BranchesDataTable Branches = new DSBranches.BranchesDataTable();
            //DSBranches.BranchesRow Branch = Branches.NewBranchesRow();

            //Branch.BrnachName = BranchName;
            //if (TypeID == null) Branch.SetTypeIDNull();
            //else Branch.TypeID = TypeID.Value;
            //if (BusSector == null) Branch.SetBusSectorNull();
            //else Branch.BusSector = BusSector.Value;
            //if (Fax == null) Branch.SetFaxNull();
            //else Branch.Fax = Fax;
            //if (phone == null) Branch.SetPhoneNull();
            //else Branch.Phone = phone;
            //if (website == null) Branch.SetWebSiteNull();
            //else Branch.WebSite = website;
            //if (IDStatus == null) Branch.SetIDStatusNull();
            //else Branch.IDStatus = IDStatus.Value;
            //if (Street1 == null) Branch.SetStreet1Null();
            //else Branch.Street1 = Street1;
            //if (City == null) Branch.SetCityNull();
            //else Branch.City = City;
            //if (ZipCode == null) Branch.SetZipCodeNull();
            //else Branch.ZipCode = ZipCode;
            //if (CountryID == null) Branch.SetCountryIDNull();
            //else Branch.CountryID = CountryID.Value;
            //if (ReferedBy == null) Branch.SetReferedByNull();
            //else Branch.ReferedBy = ReferedBy;
            //if (EnterByID == null) Branch.SetEnterByIDNull();
            //else Branch.EnterByID = EnterByID;
            //if (EnterDate == null) Branch.EnterDate = System.DateTime.Now;
            //else Branch.EnterDate = EnterDate;
            //if (Street2 == null) Branch.SetStreet2Null();
            //else Branch.Street2 = Street2;
            //if (BranchManagerID == null) Branch.SetBranchManagerIDNull();
            //else Branch.BranchManagerID = BranchManagerID.Value;
            //if (BranchManagerEditDate == null) Branch.BranchManagerEditDate = System.DateTime.Now;
            //else Branch.BranchManagerEditDate = BranchManagerEditDate;
            //if (BranchManagerAssignedDate == null) Branch.BranchManagerAssignedDate = System.DateTime.Now;
            //else Branch.BranchManagerAssignedDate = BranchManagerAssignedDate;
            //if (State == null) Branch.SetStateNull();
            //else Branch.State = State;
            //Branch.AccountID = AccountID;
            //Branch.MainOffice=MainOffice;


            //// Add the new branch
            //Branches.AddBranchesRow(Branch);
            //int result = Adapter.Update(Branches);


            //return result ;

            Branches Branch = new Branches();
            Branch.BranchName = BranchName;
            Branch.TypeID = TypeID;
            Branch.BussinessSectorID = BusSector;
            Branch.Fax = Fax;
            Branch.Phone = phone;
            Branch.WebSite = website;
            Branch.IDStatus = IDStatus;
            Branch.Street1 = Street1;
            Branch.City = City;
            Branch.ZipCode = ZipCode;
            Branch.CountryID = CountryID;
            Branch.ReferedBy = ReferedBy;
            Branch.EnterByID = EnterByID;
            Branch.EnterDate = EnterDate;
            Branch.Street2 = Street2;
            Branch.BranchManagerID = BranchManagerID;
            Branch.BranchManagerEditDate = BranchManagerEditDate;
            Branch.BranchManagerAssignedDate = BranchManagerAssignedDate;
            Branch.State = State;
            Branch.AccountID = AccountID;
            Branch.MainOffice = MainOffice;

            return Branch.AddNewBranch();
        }


        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public int updateBranch(int BranchID, string BranchName, int? TypeID, int? BusSector, string Fax,
            string phone, string website, int? IDStatus, string Street1, string City, string ZipCode,
            int? CountryID, string ReferedBy, int EditByID, DateTime EditDate,
            string Street2, int? BranchManagerID, DateTime BranchManagerEditDate, int? BranchManagerEditByID,
            DateTime BranchManagerAssignedDate,
            string State, int AccountID, bool MainOffice)
        {
            //DSBranches.BranchesDataTable Branches = Adapter.GetBranchesDetailsByID(BranchID);
            //if (Branches.Count==0)
            //{
            //    return 1;  
            //}

            //DSBranches.BranchesRow Branch = Branches[0];
            //Branch.BrnachName = BranchName;
            //if (TypeID == null) Branch.SetTypeIDNull();
            //else Branch.TypeID = TypeID.Value;
            //if (BusSector == null) Branch.SetBusSectorNull();
            //else Branch.BusSector = BusSector.Value;
            //if (Fax == null) Branch.SetFaxNull();
            //else Branch.Fax = Fax;
            //if (phone == null) Branch.SetPhoneNull();
            //else Branch.Phone = phone;
            //if (website == null) Branch.SetWebSiteNull();
            //else Branch.WebSite = website;
            //if (IDStatus == null) Branch.SetIDStatusNull();
            //else Branch.IDStatus = IDStatus.Value;
            //if (Street1 == null) Branch.SetStreet1Null();
            //else Branch.Street1 = Street1;
            //if (City == null) Branch.SetCityNull();
            //else Branch.City = City;
            //if (ZipCode == null) Branch.SetZipCodeNull();
            //else Branch.ZipCode = ZipCode;
            //if (CountryID == null) Branch.SetCountryIDNull();
            //else Branch.CountryID = CountryID.Value;
            //if (ReferedBy == null) Branch.SetReferedByNull();
            //else Branch.ReferedBy = ReferedBy;
            //if (EditByID == null) Branch.SetEditByIDNull();
            //else Branch.EditByID = EditByID;
            //if (EditDate == null) Branch.EditDate = System.DateTime.Now;
            //else Branch.EditDate = EditDate;
            //if (Street2 == null) Branch.SetStreet2Null();
            //else Branch.Street2 = Street2;
            //if (BranchManagerID == null) Branch.SetBranchManagerIDNull();
            //else Branch.BranchManagerID = BranchManagerID.Value;
            //if (BranchManagerEditDate == null) Branch.BranchManagerEditDate = System.DateTime.Now;
            //else Branch.BranchManagerEditDate = BranchManagerEditDate;
            //if (BranchManagerAssignedDate == null) Branch.BranchManagerAssignedDate = System.DateTime.Now;
            //else Branch.BranchManagerAssignedDate = BranchManagerAssignedDate;
            //if (State == null) Branch.SetStateNull();
            //else Branch.State = State;
            //Branch.AccountID = AccountID;
            //Branch.MainOffice = MainOffice;


            //// Update 
            //int result = Adapter.Update(Branch);
            //return result;

            Branches Branch = new Branches();
            Branch.BranchID = BranchID;
            Branch.BranchName = BranchName;
            Branch.TypeID = TypeID;
            Branch.BussinessSectorID = BusSector;
            Branch.Fax = Fax;
            Branch.Phone = phone;
            Branch.WebSite = website;
            Branch.IDStatus = IDStatus;
            Branch.Street1 = Street1;
            Branch.City = City;
            Branch.ZipCode = ZipCode;
            Branch.CountryID = CountryID;
            Branch.ReferedBy = ReferedBy;
            Branch.EnterByID = EditByID;
            Branch.EnterDate = EditDate;
            Branch.Street2 = Street2;
            Branch.BranchManagerID = BranchManagerID;
            Branch.BranchManagerEditDate = BranchManagerEditDate;
            Branch.BranchManagerAssignedDate = BranchManagerAssignedDate;
            Branch.State = State;
            Branch.AccountID = AccountID;
            Branch.MainOffice = MainOffice;

            return Branch.UpdateBranch();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<Branches> GetBranches(int AccountID)
        {
            Branches Br = new Branches();
            Br.AccountID = AccountID;
            return Br.GetBranchByAccID();
        }

        public bool CheckMainContact(string ContactID, string BranchID)
        {

            if (ContactID == null || BranchID == null || ContactID == "*" || ContactID == "" || BranchID == "" || BranchID == "-----")
            {
                return false;

            }
            else
            {
                return Branchobj.checkMainContact(int.Parse(ContactID), int.Parse(BranchID));
            }
        }

        public void SetMainContact(int ContactID, int BranchID, bool checkvalue)
        {
            int Check = 0;
            if (checkvalue == true)
            {
                Check = 1;
            }
            Branchobj.SetMainContact(ContactID, BranchID, Check);

        }

        public string GetContactBranchID(string ContactID, string AccountID)
        {
            //string Result = "";
            if (ContactID == null || AccountID == null || ContactID == "*" || ContactID == "" || AccountID == "" || AccountID == "-----")
            {

                return "";

            }
            return Branchobj.GetContactBranchID(ContactID, AccountID);



        }

        public string DeleteBranchByID(int BranchID)
        {
            Branches CBnch = new Branches();
            CBnch.BranchID = BranchID;

            string ResultMsg = CBnch.DeleteBranch();

            if (ResultMsg.Equals("1"))
                ResultMsg = "Branch deleted successfully!";
            else
            {
                if (ResultMsg.Equals("0"))
                    ResultMsg = "Branch not found.";
                else if (ResultMsg.Equals("-1"))
                    ResultMsg = "You must delete all notes and contacts belong to this Branch.";
            }

            return ResultMsg;
        }

        public int GetBranchOrderNo(Branches Branches)
        {
            int OrderNo = Branches.GetBranchOrder();

            return (OrderNo == -1) ? 0 : OrderNo +1;
        }
    }
}
