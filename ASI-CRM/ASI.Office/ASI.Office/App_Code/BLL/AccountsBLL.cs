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
using System.Collections;

namespace Office.BLL
{
    [System.ComponentModel.DataObject]
    public class AccountsBLL : MasterClass
    {
        public struct Filter
        {
            public string IncrementalSearch;
            public string IncrementalSearchValue;
            public string Tag;
            public string BusSector;
            public string Notes;
            public string LocationType;
            public string LocationName;
            public int? StatusID;
        }

        public AccountsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<ContactAccount> SelectAccounts(ContactAccount CurrentAccount)
        {
            ContactAccount CAcc = new ContactAccount();
            if (CurrentAccount != null)
                CAcc = CurrentAccount;
            return CAcc.GetAccounts();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
        public void UpdateAccountGridTags(ArrayList CheckedTags, ArrayList UnCheckedTags)
        {
            for (int i = 0; i < CheckedTags.Count; i++)
            {
                ContactAccount CntAcc = new ContactAccount();
                int AccountID = int.Parse(CheckedTags[i].ToString());
                CntAcc.AccountID = AccountID;
                CntAcc.Tag = true;
                CntAcc.EditByID = ((ASIIdentity)User.Identity).UserID;
                CntAcc.EditDate = DateTime.Now;
                CntAcc.UpdateContactAccount();
            }

            for (int i = 0; i < UnCheckedTags.Count; i++)
            {
                ContactAccount CntAcc = new ContactAccount();
                int AccountID = int.Parse(UnCheckedTags[i].ToString());
                CntAcc.AccountID = AccountID;
                CntAcc.Tag = false;
                CntAcc.EditByID = ((ASIIdentity)User.Identity).UserID;
                CntAcc.EditDate = DateTime.Now;
                CntAcc.UpdateContactAccount();
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public ContactAccount GetSearchFilter(string Sortby, 
                                            string sortDirection, 
                                            string TagFilter, 
                                            string SpecificFilter, 
                                            Filter Fltr, 
                                            string LocationFilter, 
                                            string SpecificLocation, 
                                            int FilterAccountNotes) 
        {
            ContactAccount CntAcc = new ContactAccount();
            switch (Sortby)
            {
                case "AccountName":
                    CntAcc.SortExpression = ContactAccount.SortBy.CompanyName;
                    break;

                case "City":
                    CntAcc.SortExpression = ContactAccount.SortBy.City;
                    break;

                case "State":
                    CntAcc.SortExpression = ContactAccount.SortBy.State;
                    break;

                case "BusinessSectorName":
                    CntAcc.SortExpression = ContactAccount.SortBy.BusinessSectorName;
                    break;
                    
                case "Tag":
                    CntAcc.SortExpression = ContactAccount.SortBy.Tag;
                    break;
               
                case "LastAccountNoteDate":
                    CntAcc.SortExpression = ContactAccount.SortBy.LastAccountNoteDate;
                    break;

                case "StatusName":
                    CntAcc.SortExpression = ContactAccount.SortBy.StatusName;
                    break;

                case "CountryName":
                    CntAcc.SortExpression = ContactAccount.SortBy.CountryName;
                    break;
            }

            switch (sortDirection)
            {
                case "ASC":
                    CntAcc.SortDirect = SortDirection.Ascending;
                    break;

                case "Desc":
                    CntAcc.SortDirect = SortDirection.Descending;
                    break;
            }

            switch (TagFilter)
            {
                case "Tagged":
                    CntAcc.Tag = true; 
                    break;

                case "Un-Tagged":
                    CntAcc.Tag = false;
                    break;

                case "All":
                    CntAcc.Tag = null;
                    break;
            }

            switch (Fltr.IncrementalSearch)
            {
                   
                case "Company":
                    CntAcc.AccountName = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    break;

                case "Business Sector":
                    CntAcc.BusinessSectorName = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    if (Fltr.IncrementalSearchValue != "")
                        Fltr.BusSector = Fltr.IncrementalSearchValue;
                    break;
                case "Telephone":
                    CntAcc.Phone = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    break;
                case "Fax":
                    CntAcc.Fax = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    break;
                case "Email":
                    CntAcc.Email = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    break;
                case "Website":
                    CntAcc.WebSite = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    break;
                case "Company No":
                    try
                    {
                        CntAcc.AccountID = (Fltr.IncrementalSearchValue != "") ? Convert.ToInt32(Fltr.IncrementalSearchValue) : 0;
                    }
                    catch (Exception ex)
                    {
                        CntAcc.AccountID = 0;
                    }
                    break;
                    
            }
            
            CntAcc.IDStatus = (Fltr.StatusID != -1) ? Fltr.StatusID : null;
            CntAcc.BusinessSectorName = (Fltr.BusSector != "-1") ? Fltr.BusSector : null;

            if (SpecificLocation != "")
            {
                switch (LocationFilter)
                {
                    case "Country":
                        CntAcc.CountryName = SpecificLocation;
                        break;

                    case "State":
                        CntAcc.State = SpecificLocation;
                        break;
                }
            }
            // Added By Fawzi
            CntAcc.FilterAccountNotes = FilterAccountNotes;
            //
            return CntAcc;
        
        }

        public ArrayList GetCountryList()
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = "Country";
            List<MainSubCode> MSCodeLst = GetList.GetSCodeList();
            ArrayList CountryLst = new ArrayList();
            foreach (MainSubCode MSCode in MSCodeLst)
                CountryLst.Add(MSCode.SubCode);
            return CountryLst;
        }

        public ArrayList GetBusSectorList()
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = "BusinessSector";
            List<MainSubCode> MSCodeLst = GetList.GetSCodeList();
            ArrayList BusSectorLst = new ArrayList();
            foreach (MainSubCode MSCode in MSCodeLst)
                BusSectorLst.Add(MSCode.SubCode);
            return BusSectorLst;
        }

        public DataTable GetBusSectors()
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = "BusinessSector";
            List<MainSubCode> MSCodeLst = GetList.GetSCodeList();
            DataTable dt = new DataTable();
            dt.Columns.Add("BusSector", typeof(int));
            dt.Columns.Add("BusSectorName", typeof(string));
            foreach (MainSubCode MSCode in MSCodeLst)
            {
                dt.Rows.Add(MSCode.SubID, MSCode.SubCode);
            }
            dt.Rows.Add(null, "");

            return dt;
        }

        public ArrayList GetStateList()
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = "state";
            List<MainSubCode> MSCodeLst = GetList.GetSCodeList();
            ArrayList StateLst = new ArrayList();
            foreach (MainSubCode MSCode in MSCodeLst)
                StateLst.Add(MSCode.SubCode);
            return StateLst;
        }

        public DataTable GetStatus()
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = "Status";
            List<MainSubCode> MSCodeLst = GetList.GetSCodeList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Status", typeof(int));
            dt.Columns.Add("StatusName", typeof(string));
            foreach (MainSubCode MSCode in MSCodeLst)
            {
                dt.Rows.Add(MSCode.SubID, MSCode.SubCode);
            }
            dt.Rows.Add(null, "");

            return dt;
        }

        public DataTable GetCountries()
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = "Country";
            List<MainSubCode> MSCodeLst = GetList.GetSCodeList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Country", typeof(int));
            dt.Columns.Add("CountryName", typeof(string));
            foreach (MainSubCode MSCode in MSCodeLst)
            {
                dt.Rows.Add(MSCode.SubID, MSCode.SubCode);
            }
            dt.Rows.Add(null, "");

            return dt;
        }

        public DataTable GetStates()
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = "State";
            List<MainSubCode> MSCodeLst = GetList.GetSCodeList();
            DataTable dt = new DataTable();
            dt.Columns.Add("State", typeof(int));
            dt.Columns.Add("StateName", typeof(string));
            foreach (MainSubCode MSCode in MSCodeLst)
            {
                dt.Rows.Add(MSCode.SubID, MSCode.SubCode);
            }
            dt.Rows.Add(null, "");

            return dt;
        }

        public List<MainSubCode> GetFilterdStatusList()
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = "Status";
            List<MainSubCode> MSCodeLst = GetList.GetSCodeList();
            List<MainSubCode> StatusLst = new List<MainSubCode>();

            foreach (MainSubCode MSCode in MSCodeLst)
            {
                if (MSCode.SubCode.ToLower() == "active" || MSCode.SubCode.ToLower() == "development" || MSCode.SubCode.ToLower() == "out of business" || MSCode.SubCode.ToLower() == "not interested")
                {
                    StatusLst.Add(MSCode);
                }
            }
            return StatusLst;
        }
        
        public int GetAccountsCount()
        {
            return ContactAccount.GetAccountsCount();
        }


        public int GetAccountsPagesNums(int PageSize)
        {
            return ContactAccount.GetAccountsPages(PageSize);
        }
        public int GetAccountGridPageNo(int AccountID, int GridPageSize)
        {
            ContactAccount CA = new ContactAccount();
            CA.AccountID = AccountID;
            int PageNo = CA.GetAccountPage(GridPageSize);

            return (PageNo == -1) ? 0 : PageNo; 
        }
    }
}