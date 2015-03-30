namespace DBInstaller
{
    partial class frmMain
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
            this.btnSelectDB = new System.Windows.Forms.Button();
            this.grbStart = new System.Windows.Forms.GroupBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.grbStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectDB
            // 
            this.btnSelectDB.Location = new System.Drawing.Point(6, 143);
            this.btnSelectDB.Name = "btnSelectDB";
            this.btnSelectDB.Size = new System.Drawing.Size(128, 23);
            this.btnSelectDB.TabIndex = 0;
            this.btnSelectDB.Text = "&Select Database...";
            this.btnSelectDB.UseVisualStyleBackColor = true;
            this.btnSelectDB.Click += new System.EventHandler(this.btnSelectDB_Click);
            // 
            // grbStart
            // 
            this.grbStart.Controls.Add(this.lblState);
            this.grbStart.Controls.Add(this.lblResult);
            this.grbStart.Controls.Add(this.btnNext);
            this.grbStart.Controls.Add(this.btnSelectDB);
            this.grbStart.Location = new System.Drawing.Point(12, 12);
            this.grbStart.Name = "grbStart";
            this.grbStart.Size = new System.Drawing.Size(525, 242);
            this.grbStart.TabIndex = 1;
            this.grbStart.TabStop = false;
            this.grbStart.Text = "Start Installation";
            // 
            // lblState
            // 
            this.lblState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblState.Location = new System.Drawing.Point(6, 16);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(513, 105);
            this.lblState.TabIndex = 2;
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
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(391, 143);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(128, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 266);
            this.Controls.Add(this.grbStart);
            this.Name = "frmMain";
            this.Text = "Install Database";
            this.grbStart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectDB;
        private System.Windows.Forms.GroupBox grbStart;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnNext;
    }
}