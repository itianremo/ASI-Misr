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
using System.Web.Configuration;

public partial class AdminPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        lblPassState.Text = "";
        if (!IsPostBack)
        {
            if (Session["User"] == null)
                Response.Redirect("LoginPage.aspx");
            else
            {
                txtNewFoxProPW.Text = "";
                txtConfFoxProPW.Text = "";
                Configuration objConfig = WebConfigurationManager.OpenWebConfiguration("~");
                AppSettingsSection objAppSettings = (AppSettingsSection)objConfig.GetSection("appSettings");
                if (objAppSettings != null)
                {
                    txtCurrentServer.Text = objAppSettings.Settings["ServerName"].Value;
                    txtCurrentURL.Text = objAppSettings.Settings["AccountabilityURL"].Value;
                    txtCurrentHelp.Text = objAppSettings.Settings["HelpURL"].Value;
                    txtCurrentFoxConn.Text = objAppSettings.Settings["FoxProConnection"].Value;
                    txtCurrentAUUAUpdateLoc.Text = objAppSettings.Settings["AUUAUpdateLocation"].Value;
                    txtCurrentANPUpdateLoc.Text = objAppSettings.Settings["ANPUpdateLocation"].Value;
                    txtCurrentFoxProUN.Text = objAppSettings.Settings["FoxProUserName"].Value;
                }
            }
        }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        try
        {
            if ((txtNewServerName.Text.Trim() != "" && txtNewServerName.Text.Trim().ToLower() != txtCurrentServer.Text.Trim().ToLower())
                || (txtNewURL.Text.Trim() != "" && txtNewURL.Text.Trim().ToLower() != txtCurrentURL.Text.Trim().ToLower())
                || (txtNewHelp.Text.Trim() != "" && txtNewHelp.Text.Trim().ToLower() != txtCurrentHelp.Text.Trim().ToLower())
                || (txtNewFoxConn.Text.Trim() != "" && txtNewFoxConn.Text.Trim().ToLower() != txtCurrentFoxConn.Text.Trim().ToLower())
                || (txtNewAUUAUpdateLoc.Text.Trim() != "" && txtNewAUUAUpdateLoc.Text.Trim().ToLower() != txtCurrentAUUAUpdateLoc.Text.Trim().ToLower())
                || (txtNewANPUpdateLoc.Text.Trim() != "" && txtNewANPUpdateLoc.Text.Trim().ToLower() != txtCurrentANPUpdateLoc.Text.Trim().ToLower())
                || (txtNewFoxProUN.Text.Trim() != "" && txtNewFoxProUN.Text.Trim().ToLower() != txtCurrentFoxProUN.Text.Trim().ToLower())
                || (txtNewFoxProPW.Text.Trim() != "" && txtConfFoxProPW.Text.Trim() != ""))
            {
                if (txtNewFoxProPW.Text.Trim() != "" && txtNewFoxProPW.Text.Trim() != txtConfFoxProPW.Text.Trim())
                    lblPassState.Text = "New password and confirmation are not matched!";
                else
                {
                    Configuration objConfig = WebConfigurationManager.OpenWebConfiguration("~");
                    AppSettingsSection objAppSettings = (AppSettingsSection)objConfig.GetSection("appSettings");
                    if (objAppSettings != null)
                    {
                        if (txtNewServerName.Text.Trim() != "")
                            objAppSettings.Settings["ServerName"].Value = txtNewServerName.Text.Trim();
                        if (txtNewURL.Text.Trim() != "")
                            objAppSettings.Settings["AccountabilityURL"].Value = txtNewURL.Text.Trim();
                        if (txtNewHelp.Text.Trim() != "")
                            objAppSettings.Settings["HelpURL"].Value = txtNewHelp.Text.Trim();
                        if (txtNewFoxConn.Text.Trim() != "")
                            objAppSettings.Settings["FoxProConnection"].Value = txtNewFoxConn.Text.Trim();
                        if (txtNewAUUAUpdateLoc.Text.Trim() != "")
                            objAppSettings.Settings["AUUAUpdateLocation"].Value = txtNewAUUAUpdateLoc.Text.Trim();
                        if (txtNewANPUpdateLoc.Text.Trim() != "")
                            objAppSettings.Settings["ANPUpdateLocation"].Value = txtNewANPUpdateLoc.Text.Trim();
                        if (txtNewFoxProUN.Text.Trim() != "")
                            objAppSettings.Settings["FoxProUserName"].Value = txtNewFoxProUN.Text.Trim();
                        if (txtNewFoxProPW.Text.Trim() != "")
                        {
                            objAppSettings.Settings["FoxProUserPass"].Value = EncryptText(txtNewFoxProPW.Text.Trim());
                            lblPassState.Text = "New password has been saved.";
                        }
                        objConfig.Save();
                        txtCurrentServer.Text = objAppSettings.Settings["ServerName"].Value;
                        txtCurrentURL.Text = objAppSettings.Settings["AccountabilityURL"].Value;
                        txtCurrentHelp.Text = objAppSettings.Settings["HelpURL"].Value;
                        txtCurrentFoxConn.Text = objAppSettings.Settings["FoxProConnection"].Value;
                        txtCurrentAUUAUpdateLoc.Text = objAppSettings.Settings["AUUAUpdateLocation"].Value;
                        txtCurrentANPUpdateLoc.Text = objAppSettings.Settings["ANPUpdateLocation"].Value;
                        txtCurrentFoxProUN.Text = objAppSettings.Settings["FoxProUserName"].Value;
                        lblMessage.Text = "Settings Changed Successfully";
                        txtNewURL.Text = "";
                        txtNewServerName.Text = "";
                        txtNewHelp.Text = "";
                        txtNewFoxConn.Text = "";
                        txtNewAUUAUpdateLoc.Text = "";
                        txtNewANPUpdateLoc.Text = "";
                        txtNewFoxProUN.Text = "";
                        txtNewFoxProPW.Text = "";
                        txtConfFoxProPW.Text = "";
                    }
                }
            }
        }
        catch (Exception Ecp)
        {
            lblMessage.Text = Ecp.Message;
        }
    }

    private string EncryptText(string TextToEncrypt)
    {
        string SKey = "0123456789";
        string EncryptedText = Util.EncryptData(TextToEncrypt, SKey);
        return EncryptedText;
    }
    private string DecryptText(string TextToDecrypt)
    {
        string SKey = "0123456789";
        string DecData = Util.DecryptData(TextToDecrypt, SKey);
        return DecData;
    }
}