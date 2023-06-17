using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DeliveryApplication.Model
{
    public partial class AddCompanyForm : Form
    {
        public AddCompanyForm()
        {
            InitializeComponent();
            companies = new List<Company>();
        }
        private List<Company> companies;

        public Company SelectedCompany { get; private set; }

        private async void AddCompany_Load(object sender, EventArgs e)
        {
            txtSearchCompany.Focus();
            if (companies.Count == 0)
            {
                try
                {
                    await DataBaseControl.LoadCompaniesAsync(companies);
                    DisplayData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}");
                }
            }
            else
            {
                DisplayData();
            }

        }

        private void DisplayData()
        {
            foreach (Company com in companies)
            {
                lbListCompany.Items.Add(com);
            }
        }

        private void txtSearchCompany_TextChanged(object sender, EventArgs e)
        {
            lbListCompany.Items.Clear();

            for (int i = 0; i < companies.Count; i++)
            {
                if (companies[i].Name.ToLower().Contains(txtSearchCompany.Text.ToLower()))
                {
                    lbListCompany.Items.Add(companies[i]);
                }
            }
        }

        private void txtSearchCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && lbListCompany.Items.Count > 0)
            {
                lbListCompany.Focus();
                lbListCompany.SelectedIndex = 0;
            }
           
        }

        private void lbListCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && lbListCompany.SelectedIndex == 0)
            {
                txtSearchCompany.Focus();
            }
            if (e.KeyCode == Keys.Enter && lbListCompany.SelectedItem != null)
            {
                SelectedCompany = (Company)lbListCompany.SelectedItem;
                this.Close();
                SendForm.Obj.Show();
            }
        }

        private void txtCodeCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            SendForm.Obj.Show();
        }

        private void btnCreateCompany_Click(object sender, EventArgs e)
        {
            #region Проверка ввода имени и кода компании
            if (string.IsNullOrEmpty(txtNameCompany.Text) && string.IsNullOrEmpty(txtCodeCompany.Text))
            {
                txtNameCompany.BorderColor = Color.Red;
                txtNameCompany.PlaceholderForeColor = Color.Red;

                txtCodeCompany.BorderColor = Color.Red;
                txtCodeCompany.PlaceholderForeColor = Color.Red;

                lblNameCompanyError.Visible = true;
                lblCodeCompanyError.Text = "Не заповнено поле";
                lblCodeCompanyError.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(txtNameCompany.Text))
            {
                txtNameCompany.BorderColor = Color.Red;
                lblNameCompanyError.Text = "Не заповнено поле";
                lblNameCompanyError.Visible = true;
            }
            if (MainForm.CountCharactersWithoutSpaces(txtNameCompany.Text) < 3)
            {
                txtNameCompany.BorderColor = Color.Red;
                lblNameCompanyError.Text = "Назва компанії повинна бути від 3 символів";
                lblNameCompanyError.Visible = true;
            }
            if (string.IsNullOrEmpty(txtCodeCompany.Text) || txtCodeCompany.Text.Length != 6)
            {
                txtCodeCompany.BorderColor = Color.Red;
                lblCodeCompanyError.Text = "ЄДРПОУ повинен складатися із 6 цифр";
                lblCodeCompanyError.Visible = true;
            }
            #endregion
            if (MainForm.CountCharactersWithoutSpaces(txtNameCompany.Text) > 2
                && txtCodeCompany.Text.Length == 6)
            {
                string qry = "SELECT COUNT(*) FROM Companies WHERE com_Name = @companyName OR com_Number = @companyCode";
                Hashtable ht = new Hashtable();
                ht.Add("@companyName", txtNameCompany.Text);
                ht.Add("@companyCode", txtCodeCompany.Text);
                int result = DataBaseControl.CheckExistence(qry, ht);
                if (result > 0)
                {
                    guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                    
                    if (guna2MessageDialog1.Show("Компанія з такою назвою або номером вже існує") == DialogResult.OK)
                    {
                        txtNameCompany.Focus();
                        txtNameCompany.SelectionStart = txtNameCompany.Text.Length;
                    }
                }
                else
                {
                    qry = "INSERT Companies VALUES (@companyName, @companyCode)";
                    ht.Clear();
                    ht.Add("@companyName", txtNameCompany.Text);
                    ht.Add("@companyCode", txtCodeCompany.Text);
                    result = DataBaseControl.Execute(qry, ht);
                    if (result > 0)
                    {
                        guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                        guna2MessageDialog1.Icon = MessageDialogIcon.Information;
                        guna2MessageDialog1.Show("Компанію створено!");

                        Company company = DataBaseControl.FindCompanyByNameAndCode(txtNameCompany.Text,txtCodeCompany.Text);
                        if (company != null)
                        {
                            companies.Add(company);
                            lbListCompany.Items.Add(company);
                            txtNameCompany.Text = string.Empty;
                            txtCodeCompany.Text = string.Empty;
                            lbListCompany.Focus();
                            lbListCompany.SelectedIndex = lbListCompany.Items.Count - 1;
                        }
                    }
                }
            }

        }
        #region Фокус кнопок
        private void txtNameCompany_Enter(object sender, EventArgs e)
        {
            txtNameCompany.BorderColor = Color.FromArgb(213,218,223);
            txtNameCompany.PlaceholderForeColor = Color.Gray;
            lblNameCompanyError.Visible = false;
        }

        private void txtCodeCompany_Enter(object sender, EventArgs e)
        {
            txtCodeCompany.BorderColor = Color.FromArgb(213, 218, 223);
            txtCodeCompany.PlaceholderForeColor = Color.Gray;
            lblCodeCompanyError.Visible = false;
        }

        private void btnCreateCompany_Enter(object sender, EventArgs e)
        {
            btnCreateCompany.BorderColor = Color.FromArgb(27, 45, 137);
        }

        private void btnCreateCompany_Leave(object sender, EventArgs e)
        {
            btnCreateCompany.BorderColor = Color.FromArgb(155, 155, 155);
        }

        private void guna2Panel2_Leave(object sender, EventArgs e)
        {
            guna2Panel2.BorderColor = Color.Silver;
        }

        private void guna2Panel2_Enter(object sender, EventArgs e)
        {
            guna2Panel2.BorderColor = Color.DarkSlateBlue;
        }

        private void btnClose_Enter(object sender, EventArgs e)
        {
            btnClose.BorderColor = Color.DarkSlateBlue;
            btnClose.BorderThickness = 1;
        }

        private void btnClose_Leave(object sender, EventArgs e)
        {
            btnClose.BorderColor = Color.Transparent;
            btnClose.BorderThickness = 1;
        }
        #endregion
    }
}
