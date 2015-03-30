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

namespace Office.BLL
{
    [System.ComponentModel.DataObject]
    public class ContactsBLL : MasterClass
    {
        public struct Filter
        {
            public string IncrementalSearch;
            public string IncrementalSearchValue;
            public string Tag;
            public string Notes;
            public string SortCriteria;
        }

        public ContactsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<ContactContactsInfo> GetAllContacts(ContactContactsInfo CurrentContact)
        {
            ContactContactsInfo CCI= new ContactContactsInfo();
            if (CurrentContact != null)
                CCI = CurrentContact;
            return CCI.GetContacts();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public ContactContactsInfo GetSearchFilter(string Sortby, 
                                                string sortDirection, 
                                                string TagFilter, 
                                                string SpecificFilter,
                                                Filter Fltr, 
                                                int FilterContactsNotes)
        {
            ContactContactsInfo CCI = new ContactContactsInfo();
            switch (Sortby)
            {
                case "AccountName":
                    CCI.SortExpression = ContactContactsInfo.SortBy.Company;
                    break;

                case "Email":
                    CCI.SortExpression = ContactContactsInfo.SortBy.Email;
                    break;

                case "Fax":
                    CCI.SortExpression = ContactContactsInfo.SortBy.Fax;
                    break;

                case "FirstName":
                    CCI.SortExpression = ContactContactsInfo.SortBy.FirstName;
                    break;

                case "Phone":
                    CCI.SortExpression = ContactContactsInfo.SortBy.Phone;
                    break;

                case "LastName":
                    CCI.SortExpression = ContactContactsInfo.SortBy.LastName;
                    break;

                case "TitleName":
                    CCI.SortExpression = ContactContactsInfo.SortBy.TitleName;
                    break;
                case "Tag":
                    CCI.SortExpression = ContactContactsInfo.SortBy.Tag;
                    break;
                case "LastContactNoteDate":
                    CCI.SortExpression = ContactContactsInfo.SortBy.LastContactNoteDate;
                    break;
            }

            switch (sortDirection)
            {
                case "ASC":
                    CCI.SortDirect = SortDirection.Ascending;
                    break;

                case "Desc":
                    CCI.SortDirect = SortDirection.Descending;
                    break;
            }

            switch (TagFilter)
            {
                case "Tagged":
                    CCI.Tag = true;
                    break;

                case "Un-Tagged":
                    CCI.Tag = false;
                    break;

                case "All":
                    CCI.Tag = null;
                    break;
            }
            switch (Fltr.IncrementalSearch)
            {
                case "Company":
                    CCI.AccountName = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    CCI.SearchList = ContactContactsInfo.SearchBy.AName;
                    break;

                case "Email":
                    CCI.Email = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    CCI.SearchList = ContactContactsInfo.SearchBy.Email;
                    break;

                case "Fax":
                    CCI.Fax = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    CCI.SearchList = ContactContactsInfo.SearchBy.Fax;
                    break;

                case "Contact First Name":
                    CCI.FirstName = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    CCI.SearchList = ContactContactsInfo.SearchBy.FirstName;
                    break;

                case "Contact Last Name":
                    CCI.LastName = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    CCI.SearchList = ContactContactsInfo.SearchBy.LastName;
                    break;

                case "Telephone":
                    CCI.Phone = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    CCI.SearchList = ContactContactsInfo.SearchBy.Phone;
                    break;

                case "ID/Status":
                    CCI.IDStatus = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    CCI.SearchList = ContactContactsInfo.SearchBy.IDStatus;
                    break;
            }
            // Added By Fawzi
            CCI.FilterContactsNotes = FilterContactsNotes;
            //
            return CCI;

        }

        
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
        public void UpdateContactGridTags(GridView GridViewName)
        {
            foreach (GridViewRow gvrow in GridViewName.Rows)
                               {
                if (gvrow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkboxTag = (CheckBox)gvrow.FindControl("CbEmail");
                    
                    ContactContactsInfo CCI = new ContactContactsInfo();
                    CCI.ContactID = int.Parse(GridViewName.DataKeys[gvrow.RowIndex].Values["ContactID"].ToString());
                     CCI.Tag = chkboxTag.Checked;
                    CCI.EditByID = ((ASIIdentity)User.Identity).UserID;
                    CCI.EditDate = DateTime.Now;
                    // the following lines added by Sayed for testing only

                  int result=  CCI.UpdateContactContactsInfo();
                    if(result>0)
                        result = 1;

                }
            }
        }

        public int GetContactsPagesNums(int PageSize)
        {
            return ContactContactsInfo.GetContactsPages(PageSize);
        }

        public int GetContactGridPageNo(int ContactID, int GridPageSize)
        {
            ContactContactsInfo CCI = new ContactContactsInfo();
            CCI.ContactID = ContactID;
            int PageNo = CCI.GetContactPage(GridPageSize);

            return (PageNo == -1) ? 0 : PageNo;
        }
    }
}