using System;
using System.Collections.Generic;
using System.Web;
using Office.DAL;
using System.Collections;
using System.Web.UI.WebControls;

namespace Office.BLL
{
    [System.ComponentModel.DataObject]
    public class CallsBLL : MasterClass
    {
        public CallsBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<Calls> SelectCalls(Calls CurrentCall)
        {
            Calls Cl = new Calls();

            if (CurrentCall != null)
            {
                Cl = CurrentCall;
            }

            return Cl.GetRelatedCalls();
        }

        public List<MainSubCode> GetCallStatusList()
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = "CallStatus";
            List<MainSubCode> MSCodeLst = GetList.GetSCodeList();
            return MSCodeLst;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public Calls GetSearchFilter(string sortDirection,
                                    string SpecificFilter,
                                    string CallDate,
                                    string OrderBy)
        {
            Calls Cl = new Calls();
            switch (OrderBy)
            {
                case "Subject":
                    Cl.SortExpression = Calls.SortBy.Subject;
                    break;
                case "ContactFirstName":
                    Cl.SortExpression = Calls.SortBy.ContactFirstName;
                    break;
                case "ContactLastName":
                    Cl.SortExpression = Calls.SortBy.ContactLastName;
                    break;
                case "StatusName":
                    Cl.SortExpression = Calls.SortBy.StatusName;
                    break;
                case "StartDate":
                    Cl.SortExpression = Calls.SortBy.StartDate;
                    break;
                case "Notes":
                    Cl.SortExpression = Calls.SortBy.Notes;
                    break;
                default:
                    Cl.SortExpression = Calls.SortBy.EnterDate;
                    break;
            }
            

            switch (sortDirection)
            {
                case "ASC":
                    Cl.SortDirect = SortDirection.Ascending;
                    break;

                case "Desc":
                    Cl.SortDirect = SortDirection.Descending;
                    break;
            }

            Cl.ContactFirstName = (SpecificFilter != "") ? SpecificFilter : null;

            if (CallDate.Length > 0)
                Cl.StartDate = Convert.ToDateTime(CallDate);

            return Cl;
        }

        public bool AddCall(string Subject, DateTime StartDate, int Status, int RelatedTo, string Notes)
        {
            Calls Cl = new Calls();

            Cl.Subject = Subject;
            Cl.StartDate = StartDate;
            Cl.Status = Status;
            Cl.ContactID = RelatedTo;
            Cl.AccountID = null;
            Cl.EnterByID = ((ASIIdentity)User.Identity).UserID;
            Cl.EnterDate = DateTime.Now;
            Cl.EditByID = ((ASIIdentity)User.Identity).UserID;
            Cl.EditDate = DateTime.Now;
            Cl.Notes = Notes;

            return Cl.AddNewCall() == 1;
        }

        public bool UpdateCall(int CallID, string Subject, DateTime StartDate, int Status, int RelatedTo, string Notes)
        {
            Calls Cl = new Calls();

            Cl.CallID = CallID;
            Cl.Subject = Subject;
            Cl.StartDate = StartDate;
            Cl.Status = Status;
            Cl.ContactID = RelatedTo;
            Cl.AccountID = null;
            Cl.EditByID = ((ASIIdentity)User.Identity).UserID;
            Cl.EditDate = DateTime.Now;
            Cl.Notes = Notes;

            return Cl.UpdateCall() == 1;
        }

        public string DeleteCallByID(int CallID)
        {
            Calls Cl = new Calls();
            Cl.CallID = CallID;

            string ResultMsg = Cl.DeleteCall();

            if (ResultMsg.Equals("1"))
                ResultMsg = "Call deleted successfully!";
            else
                ResultMsg = "Call not found.";

            return ResultMsg;
        }
    }
}