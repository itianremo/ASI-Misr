namespace AccountabilityNotePad
{
    partial class Edit_Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCurntName = new System.Windows.Forms.Label();
            this.btnClosURL = new System.Windows.Forms.Button();
            this.URLBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.grvSrvNam = new System.Windows.Forms.GroupBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.btnSaveAllChanges = new System.Windows.Forms.Button();
            this.cbStartUp = new System.Windows.Forms.CheckBox();
            this.grGeneral = new System.Windows.Forms.GroupBox();
            this.cbAlwaysHide = new System.Windows.Forms.CheckBox();
            this.grStartMode = new System.Windows.Forms.GroupBox();
            this.rdBtnMFGMode = new System.Windows.Forms.RadioButton();
            this.rdBtnAccMode = new System.Windows.Forms.RadioButton();
            this.grvSrvNam.SuspendLayout();
            this.grGeneral.SuspendLayout();
            this.grStartMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurntName
            // 
            this.lblCurntName.AutoSize = true;
            this.lblCurntName.Location = new System.Drawing.Point(8, 16);
            this.lblCurntName.Name = "lblCurntName";
            this.lblCurntName.Size = new System.Drawing.Size(69, 13);
            this.lblCurntName.TabIndex = 2;
            this.lblCurntName.Text = "Server Name";
            // 
            // btnClosURL
            // 
            this.btnClosURL.Location = new System.Drawing.Point(190, 176);
            this.btnClosURL.Name = "btnClosURL";
            this.btnClosURL.Size = new System.Drawing.Size(94, 23);
            this.btnClosURL.TabIndex = 6;
            this.btnClosURL.Text = "Cancel";
            this.btnClosURL.UseVisualStyleBackColor = true;
            this.btnClosURL.Click += new System.EventHandler(this.btnClosURL_Click);
            // 
            // grvSrvNam
            // 
            this.grvSrvNam.Controls.Add(this.lblHint);
            this.grvSrvNam.Controls.Add(this.lblCurntName);
            this.grvSrvNam.Controls.Add(this.txtCurrent);
            this.grvSrvNam.Location = new System.Drawing.Point(9, 12);
            this.grvSrvNam.Name = "grvSrvNam";
            this.grvSrvNam.Size = new System.Drawing.Size(345, 61);
            this.grvSrvNam.TabIndex = 6;
            this.grvSrvNam.TabStop = false;
            this.grvSrvNam.Text = "Change Server Name";
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(8, 41);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(292, 13);
            this.lblHint.TabIndex = 3;
            this.lblHint.Text = "*Hint: The name of server that contains the routing service";
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(95, 16);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(149, 20);
            this.txtCurrent.TabIndex = 0;
            // 
            // btnSaveAllChanges
            // 
            this.btnSaveAllChanges.Location = new System.Drawing.Point(77, 176);
            this.btnSaveAllChanges.Name = "btnSaveAllChanges";
            this.btnSaveAllChanges.Size = new System.Drawing.Size(94, 23);
            this.btnSaveAllChanges.TabIndex = 0;
            this.btnSaveAllChanges.Text = "OK";
            this.btnSaveAllChanges.UseVisualStyleBackColor = true;
            this.btnSaveAllChanges.Click += new System.EventHandler(this.btnSaveAllChanges_Click);
            // 
            // cbStartUp
            // 
            this.cbStartUp.AutoSize = true;
            this.cbStartUp.Location = new System.Drawing.Point(6, 42);
            this.cbStartUp.Name = "cbStartUp";
            this.cbStartUp.Size = new System.Drawing.Size(151, 17);
            this.cbStartUp.TabIndex = 4;
            this.cbStartUp.Text = "Add application in start up";
            this.cbStartUp.UseVisualStyleBackColor = true;
            this.cbStartUp.Visible = false;
            // 
            // grGeneral
            // 
            this.grGeneral.Controls.Add(this.cbAlwaysHide);
            this.grGeneral.Controls.Add(this.cbStartUp);
            this.grGeneral.Location = new System.Drawing.Point(9, 85);
            this.grGeneral.Name = "grGeneral";
            this.grGeneral.Size = new System.Drawing.Size(345, 74);
            this.grGeneral.TabIndex = 12;
            this.grGeneral.TabStop = false;
            this.grGeneral.Text = "General Settings";
            // 
            // cbAlwaysHide
            // 
            this.cbAlwaysHide.AutoSize = true;
            this.cbAlwaysHide.Checked = global::AccountabilityNotePad.Properties.Settings.Default.HideApp;
            this.cbAlwaysHide.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AccountabilityNotePad.Properties.Settings.Default, "HideApp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAlwaysHide.Location = new System.Drawing.Point(6, 19);
            this.cbAlwaysHide.Name = "cbAlwaysHide";
            this.cbAlwaysHide.Size = new System.Drawing.Size(214, 17);
            this.cbAlwaysHide.TabIndex = 3;
            this.cbAlwaysHide.Text = "Always hide application when minimized";
            this.cbAlwaysHide.UseVisualStyleBackColor = true;
            // 
            // grStartMode
            // 
            this.grStartMode.Controls.Add(this.rdBtnMFGMode);
            this.grStartMode.Controls.Add(this.rdBtnAccMode);
            this.grStartMode.Location = new System.Drawing.Point(9, 168);
            this.grStartMode.Name = "grStartMode";
            this.grStartMode.Size = new System.Drawing.Size(342, 74);
            this.grStartMode.TabIndex = 13;
            this.grStartMode.TabStop = false;
            this.grStartMode.Text = "Select defualt start mode";
            this.grStartMode.Visible = false;
            // 
            // rdBtnMFGMode
            // 
            this.rdBtnMFGMode.AutoSize = true;
            this.rdBtnMFGMode.Location = new System.Drawing.Point(6, 42);
            this.rdBtnMFGMode.Name = "rdBtnMFGMode";
            this.rdBtnMFGMode.Size = new System.Drawing.Size(75, 17);
            this.rdBtnMFGMode.TabIndex = 1;
            this.rdBtnMFGMode.Text = "MFG Mode";
            this.rdBtnMFGMode.UseVisualStyleBackColor = true;
            // 
            // rdBtnAccMode
            // 
            this.rdBtnAccMode.AutoSize = true;
            this.rdBtnAccMode.Checked = true;
            this.rdBtnAccMode.Location = new System.Drawing.Point(6, 19);
            this.rdBtnAccMode.Name = "rdBtnAccMode";
            this.rdBtnAccMode.Size = new System.Drawing.Size(121, 17);
            this.rdBtnAccMode.TabIndex = 0;
            this.rdBtnAccMode.TabStop = true;
            this.rdBtnAccMode.Text = "Accountability Mode";
            this.rdBtnAccMode.UseVisualStyleBackColor = true;
            // 
            // Edit_Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(221)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(363, 212);
            this.ControlBox = false;
            this.Controls.Add(this.grStartMode);
            this.Controls.Add(this.btnSaveAllChanges);
            this.Controls.Add(this.btnClosURL);
            this.Controls.Add(this.grvSrvNam);
            this.Controls.Add(this.grGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Edit_Configuration";
            this.ShowInTaskbar = false;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Edit_Configuration_Load);
            this.grvSrvNam.ResumeLayout(false);
            this.grvSrvNam.PerformLayout();
            this.grGeneral.ResumeLayout(false);
            this.grGeneral.PerformLayout();
            this.grStartMode.ResumeLayout(false);
            this.grStartMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.Label lblCurntName;
        private System.Windows.Forms.FolderBrowserDialog URLBrowser;
        private System.Windows.Forms.GroupBox grvSrvNam;
        private System.Windows.Forms.CheckBox cbAlwaysHide;
        private System.Windows.Forms.CheckBox cbStartUp;
        private System.Windows.Forms.GroupBox grGeneral;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.RadioButton rdBtnMFGMode;
        private System.Windows.Forms.RadioButton rdBtnAccMode;
        public System.Windows.Forms.GroupBox grStartMode;
        public System.Windows.Forms.Button btnClosURL;
        public System.Windows.Forms.Button btnSaveAllChanges;
    }
}