using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Caching;
using System.Data;

[System.ComponentModel.DataObject]
public class ELSDataHelper : Office.BLL.MasterClass
{
    public ELSDataHelper()
	{
	}

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public DataTable GetData()
    {
        if (HttpContext.Current.Cache["ELSData"] != null)
        {
            return ((DataTable)HttpContext.Current.Cache["ELSData"]).Copy();
        }
        else
        {
            ELSData.DataService sdata = Connect();
            DataTable dt = sdata.getAllContact();
            HttpContext.Current.Cache.Add("ELSData", dt, null, DateTime.Now.AddDays(2), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            return dt.Copy();
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public void RefreshWebinarData()
    {
        ELSData.DataService sdata = Connect();
        DataTable dt = sdata.getAllContact();
        HttpContext.Current.Cache.Add("ELSData", dt, null, DateTime.Now.AddDays(2), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
    }

    private static ELSData.DataService Connect()
    {
        ELSData.DataService sdata = new ELSData.DataService();
        ELSData.AuthHeader ss = new ELSData.AuthHeader();
        ss.Password = ConfigurationManager.AppSettings["PasswordELS"].ToString();
        ss.Username = ConfigurationManager.AppSettings["UserNameELS"].ToString();
        sdata.AuthHeaderValue = ss;
        return sdata;
    }
}