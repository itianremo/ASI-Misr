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

public partial class Go_TestingPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime value = DateTime.Today;
        System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        //Console.WriteLine(value.ToString("D", culture));
        // culture = System.Globalization.CultureInfo.GetCultureInfo("en-GB");
        string ss = "Cairo" +System.Environment.NewLine + " Printed " + value.ToString("D", culture);
          ss = "Cairo" +System.Environment.NewLine + " Printed " + value.ToString("DD", culture);
          ss = "Cairo" +System.Environment.NewLine + " Printed " + value.ToString("M", culture);
          ss = "Cairo" +System.Environment.NewLine + " Printed " + value.ToString("MM", culture);
        ss += "";

    }
}
