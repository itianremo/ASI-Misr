using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Office.DAL;

namespace Office.BLL
{
    [System.ComponentModel.DataObject]
    public class ManageApplicationBLL : MasterClass
    {
        public ManageApplicationBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select,false)]
        public List<MainSubCode> GetSubCodeList(string CurrentGCode)
        {
            MainSubCode GetList = new MainSubCode();
            GetList.GCode = CurrentGCode;
            return GetList.GetSCodeList();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<WebsitesServices> GetWebsitesServicesList()
        {
            WebsitesServices GetList = new WebsitesServices();
            return GetList.GetRelatedWebsitesServices();
        }

        public void GetWebsitesService(int WSID, out string WSName, out string WSURL, out string WSUsername)
        {
            WebsitesServices WS = (new WebsitesServices()).GetWebsitesServiceByID(WSID);
            WSName = WS.WSName;
            WSURL = WS.WSURL;
            WSUsername = WS.WSUsername;
        }
    }
}