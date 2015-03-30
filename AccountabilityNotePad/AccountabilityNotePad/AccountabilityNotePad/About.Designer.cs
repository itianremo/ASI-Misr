namespace AccountabilityNotePad
{
    partial class About
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
            this.button1 = new System.Windows.Forms.Button();
            this.lblLineOne = new System.Windows.Forms.Label();
            this.lblLineTwo = new System.Windows.Forms.Label();
            this.lblLineThree = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbWebSite = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblLineOne
            // 
            this.lblLineOne.AutoSize = true;
            this.lblLineOne.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineOne.Location = new System.Drawing.Point(12, 21);
            this.lblLineOne.Name = "lblLineOne";
            this.lblLineOne.Size = new System.Drawing.Size(239, 14);
            this.lblLineOne.TabIndex = 1;
            this.lblLineOne.Text = "Licenced to the Steel Network, Inc.";
            // 
            // lblLineTwo
            // 
            this.lblLineTwo.AutoSize = true;
            this.lblLineTwo.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineTwo.Location = new System.Drawing.Point(11, 91);
            this.lblLineTwo.Name = "lblLineTwo";
            this.lblLineTwo.Size = new System.Drawing.Size(286, 29);
            this.lblLineTwo.TabIndex = 2;
            this.lblLineTwo.Text = "Accountability NotePad";
            // 
            // lblLineThree
            // 
            this.lblLineThree.AutoSize = true;
            this.lblLineThree.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineThree.Location = new System.Drawing.Point(12, 171);
            this.lblLineThree.Name = "lblLineThree";
            this.lblLineThree.Size = new System.Drawing.Size(277, 14);
            this.lblLineThree.TabIndex = 3;
            this.lblLineThree.Text = "Version 1.0    Build # 44    June 08,2009";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Copyright © The Steel Network, Inc.";
            // 
            // lbWebSite
            // 
            this.lbWebSite.AutoSize = true;
            this.lbWebSite.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWebSite.Location = new System.Drawing.Point(240, 216);
            this.lbWebSite.Name = "lbWebSite";
            this.lbWebSite.Size = new System.Drawing.Size(163, 16);
            this.lbWebSite.TabIndex = 6;
            this.lbWebSite.TabStop = true;
            this.lbWebSite.Text = "www.steelnetwork.com";
            this.lbWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbWebSite_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AccountabilityNotePad.Properties.Resources.Acc_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(303, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 88);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(221)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(409, 267);
            this.ControlBox = false;
            this.Controls.Add(this.lbWebSite);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLineThree);
            this.Controls.Add(this.lblLineTwo);
            this.Controls.Add(this.lblLineOne);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblLineOne;
        private System.Windows.Forms.Label lblLineTwo;
        private System.Windows.Forms.Label lblLineThree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lbWebSite;
    }
}