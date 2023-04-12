using DeliveryApplication.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryApplication
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            guna2Panel1.Location = new Point((this.ClientSize.Width - guna2Panel1.Width) / 2, guna2Panel1.Location.Y);
            guna2Panel1.Location = new Point(guna2Panel1.Location.X, (this.ClientSize.Height - guna2Panel1.Height) / 2);
        }
        
        #region Фокус кнопок
        private void guna2Button1_Enter(object sender, EventArgs e)
        {
            btnInput.BorderColor = Color.FromArgb(27,45,137);
            btnInput.BorderThickness = 1;
        }
        private void guna2Button1_Leave(object sender, EventArgs e)
        {
            btnInput.BorderColor = Color.Transparent;
            btnInput.BorderThickness = 0;
        }
        private void btnClose_Enter(object sender, EventArgs e)
        {
            btnClose.BorderColor = Color.FromArgb(195, 0, 0);
            btnClose.BorderThickness = 2;
        }
        private void btnClose_Leave(object sender, EventArgs e)
        {
            btnClose.BorderColor = Color.Transparent;
            btnClose.BorderThickness = 0;
        }
        private void txtUser_Enter(object sender, EventArgs e)
        {
            txtUser.BorderColor = Color.FromArgb(213, 218, 223);
            txtUser.PlaceholderForeColor = Color.Gray;
            txtPassword.BorderColor = Color.FromArgb(213, 218, 223);
            txtPassword.PlaceholderForeColor = Color.Gray;
            lblLoginError.Visible = false;
            lblPasswordError.Visible = false;
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtUser.BorderColor = Color.FromArgb(213, 218, 223);
            txtUser.PlaceholderForeColor = Color.Gray;
            txtPassword.BorderColor = Color.FromArgb(213, 218, 223);
            txtPassword.PlaceholderForeColor = Color.Gray;
            lblPasswordError.Visible = false;
            lblLoginError.Visible = false;
        }
        #endregion
        private void btnInput_Click(object sender, EventArgs e)
        {
            #region Проверки логина и пароля
            if (string.IsNullOrEmpty(txtUser.Text) && string.IsNullOrEmpty(txtPassword.Text))
            {
                txtUser.BorderColor = Color.Red;
                txtUser.PlaceholderForeColor = Color.Red;

                txtPassword.BorderColor = Color.Red;
                txtPassword.PlaceholderForeColor = Color.Red;

                lblLoginError.Visible = true;
                lblPasswordError.Text = "Не заповнено поле";
                lblPasswordError.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                txtUser.BorderColor = Color.Red;
                lblLoginError.Text = "Не заповнено поле";
                lblLoginError.Visible = true;
            }
            if (string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                txtPassword.BorderColor = Color.Red;
                lblPasswordError.Text = "Пароль повинен бути від 6 до 50 символів";
                lblPasswordError.Visible = true;
            }
            #endregion
            if (txtUser.Text.Length > 0 && txtPassword.Text.Length > 5)
            {
                string qry = @"Select * from employee where empLogin = '" + txtUser.Text + "' and empPassword = '" + txtPassword.Text.GetHashCode() + "'";
                SqlCommand cmd = new SqlCommand(qry, DataBaseControl.GetConnection());
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MainForm.CurrentEmployee = GetEmployeeFromTable(dt.Rows[0]);
                    this.Hide();
                    StartScreen form = new StartScreen();
                    form.Show();
                }
                else
                {
                    txtUser.BorderColor = Color.Red;
                    txtPassword.BorderColor = Color.Red;
                    
                    lblPasswordError.Text = "Не вірно заповнено користувача або пароль";
                    lblPasswordError.Visible = true;
                }
            }
        }

        private Employee GetEmployeeFromTable(DataRow row)
        {
            int id = Convert.ToInt32(row["Id"]);
            string login = row["empLogin"].ToString();
            string name = row["empName"].ToString();
            string surname = row["empSurname"].ToString();
            string patronymic = row["empPatronymic"].ToString();
            string email = row["empEmail"].ToString();
            string phone = row["empNumberPhone"].ToString();

            return new Employee(id,login,name,surname,patronymic,email,phone);
        }
    }
}
