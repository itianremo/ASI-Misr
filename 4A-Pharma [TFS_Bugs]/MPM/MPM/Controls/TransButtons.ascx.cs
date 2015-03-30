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


    public partial class TransButtons : System.Web.UI.UserControl
    {
            
        #region ---------------Class Declaration----------------------

            /// <summary>
        /// Declare Custom Event handler for each button on the ToolBar of type Event Handler
        /// </summary>
        public event EventHandler btnAddEvent, btnEditEvent, btnSaveEvent, btnCancelEvent, btnDeleteEvent;
        string strCurrentPage;
        
        #endregion

        #region -------------------Onload Event Handler---------------

        protected void Page_Load(object sender, EventArgs e)
        {
            #region -------------------Graphics Handler--------------------

            btnAdd.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/add_o.jpg") + "'");
            btnEdit.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/Edit_o.jpg") + "'");
            btnSave.Attributes.Add("onmouseover", "this.src='" + ResolveClientUrl("~/Images/Save_o.jpg") + "'");
            btnCancel.Attributes.Add("onmouseover", "this.src='"+ ResolveClientUrl("~/Images/cancel-d.jpg") + "'");
            btnDelete.Attributes.Add("onmouseover", "this.src='"+ ResolveClientUrl("~/Images/delete_o.jpg") + "'");
            //////////////////////////////////////////////////////////////////////////
            btnAdd.Attributes.Add("onmouseout", "this.src='" + ResolveClientUrl("~/Images/add_n.jpg") + "'");
            btnEdit.Attributes.Add("onmouseout", "this.src='"+ ResolveClientUrl("~/Images/Edit_n.jpg") + "'");
            btnSave.Attributes.Add("onmouseout", "this.src='"+ ResolveClientUrl("~/Images/Save_n.jpg") + "'");
            btnCancel.Attributes.Add("onmouseout", "this.src='"+ ResolveClientUrl("~/Images/cancel-n.jpg") + "'");
            btnDelete.Attributes.Add("onmouseout", "this.src='"+ ResolveClientUrl("~/Images/delete_n.jpg") + "'");
            
            #endregion
            SetButtonsHandler();
        }
        #endregion

        #region -------------------Control Handler--------------------

        private void SetButtonsHandler()
        {
            Pharma.BMD.BLL.MasterClass MCPage = new Pharma.BMD.BLL.MasterClass();
            //MCPage.RefreshCurrentUserInfo();
            if (CurrentPage == "SearchPage" || CurrentPage == "ManageApplication" || CurrentPage == "Reports")
            {
                    // Normal User // Has No Access to Add or Edit //
                    btnAdd.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;

            }

        }
        #endregion

        #region -------------------Event Handler----------------------
        ///property which allow the user of the custom toolbar to enable/disable the buttons 
        ///of the toolbar

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (this.btnAddEvent != null)
                btnAddEvent(sender, new EventArgs());

        }
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            if (this.btnEditEvent != null)
                btnEditEvent(sender, new EventArgs());

        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (this.btnSaveEvent != null)
                btnSaveEvent(sender, new EventArgs());

        }
        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            if (this.btnCancelEvent != null)
                btnCancelEvent(sender, new EventArgs());
        }
        
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            if (this.btnDeleteEvent != null)
                btnDeleteEvent(sender, new EventArgs());
        }

        #endregion

        #region -------------------Properties-------------------------
        public string CurrentPage
        {
            get { return strCurrentPage; }
            set { strCurrentPage = value; }
        }
        #endregion
    }
