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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //CreatLineChart(FusionLineChart.Line2D);
    }

    private void CreatLineChart(string CharType)
    {
        FusionLineChart lineChart = new FusionLineChart();
        lineChart.showNames = true;
        lineChart.subCaption = "";
        lineChart.caption = "";
        lineChart.yAxisName = "Total Scores";
        lineChart.xAxisName = "Score Date";
        lineChart.yAxisMaxValue = 100;
        string chartHtml = lineChart.CreateSetElement(BuildChartData(), CharType, divScoresChart.ClientID, false, "", "StrScoreDate", "Total", "StrScoreDate", "", "", false, 400, 300);
        divScoresChart.InnerHtml = chartHtml;
    }

    protected void ddlChartType_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddlChartType.SelectedValue)
        {
            case "Area2D":
                CreatLineChart(FusionLineChart.Area2D);
                break;
            case "Bar2D":
                CreatLineChart(FusionLineChart.Bar2D);
                break;
            case "Line2D":
                CreatLineChart(FusionLineChart.Line2D);
                break;
            default:
                break;
        }
    }

    private DataTable BuildChartData()
    {
        //DataTable dtChart, string nameField, string valueField, string hoverTextField, string urlField, string urlPrefix, int chartWidth, int chartHeight

        return new dsPhysicianScoreTableAdapters.daPhysicianScore().GetPhysicianScoresByPhysicianDesc(1, false);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Roles.DeleteRole("admin1");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            RegularExpressionValidator1.ValidationExpression = TextBox2.Text;
            RegularExpressionValidator1.Validate();
            Label2.Text = "";
        }
        catch (Exception ex)
        {
            Label2.Text = ex.Message;
        }
        
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            ((Label)e.Row.FindControl("lblCommited")).Attributes.Add("onMouseOver", "this.style.background='#0099cc'");
            ((Label)e.Row.FindControl("lblCommited")).Attributes.Add("onMouseOut", "this.style.background='#ffffff'");
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "this.style.background='#ff9900'");
            e.Row.Attributes.Add("onMouseOut", "if(this.getElementsByTagName('input')[0].checked){this.style.background='#BCC9B7'}else{this.style.background='#ffffff'}");
        }
    }
}
