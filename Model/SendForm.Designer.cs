using System;

namespace DeliveryApplication.Model
{
    partial class SendForm
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMenuPackage = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.lblDateNow = new System.Windows.Forms.Label();
            this.lblPackageNumber = new System.Windows.Forms.Label();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblVisitNumber = new System.Windows.Forms.Label();
            this.imgClientLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panelSender = new Guna.UI2.WinForms.Guna2Panel();
            this.panelPackageInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.panelRecipient = new Guna.UI2.WinForms.Guna2Panel();
            this.panelPayment = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgClientLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnMenuPackage);
            this.guna2Panel1.Controls.Add(this.btnExit);
            this.guna2Panel1.Controls.Add(this.lblDateNow);
            this.guna2Panel1.Controls.Add(this.lblPackageNumber);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox2);
            this.guna2Panel1.Controls.Add(this.lblVisitNumber);
            this.guna2Panel1.Controls.Add(this.imgClientLogo);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1257, 90);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnMenuPackage
            // 
            this.btnMenuPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuPackage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.btnMenuPackage.BorderRadius = 5;
            this.btnMenuPackage.BorderThickness = 1;
            this.btnMenuPackage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuPackage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMenuPackage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMenuPackage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMenuPackage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnMenuPackage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMenuPackage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnMenuPackage.Image = global::DeliveryApplication.Properties.Resources.menuOther;
            this.btnMenuPackage.Location = new System.Drawing.Point(1083, 29);
            this.btnMenuPackage.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.btnMenuPackage.Name = "btnMenuPackage";
            this.btnMenuPackage.Size = new System.Drawing.Size(45, 45);
            this.btnMenuPackage.TabIndex = 6;
            this.btnMenuPackage.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.btnExit.BorderRadius = 5;
            this.btnExit.BorderThickness = 1;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.Image = global::DeliveryApplication.Properties.Resources.btnEsc;
            this.btnExit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnExit.ImageOffset = new System.Drawing.Point(0, 1);
            this.btnExit.ImageSize = new System.Drawing.Size(22, 22);
            this.btnExit.Location = new System.Drawing.Point(1137, 29);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 45);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "ВИЙТИ";
            this.btnExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExit.TextOffset = new System.Drawing.Point(-3, 0);
            this.btnExit.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // lblDateNow
            // 
            this.lblDateNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDateNow.AutoSize = true;
            this.lblDateNow.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDateNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblDateNow.Location = new System.Drawing.Point(240, 51);
            this.lblDateNow.Name = "lblDateNow";
            this.lblDateNow.Size = new System.Drawing.Size(135, 23);
            this.lblDateNow.TabIndex = 4;
            this.lblDateNow.Text = "Дата: 10.04.2023";
            // 
            // lblPackageNumber
            // 
            this.lblPackageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPackageNumber.AutoSize = true;
            this.lblPackageNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPackageNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblPackageNumber.Location = new System.Drawing.Point(186, 51);
            this.lblPackageNumber.Name = "lblPackageNumber";
            this.lblPackageNumber.Size = new System.Drawing.Size(48, 23);
            this.lblPackageNumber.TabIndex = 3;
            this.lblPackageNumber.Text = "7424";
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2PictureBox2.Image = global::DeliveryApplication.Properties.Resources.arrowDown;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(155, 50);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(25, 25);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 2;
            this.guna2PictureBox2.TabStop = false;
            // 
            // lblVisitNumber
            // 
            this.lblVisitNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVisitNumber.AutoSize = true;
            this.lblVisitNumber.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVisitNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblVisitNumber.Location = new System.Drawing.Point(71, 51);
            this.lblVisitNumber.Name = "lblVisitNumber";
            this.lblVisitNumber.Size = new System.Drawing.Size(78, 23);
            this.lblVisitNumber.TabIndex = 1;
            this.lblVisitNumber.Text = "Візит 10";
            // 
            // imgClientLogo
            // 
            this.imgClientLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgClientLogo.Image = global::DeliveryApplication.Properties.Resources.userIcon;
            this.imgClientLogo.ImageRotate = 0F;
            this.imgClientLogo.Location = new System.Drawing.Point(10, 37);
            this.imgClientLogo.Name = "imgClientLogo";
            this.imgClientLogo.Size = new System.Drawing.Size(50, 50);
            this.imgClientLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgClientLogo.TabIndex = 0;
            this.imgClientLogo.TabStop = false;
            // 
            // panelSender
            // 
            this.panelSender.BackColor = System.Drawing.Color.Transparent;
            this.panelSender.BorderColor = System.Drawing.Color.White;
            this.panelSender.BorderRadius = 12;
            this.panelSender.BorderThickness = 2;
            this.panelSender.CustomBorderThickness = new System.Windows.Forms.Padding(5);
            this.panelSender.FillColor = System.Drawing.Color.White;
            this.panelSender.Location = new System.Drawing.Point(10, 96);
            this.panelSender.Name = "panelSender";
            this.panelSender.Size = new System.Drawing.Size(299, 579);
            this.panelSender.TabIndex = 1;
            // 
            // panelPackageInfo
            // 
            this.panelPackageInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelPackageInfo.BorderColor = System.Drawing.Color.White;
            this.panelPackageInfo.BorderRadius = 12;
            this.panelPackageInfo.BorderThickness = 2;
            this.panelPackageInfo.FillColor = System.Drawing.Color.White;
            this.panelPackageInfo.Location = new System.Drawing.Point(315, 96);
            this.panelPackageInfo.Name = "panelPackageInfo";
            this.panelPackageInfo.Size = new System.Drawing.Size(299, 579);
            this.panelPackageInfo.TabIndex = 2;
            // 
            // panelRecipient
            // 
            this.panelRecipient.BackColor = System.Drawing.Color.Transparent;
            this.panelRecipient.BorderColor = System.Drawing.Color.White;
            this.panelRecipient.BorderRadius = 12;
            this.panelRecipient.BorderThickness = 2;
            this.panelRecipient.FillColor = System.Drawing.Color.White;
            this.panelRecipient.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelRecipient.Location = new System.Drawing.Point(631, 96);
            this.panelRecipient.Name = "panelRecipient";
            this.panelRecipient.Size = new System.Drawing.Size(299, 579);
            this.panelRecipient.TabIndex = 2;
            // 
            // panelPayment
            // 
            this.panelPayment.BackColor = System.Drawing.Color.Transparent;
            this.panelPayment.BorderColor = System.Drawing.Color.White;
            this.panelPayment.BorderRadius = 12;
            this.panelPayment.BorderThickness = 2;
            this.panelPayment.FillColor = System.Drawing.Color.White;
            this.panelPayment.Location = new System.Drawing.Point(945, 96);
            this.panelPayment.Name = "panelPayment";
            this.panelPayment.Size = new System.Drawing.Size(299, 579);
            this.panelPayment.TabIndex = 2;
            // 
            // btnCreate
            // 
            this.btnCreate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.btnCreate.BorderRadius = 5;
            this.btnCreate.BorderThickness = 1;
            this.btnCreate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCreate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCreate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCreate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCreate.Location = new System.Drawing.Point(1126, 681);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(118, 45);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "СТВОРИТИ";
            // 
            // SendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1257, 744);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.panelPayment);
            this.Controls.Add(this.panelRecipient);
            this.Controls.Add(this.panelPackageInfo);
            this.Controls.Add(this.panelSender);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendForm";
            this.Load += new System.EventHandler(this.SendForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgClientLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox imgClientLogo;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label lblVisitNumber;
        private System.Windows.Forms.Label lblDateNow;
        private System.Windows.Forms.Label lblPackageNumber;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2Button btnMenuPackage;
        private Guna.UI2.WinForms.Guna2Panel panelSender;
        private Guna.UI2.WinForms.Guna2Panel panelPackageInfo;
        private Guna.UI2.WinForms.Guna2Panel panelRecipient;
        private Guna.UI2.WinForms.Guna2Panel panelPayment;
        private Guna.UI2.WinForms.Guna2Button btnCreate;
    }
}