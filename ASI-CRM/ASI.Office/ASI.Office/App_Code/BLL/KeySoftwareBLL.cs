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
    public class KeySoftwareBLL : System.Web.UI.UserControl
    {
        public KeySoftwareBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public List<KeySoftware> SelectAllKeySoftware(KeySoftware CurrentKey)
        {
            KeySoftware key = new KeySoftware();
            if (CurrentKey != null)
                key = CurrentKey;
            return key.GetKeySoftWare();
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public KeySoftware SelectKeySoftware(KeySoftware CurrentKey)
        {
            if (CurrentKey != null)
                return CurrentKey.GetSingleKeySoftWare();
            else
                return new KeySoftware();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public KeySoftware GetSearchFilter(string Sortby, string sortDirection)
        {
            KeySoftware key = new KeySoftware();
            switch (Sortby)
            {
                case "Software":
                    key.SortExpression = KeySoftware.SortBy.Software;
                    break;

                case "SID":
                    key.SortExpression =KeySoftware.SortBy.SID;
                    break;
                case "Version":
                    key.SortExpression = KeySoftware.SortBy.Version;
                    break;


            }

            switch (sortDirection)
            {
                case "ASC":
                    key.SortDirect = SortDirection.Ascending;
                    break;

                case "Desc":
                    key.SortDirect = SortDirection.Descending;
                    break;
            }


            //
            return key;

        }


              
    }
}
