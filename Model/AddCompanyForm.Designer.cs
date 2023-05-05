namespace DeliveryApplication.Model
{
    partial class AddCompanyForm
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
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchCompany = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbListCompany = new System.Windows.Forms.ListBox();
            this.txtCodeCompany = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNameCompany = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCodeCompanyError = new System.Windows.Forms.Label();
            this.lblNameCompanyError = new System.Windows.Forms.Label();
            this.btnCreateCompany = new Guna.UI2.WinForms.Guna2Button();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.BorderRadius = 40;
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.CustomizableEdges.BottomLeft = false;
            this.guna2Panel1.CustomizableEdges.TopLeft = false;
            this.guna2Panel1.CustomizableEdges.TopRight = false;
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.guna2Panel1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(800, 70);
            this.guna2Panel1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 3;
            this.btnClose.FillColor = System.Drawing.Color.Firebrick;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(752, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Enter += new System.EventHandler(this.btnClose_Enter);
            this.btnClose.Leave += new System.EventHandler(this.btnClose_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(0, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Додати компанію";
            // 
            // txtSearchCompany
            // 
            this.txtSearchCompany.BorderRadius = 5;
            this.txtSearchCompany.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchCompany.DefaultText = "";
            this.txtSearchCompany.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchCompany.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchCompany.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchCompany.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchCompany.FocusedState.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.txtSearchCompany.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearchCompany.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchCompany.IconLeft = global::DeliveryApplication.Properties.Resources.linse;
            this.txtSearchCompany.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtSearchCompany.IconLeftSize = new System.Drawing.Size(15, 15);
            this.txtSearchCompany.Location = new System.Drawing.Point(13, 77);
            this.txtSearchCompany.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchCompany.Name = "txtSearchCompany";
            this.txtSearchCompany.PasswordChar = '\0';
            this.txtSearchCompany.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.txtSearchCompany.PlaceholderText = "Пошук";
            this.txtSearchCompany.SelectedText = "";
            this.txtSearchCompany.Size = new System.Drawing.Size(429, 45);
            this.txtSearchCompany.TabIndex = 0;
            this.txtSearchCompany.TextOffset = new System.Drawing.Point(5, 0);
            this.txtSearchCompany.TextChanged += new System.EventHandler(this.txtSearchCompany_TextChanged);
            this.txtSearchCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchCompany_KeyDown);
            // 
            // lbListCompany
            // 
            this.lbListCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbListCompany.FormattingEnabled = true;
            this.lbListCompany.ItemHeight = 21;
            this.lbListCompany.Location = new System.Drawing.Point(13, 130);
            this.lbListCompany.Name = "lbListCompany";
            this.lbListCompany.Size = new System.Drawing.Size(429, 361);
            this.lbListCompany.TabIndex = 1;
            this.lbListCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbListCompany_KeyDown);
            // 
            // txtCodeCompany
            // 
            this.txtCodeCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeCompany.BorderRadius = 10;
            this.txtCodeCompany.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodeCompany.DefaultText = "";
            this.txtCodeCompany.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCodeCompany.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCodeCompany.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodeCompany.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodeCompany.FocusedState.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.txtCodeCompany.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCodeCompany.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodeCompany.Location = new System.Drawing.Point(5, 70);
            this.txtCodeCompany.Margin = new System.Windows.Forms.Padding(5);
            this.txtCodeCompany.MaxLength = 6;
            this.txtCodeCompany.Name = "txtCodeCompany";
            this.txtCodeCompany.Padding = new System.Windows.Forms.Padding(3);
            this.txtCodeCompany.PasswordChar = '\0';
            this.txtCodeCompany.PlaceholderText = "Код ЄДРПОУ";
            this.txtCodeCompany.SelectedText = "";
            this.txtCodeCompany.Size = new System.Drawing.Size(312, 36);
            this.txtCodeCompany.TabIndex = 1;
            this.txtCodeCompany.Enter += new System.EventHandler(this.txtCodeCompany_Enter);
            this.txtCodeCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodeCompany_KeyPress);
            // 
            // txtNameCompany
            // 
            this.txtNameCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameCompany.BorderRadius = 10;
            this.txtNameCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNameCompany.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNameCompany.DefaultText = "";
            this.txtNameCompany.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNameCompany.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNameCompany.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameCompany.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameCompany.FocusedState.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.txtNameCompany.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNameCompany.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameCompany.Location = new System.Drawing.Point(5, 8);
            this.txtNameCompany.Margin = new System.Windows.Forms.Padding(5);
            this.txtNameCompany.Name = "txtNameCompany";
            this.txtNameCompany.Padding = new System.Windows.Forms.Padding(3);
            this.txtNameCompany.PasswordChar = '\0';
            this.txtNameCompany.PlaceholderText = "Назва компанії";
            this.txtNameCompany.SelectedText = "";
            this.txtNameCompany.Size = new System.Drawing.Size(312, 36);
            this.txtNameCompany.TabIndex = 0;
            this.txtNameCompany.Enter += new System.EventHandler(this.txtNameCompany_Enter);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.lblCodeCompanyError);
            this.guna2Panel2.Controls.Add(this.lblNameCompanyError);
            this.guna2Panel2.Controls.Add(this.btnCreateCompany);
            this.guna2Panel2.Controls.Add(this.txtNameCompany);
            this.guna2Panel2.Controls.Add(this.txtCodeCompany);
            this.guna2Panel2.Location = new System.Drawing.Point(466, 130);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(322, 358);
            this.guna2Panel2.TabIndex = 2;
            this.guna2Panel2.Enter += new System.EventHandler(this.guna2Panel2_Enter);
            this.guna2Panel2.Leave += new System.EventHandler(this.guna2Panel2_Leave);
            // 
            // lblCodeCompanyError
            // 
            this.lblCodeCompanyError.AutoSize = true;
            this.lblCodeCompanyError.BackColor = System.Drawing.Color.White;
            this.lblCodeCompanyError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCodeCompanyError.ForeColor = System.Drawing.Color.Red;
            this.lblCodeCompanyError.Location = new System.Drawing.Point(17, 111);
            this.lblCodeCompanyError.Name = "lblCodeCompanyError";
            this.lblCodeCompanyError.Size = new System.Drawing.Size(119, 15);
            this.lblCodeCompanyError.TabIndex = 9;
            this.lblCodeCompanyError.Text = "Не заповнено поле";
            this.lblCodeCompanyError.Visible = false;
            // 
            // lblNameCompanyError
            // 
            this.lblNameCompanyError.AutoSize = true;
            this.lblNameCompanyError.BackColor = System.Drawing.Color.White;
            this.lblNameCompanyError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNameCompanyError.ForeColor = System.Drawing.Color.Red;
            this.lblNameCompanyError.Location = new System.Drawing.Point(17, 49);
            this.lblNameCompanyError.Name = "lblNameCompanyError";
            this.lblNameCompanyError.Size = new System.Drawing.Size(119, 15);
            this.lblNameCompanyError.TabIndex = 8;
            this.lblNameCompanyError.Text = "Не заповнено поле";
            this.lblNameCompanyError.Visible = false;
            // 
            // btnCreateCompany
            // 
            this.btnCreateCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCompany.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.btnCreateCompany.BorderRadius = 5;
            this.btnCreateCompany.BorderThickness = 1;
            this.btnCreateCompany.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateCompany.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateCompany.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreateCompany.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCreateCompany.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnCreateCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreateCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCreateCompany.Location = new System.Drawing.Point(192, 315);
            this.btnCreateCompany.Name = "btnCreateCompany";
            this.btnCreateCompany.Size = new System.Drawing.Size(120, 33);
            this.btnCreateCompany.TabIndex = 2;
            this.btnCreateCompany.Text = "СТВОРИТИ";
            this.btnCreateCompany.Click += new System.EventHandler(this.btnCreateCompany_Click);
            this.btnCreateCompany.Enter += new System.EventHandler(this.btnCreateCompany_Enter);
            this.btnCreateCompany.Leave += new System.EventHandler(this.btnCreateCompany_Leave);
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = null;
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            this.guna2MessageDialog1.Parent = null;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.guna2MessageDialog1.Text = null;
            // 
            // AddCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.lbListCompany);
            this.Controls.Add(this.txtSearchCompany);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AddCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCompany";
            this.Load += new System.EventHandler(this.AddCompany_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        protected Guna.UI2.WinForms.Guna2TextBox txtSearchCompany;
        private System.Windows.Forms.ListBox lbListCompany;
        private Guna.UI2.WinForms.Guna2TextBox txtCodeCompany;
        private Guna.UI2.WinForms.Guna2TextBox txtNameCompany;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnCreateCompany;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private System.Windows.Forms.Label lblCodeCompanyError;
        private System.Windows.Forms.Label lblNameCompanyError;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}