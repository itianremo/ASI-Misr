using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;

public partial class test3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.ddlCreditCheck.Attributes.Add("onchange", "alert('d');");
        this.ddlCreditCheck.Attributes.Add("onkeyup", "this.blur();this.focus();");
    }
    
   
}