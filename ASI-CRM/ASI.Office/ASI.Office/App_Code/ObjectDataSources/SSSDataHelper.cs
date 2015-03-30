using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Caching;

[System.ComponentModel.DataObject]
public class SSSDataHelper : Office.BLL.MasterClass
{
	public SSSDataHelper()
	{ 
	}

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SSSData.MembersDS.MembersDataTable GetData()
    {
        if (HttpContext.Current.Cache["MembersDataTable"] != null)
        {
            return (SSSData.MembersDS.MembersDataTable)((SSSData.MembersDS.MembersDataTable)HttpContext.Current.Cache["MembersDataTable"]).Copy();
        }
        else
        {
            SSSData.SSSData sdata = Connect();
            SSSData.MembersDS.MembersDataTable dt = sdata.GetAllMembers();
            HttpContext.Current.Cache.Add("MembersDataTable", dt, null, DateTime.Now.AddDays(2), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            return (SSSData.MembersDS.MembersDataTable)dt.Copy();
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public void RefreshData()
    {
            SSSData.SSSData sdata = Connect();
            SSSData.MembersDS.MembersDataTable dt = sdata.GetAllMembers();
            HttpContext.Current.Cache.Add("MembersDataTable", dt, null, DateTime.Now.AddDays(2), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
    }

    public bool AddMember(string firstname, string lastname, string address, string address2, string city, string state, string country, string company, string phone, string fax, string website, string email, DateTime regDate, bool sss, bool lgd, bool ldg, bool approved, string zipcode, bool checkListValue, bool agreementValue, string password)
    {
        SSSData.SSSData sdata = Connect();
        bool result = sdata.AddMember(firstname, lastname, address, address2, city, state, country, company, phone, fax, website, email, password, sss, lgd, ldg, zipcode, regDate, approved);

        if (result)
        {
            sdata.UpdateAgreement(email, agreementValue);
            SSSData.MembersDS.MembersDataTable dt = sdata.GetAllMembers();
            HttpContext.Current.Cache.Add("MembersDataTable", dt, null, DateTime.Now.AddDays(2), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
        }

        return result;
    }


    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SSSData.Webinars.WebinarRegDataTable GetWebinarData()
    {
        if (HttpContext.Current.Cache["WebinarRegDataTable"] != null)
        {
            return (SSSData.Webinars.WebinarRegDataTable)((SSSData.Webinars.WebinarRegDataTable)HttpContext.Current.Cache["WebinarRegDataTable"]).Copy();
        }
        else
        {
            SSSData.SSSData sdata = Connect();
            SSSData.Webinars.WebinarRegDataTable dt = sdata.GetAllWebinarRegistrations();
            HttpContext.Current.Cache.Add("WebinarRegDataTable", dt, null, DateTime.Now.AddDays(2), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            return (SSSData.Webinars.WebinarRegDataTable)dt.Copy();
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public void RefreshWebinarData()
    {
        SSSData.SSSData sdata = Connect();
        SSSData.Webinars.WebinarRegDataTable dt = sdata.GetAllWebinarRegistrations();
        HttpContext.Current.Cache.Add("WebinarRegDataTable", dt, null, DateTime.Now.AddDays(2), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
    }

    private static SSSData.SSSData Connect()
    {
        SSSData.SSSData sdata = new SSSData.SSSData();
        SSSData.AuthHeader ss = new SSSData.AuthHeader();
        ss.Password = ConfigurationManager.AppSettings["PasswordSSS"].ToString();
        ss.Username = ConfigurationManager.AppSettings["UserNameSSS"].ToString();
        sdata.AuthHeaderValue = ss;
        return sdata;
    }
}