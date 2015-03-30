using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Redirect : Pharma.BMD.BLL.MasterClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region -------------------Graphics Handler--------------------
            /////////////////////////////////////////////////////////////////////////////////////
            btnBMD.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/BMDmodule-o.png") + "'");
            btnFMT.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/FMTmodule-o.png") + "'");
            /////////////////////////////////////////////////////////////////////////////////////
            btnBMD.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/BMDmodule-n.png") + "'");
            btnFMT.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/FMTmodule-n.png") + "'");
            /////////////////////////////////////////////////////////////////////////////////////
            #endregion
        }
    }
}
