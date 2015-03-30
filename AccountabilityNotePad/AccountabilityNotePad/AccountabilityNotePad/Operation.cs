using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountabilityNotePad
{
    public partial class Operation : Form
    {
        public Operation()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            #region Visual effects
            lblOperation.Enabled = false;
            cmbOperation.Enabled = false;

            lblNewOpration.Enabled = true;
            tbxNewOperation.Enabled = true;
            lblDescription.Enabled = true;
            tbxDescription.Enabled = true;

            btnSave.Visible = true;
            btnCancel.Visible = true;

            btnNew.Visible = false;
            btnEdit.Visible = false;
            btnDel.Visible = false;
            #endregion
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            #region Visual effects
            lblOperation.Enabled = false;
            cmbOperation.Enabled = false;

            lblNewOpration.Enabled = true;
            tbxNewOperation.Enabled = true;
            lblDescription.Enabled = true;
            tbxDescription.Enabled = true;

            btnSave.Visible = true;
            btnCancel.Visible = true;

            btnNew.Visible = false;
            btnEdit.Visible = false;
            btnDel.Visible = false;
            #endregion
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to delete?", "Warning!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            #region Visual effects
            lblOperation.Enabled = true;
            cmbOperation.Enabled = true;

            lblNewOpration.Enabled = false;
            tbxNewOperation.Text = "Enter the new name";
            tbxNewOperation.Enabled = false;
            lblDescription.Enabled = false;
            tbxDescription.Text = "Selected Operation";
            tbxDescription.Enabled = false;

            btnSave.Visible = false;
            btnCancel.Visible = false;

            btnNew.Visible = true;
            btnEdit.Visible = true;
            btnDel.Visible = true;
            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Visual effects
            lblOperation.Enabled = true;
            cmbOperation.Enabled = true;

            lblNewOpration.Enabled = false;
            tbxNewOperation.Text = "Enter the new name";
            tbxNewOperation.Enabled = false;
            lblDescription.Enabled = false;
            tbxDescription.Text = "Selected Operation";
            tbxDescription.Enabled = false;

            btnSave.Visible = false;
            btnCancel.Visible = false;

            btnNew.Visible = true;
            btnEdit.Visible = true;
            btnDel.Visible = true;
            #endregion
        }
    }
}