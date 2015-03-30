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

public partial class Go_frmConfigurationf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            display();
        //Modify("MailingType", "1");

    }
    //The following code snippet displays all the keys of the appSettings section of the web.config file: 


    void display()
    {
        Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");

        AppSettingsSection appSettingsSection =

         (AppSettingsSection)configuration.GetSection("appSettings");

        if (appSettingsSection != null)
        {

            foreach (string key in appSettingsSection.Settings.AllKeys)
            {

                //Response.Write(key);
                ddlkeys.Items.Add(key);

            }
            if (ddlkeys.Items.Count > 0)

                txtKey.Text = GetKeyValue(ddlkeys.Items[0].Value);

        }
    }

 

//The following method can be used to modify a specific key — value pair of the web.config file — programmatically using C#:



    public void Modify(string key, string value)
    {
        try
        {

            Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");

            AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");

            if (appSettingsSection != null)
            {

                appSettingsSection.Settings[key].Value = value;

                //config.Save();
                configuration.Save();

            }
        }
        catch
        {
            Response.Write("The web.config file is read only, it must be read and write");
        }

    }

 

//The following method can be used to delete a specific key in the web.config file programmatically using C#:



    public void Remove(string key)
    {
        try
        {
            Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");

            AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");

            if (appSettingsSection != null)
            {
                appSettingsSection.Settings.Remove(key);
                configuration.Save();

            }
        }
        catch
        {
            Response.Write("The web.config file is read only, it must be read and write");
        }


    }



    protected void ddlkeys_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtKey.Text =  GetKeyValue(ddlkeys.SelectedValue);
       
    }

    private string GetKeyValue(string key)
    {
        try
        {
            Configuration configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");

            AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");

            if (appSettingsSection != null)
            {

                return appSettingsSection.Settings[key].Value;

            }
            else return "";
        }
        catch
        {
            return "";
        }
    }
    protected void btnUpdateKeyValue_Click(object sender, ImageClickEventArgs e)
    {
        if(ddlkeys.Items.Count>0)
            if (ddlkeys.SelectedValue != null)
            {
                Modify(ddlkeys.SelectedValue, txtKey.Text.Trim());
            }
    }
}
