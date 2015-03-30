using System;
using System.Collections.Generic;
using System.Web;
using Office.DAL;
using System.Collections;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace Office.BLL
{
    [System.ComponentModel.DataObject]
    public class HomeBLL : MasterClass
	 {
        public HomeBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<Tasks> SelectOpenTasks()
        {
            Tasks Cl = new Tasks();
            return Cl.GetOpenTasks(((ASIIdentity)User.Identity).UserID, DateTime.Today);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<MyCalls> SelectMyCalls()
        {
            MyCalls MC = new MyCalls();
            return MC.GetMyCalls();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<TopAccounts> SelectTopAccounts()
        {
            TopAccounts TA = new TopAccounts();
            return TA.GetTopAccounts();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<MyCustomerSupports> SelectCustomerSupport(int IsCustomerSupport)
        {
            List<MyCustomerSupports> mcsList = new List<MyCustomerSupports>();
            MyCustomerSupports mcs;
            DataTable dt;
            DataView dv;

            try
            {
                if (IsCustomerSupport == 0)
                {
                    ELSData.DataService sdata = new ELSData.DataService();
                    ELSData.AuthHeader ss = new ELSData.AuthHeader();
                    sdata.Url = ConfigurationManager.AppSettings["ELSData.DataService"].ToString();
                    ss.Password = ConfigurationManager.AppSettings["UserNameELS"].ToString();
                    ss.Username = ConfigurationManager.AppSettings["PasswordELS"].ToString();
                    sdata.AuthHeaderValue = ss;
                    dt = sdata.getAllContact();
                    dv = dt.DefaultView;
                }
                else
                {
                    RequestQuote.DataService sdata = new RequestQuote.DataService();
                    RequestQuote.AuthHeader ss = new RequestQuote.AuthHeader();
                    sdata.Url = ConfigurationManager.AppSettings["ELSData.DataService"].ToString();
                    ss.Password = ConfigurationManager.AppSettings["UserNameELS"].ToString();
                    ss.Username = ConfigurationManager.AppSettings["PasswordELS"].ToString();
                    sdata.AuthHeaderValue = ss;
                    dt = sdata.getRequestForm();
                    dv = dt.DefaultView;
                }

                for (int i = 0; i < 5; i++)
                {
                    mcs = new MyCustomerSupports();

                    if (dv.Count == i)
                        break;

                    mcs.Account = dt.Rows[i]["companyName"].ToString();
                    mcs.Country = dt.Rows[i]["country"].ToString();
                    mcs.FirstName = dt.Rows[i]["firstName"].ToString();
                    mcs.LastName = dt.Rows[i]["lastName"].ToString();
                    mcs.TechnicalSupportDate = null;
                    if (dt.Rows[i]["SubmitDate"] != null)
                        if (dt.Rows[i]["SubmitDate"].ToString().Length > 0)
                            mcs.TechnicalSupportDate = Convert.ToDateTime(dt.Rows[i]["SubmitDate"]);
                    mcs.TechnicalSupportID = null;
                    if (dt.Rows[i]["id"] != null)
                        if (dt.Rows[i]["id"].ToString().Length > 0)
                            mcs.TechnicalSupportID = Convert.ToInt32(dt.Rows[i]["id"]);

                    mcsList.Add(mcs);
                }
            }
            catch (Exception ex)
            {
                
            }

            return mcsList;
        }
    }
}