using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class ConfigData_Default9 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ConfigDB"] == null)
            {
                Response.Redirect("~/ConfigData/ConfigData.aspx", true);
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["ConfigDB"] = null;
        Response.Redirect("~/ConfigData/ConfigData.aspx", true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmaConnectionString"].ConnectionString);
        con.Open();
        SqlCommand comm = new SqlCommand(TextBox1.Text, con);
        Label1.Text = comm.ExecuteNonQuery().ToString();
        con.Close();
    }
}