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
    public class DueDiligenceBLL : System.Web.UI.UserControl
    {
        public DueDiligenceBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<DueDiligence> GetDueDiligenceData(DueDiligence CurrentDueDiligence)
        {
            DueDiligence objDueDiligence = new DueDiligence();
            if (CurrentDueDiligence != null)
                objDueDiligence = CurrentDueDiligence;
            return objDueDiligence.GetDueDiligenceData();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<DueDiligence> GetDueDiligenceByAccountID(DueDiligence CurrentDueDiligence)
        {
            DueDiligence objDueDiligence = new DueDiligence();
            if (CurrentDueDiligence != null)
                objDueDiligence = CurrentDueDiligence;
            return objDueDiligence.GetDueDiligenceByAccID();
        }

        
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public DueDiligence GetDueDiligenceByDueDiligenceID(DueDiligence CurrentDueDiligence)
        {
            if (CurrentDueDiligence != null)
                return CurrentDueDiligence.GetSingleDueDiligence();
            else
                return new DueDiligence();
        }

      
        
    }
}
