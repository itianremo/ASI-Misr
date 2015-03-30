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

public partial class CreateReport : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {    
        txtReportName.Focus();
    }
    protected void ButtonSaveReprt_Click(object sender, EventArgs e)
    {
        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[a-zA-Z0-9\p{IsArabic}_\s]");
        foreach (char c in txtReportName.Text)
        {
            System.Text.RegularExpressions.Match match = reg.Match(c.ToString());
            if (!match.Success)
            {
                tblErr.Rows[0].Cells[1].Text = "Report name must not have special characters.";
                tblErr.Visible = true;
                return;
            }
        }
        if (txtReportName.Text.Trim() == string.Empty)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "fdsf", "<script>alert('Report name must not be null.')</script>");
            tblErr.Rows[0].Cells[1].Text = "Report name must not be null.";
            tblErr.Visible = true;
            return;
        }
        //Make Session["ReportInserted"] = null to add more reports
        Session["ReportInserted"] = null;
        Session["FireFoxPostBack"] = "false";
        Response.Redirect("Query.aspx?Status=NewReport&ReportName=" + txtReportName.Text.Trim() + "");
    }
}
