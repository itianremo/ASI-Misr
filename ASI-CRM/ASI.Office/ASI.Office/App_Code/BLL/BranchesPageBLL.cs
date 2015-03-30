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
    public class BranchesPageBLL : MasterClass
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

        public BranchesPageBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<Branches> SelectBranches(Branches CurrentBranch)
        {
            Branches Br = new Branches();

            if (CurrentBranch != null)
            {
                Br = CurrentBranch;
            }

            return Br.GetBranchesData();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public Branches GetBranchByID(int BranchID)
        {
            Branches Br = new Branches();
            Br.BranchID = BranchID;
            return Br.GetSingleBranch();
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

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public Branches GetSearchFilter(string Sortby,
                                            string sortDirection,
                                            string SpecificFilter,
                                            Filter Fltr,
                                            string LocationFilter,
                                            string SpecificLocation,
                                            int FilterBranchNotes)
        {
            Branches Br = new Branches();
            switch (Sortby)
            {
                case "BranchName":
                    Br.SortExpression = Branches.SortBy.BranchName;
                    break;

                case "City":
                    Br.SortExpression = Branches.SortBy.City;
                    break;

                case "State":
                    Br.SortExpression = Branches.SortBy.State;
                    break;

                case "BusinessSectorName":
                    Br.SortExpression = Branches.SortBy.BusinessSectorName;
                    break;

                case "Tag":
                    Br.SortExpression = Branches.SortBy.Tag;
                    break;

                case "LastBranchNoteDate":
                    Br.SortExpression = Branches.SortBy.LastAccountNoteDate;
                    break;

                case "IDStatus":
                    Br.SortExpression = Branches.SortBy.IDStatus;
                    break;

                case "CountryName":
                    Br.SortExpression = Branches.SortBy.CountryName;
                    break;
            }

            switch (sortDirection)
            {
                case "ASC":
                    Br.SortDirect = SortDirection.Ascending;
                    break;

                case "Desc":
                    Br.SortDirect = SortDirection.Descending;
                    break;
            }

            switch (Fltr.IncrementalSearch)
            {
                case "Company":
                    Br.BranchName = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    break;

                case "Business Sector":
                    Br.BussinessSectorName = (Fltr.IncrementalSearchValue != "") ? Fltr.IncrementalSearchValue : null;
                    if (Fltr.IncrementalSearchValue != "")
                        Fltr.BusSector = Fltr.IncrementalSearchValue;
                    break;
            }

            Br.IDStatus = (Fltr.StatusID != -1) ? Fltr.StatusID : null;
            Br.BussinessSectorName = (Fltr.BusSector != "-1") ? Fltr.BusSector : null;

            if (SpecificLocation != "")
            {
                switch (LocationFilter)
                {
                    case "Country":
                        Br.CountryName = SpecificLocation;
                        break;

                    case "State":
                        Br.State = SpecificLocation;
                        break;
                }
            }
            // Added By Fawzi
            Br.FilterBranchNotes = Convert.ToInt32(Fltr.Notes);// FilterBranchNotes;
            //
            return Br;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public Branches GetBranchDetailsSearchFilter(string SpecificFilter, string FilterField, string BranchID)
        {
            Branches Br = new Branches();
            if (SpecificFilter != "")
            {
                switch (FilterField)
                {
                    case "Company":
                        Br.BranchName = SpecificFilter;
                        break;

                    case "Business Sector":
                        Br.BussinessSectorName = SpecificFilter;
                        break;
                }
            }
            if (BranchID != "")
            {
                Br.BranchID = int.Parse(BranchID);

            }
            return Br;
        }
    }
}