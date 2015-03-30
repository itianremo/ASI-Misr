using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Office.DAL;
using System.Collections.Generic;

namespace Office.BLL
{
    [System.ComponentModel.DataObject]
    public class RegistrationBLL : MasterClass
    {
        public RegistrationBLL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        Registration reg = new Registration();
       
        #region Get Registration By Email

        public DataRow mGetRegisterationByEmail(string Email)
        {

            return reg.mGetRegisterationByEmail(Email);
        }
        #endregion
        #region Get Registration
        public DataSet mGetRegisteration()
        {
            return reg.mGetRegisteration();
        }
        #endregion

        #region Add Registration
        public int mAddRegisteration(string Email, int Checklist, int Agrement)
        {
           return reg.mAddRegisteration(Email, Checklist, Agrement);

        }
        #endregion
        #region Update Registration
        public int mUpdateRegisteration(string Email, bool Checklist, bool Agrement, bool Visible)
        {
            return reg.mUpdateRegisteration(Email, Checklist, Agrement, Visible);

        }
        #endregion

        #region Delete Registration
        public int mDeleteRegisteration(string Email)
        {
            return reg.mDeleteRegisteration(Email);
        }
        #endregion


        


              
    }
}
