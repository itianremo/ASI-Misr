namespace DBInstaller
{
    partial class frmUpdate
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
            this.grbUpdate = new System.Windows.Forms.GroupBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnUpdateDB = new System.Windows.Forms.Button();
            this.grbUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbUpdate
            // 
            this.grbUpdate.Controls.Add(this.lblState);
            this.grbUpdate.Controls.Add(this.lblResult);
            this.grbUpdate.Controls.Add(this.btnFinish);
            this.grbUpdate.Controls.Add(this.btnUpdateDB);
            this.grbUpdate.Location = new System.Drawing.Point(12, 12);
            this.grbUpdate.Name = "grbUpdate";
            this.grbUpdate.Size = new System.Drawing.Size(525, 242);
            this.grbUpdate.TabIndex = 2;
            this.grbUpdate.TabStop = false;
            this.grbUpdate.Text = "Continue Installation";
            // 
            // lblState
            // 
            this.lblState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblState.Location = new System.Drawing.Point(6, 16);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(513, 105);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "Press \'Go\' to start updating database.";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(6, 187);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(513, 23);
            this.lblResult.TabIndex = 2;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFinish
            // 
            this.btnFinish.Enabled = false;
            this.btnFinish.Location = new System.Drawing.Point(391, 143);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(128, 23);
            this.btnFinish.TabIndex = 0;
            this.btnFinish.Text = "&Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnUpdateDB
            // 
            this.btnUpdateDB.Location = new System.Drawing.Point(6, 143);
            this.btnUpdateDB.Name = "btnUpdateDB";
            this.btnUpdateDB.Size = new System.Drawing.Size(128, 23);
            this.btnUpdateDB.TabIndex = 0;
            this.btnUpdateDB.Text = "&Go";
            this.btnUpdateDB.UseVisualStyleBackColor = true;
            this.btnUpdateDB.Click += new System.EventHandler(this.btnUpdateDB_Click);
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 266);
            this.Controls.Add(this.grbUpdate);
            this.Name = "frmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmUpdate";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpdate_FormClosed);
            this.grbUpdate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbUpdate;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnUpdateDB;
        public System.Windows.Forms.Label lblState;
    }
}