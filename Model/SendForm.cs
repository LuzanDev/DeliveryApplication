using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace DeliveryApplication.Model
{
    public partial class SendForm : Form
    {
        public SendForm()
        {
            InitializeComponent();
            Obj = this;
        }

        public static SendForm Obj { get; private set; }
        private void SendForm_Load(object sender, EventArgs e)
        {
            #region Отрисовка основных панелей управления формы Отправить
            int padding = 10;
            int workSizeWidth = (Screen.PrimaryScreen.Bounds.Width - padding * 5);
            int workSizeHeight = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 3);
            int width = workSizeWidth / 4;

            panelSender.Width = width;
            panelSender.Height = workSizeHeight;

            panelPackageInfo.Width = width;
            panelPackageInfo.Height = workSizeHeight;

            panelRecipient.Width = width;
            panelRecipient.Height = workSizeHeight;

            panelPayment.Width = width;
            panelPayment.Height = workSizeHeight;

            panelSender.Location = new Point(padding, padding + 90);
            panelPackageInfo.Location = new Point(padding * 2 + width, padding + 90);
            panelRecipient.Location = new Point(padding * 3 + width * 2, padding + 90);
            panelPayment.Location = new Point(padding * 4 + width * 3, padding + 90);

            btnCreate.Location = new Point((panelPayment.Location.X + panelPayment.Size.Width) - btnCreate.Size.Width, panelPayment.Location.Y + panelPayment.Size.Height + padding);
            #endregion

            #region Размещение кнопок ширина/длина/высота согласно размеру экрана
            int widthSetup = (txtDesPackage.Size.Width - 10) / 3;
            txtWidth.Width = widthSetup;
            txtLength.Width = widthSetup;
            txtHeight.Width = widthSetup;

            txtWidth.Location = new Point(txtDesPackage.Location.X, btnAddPackage.Location.Y + 62);
            txtLength.Location = new Point(txtDesPackage.Location.X + 5 + txtWidth.Size.Width, btnAddPackage.Location.Y + 62);
            txtHeight.Location = new Point(txtDesPackage.Location.X + 10 + txtLength.Size.Width + txtWidth.Size.Width, btnAddPackage.Location.Y + 62);
            #endregion
            clients = new List<Client>();
            listBox1.Size = new Size(txtNumberSender.Width,20);
            panelSender.Focus();
            txtNumberSender.Focus();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MainForm.Instance.AddControls(new ControlMenu());
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtDesPackage.Text.Length > 2)
            {
                cbTypeDelivery.Enabled = true;
            }
            else
            {
                cbTypeDelivery.Enabled = false;
            }
        }

        private void panel_Enter(object sender, EventArgs e)
        {
            if (sender is Guna2Panel panel)
            {
                panel.BorderColor = Color.FromArgb(46, 186, 119);
            }
            if (sender is Guna2Button button)
            {
                button.BorderColor = Color.FromArgb(46, 186, 119);
            }
        }

        private void panel_Leave(object sender, EventArgs e)
        {
            if (sender is Guna2Panel panel)
            {
                panel.BorderColor = Color.White;
            }
            if (sender is Guna2Button button)
            {
                button.BorderColor = Color.White;
            }
        }

        private void Generel_TextChanged(object sender, EventArgs e)
        {
            if (sender is Guna2TextBox activeButton)
            {
                
                if (activeButton.Text == "+38 (")
                {
                    activeButton.Text = "";
                    return;
                }
                if (activeButton.Text.Length == 3)
                {
                    activeButton.Text = "+38 (" + activeButton.Text + ")";
                    activeButton.SelectionStart = activeButton.Text.Length;
                    return;
                }

                if (activeButton.Text.Length == 9)
                {
                    activeButton.Text += " ";
                    activeButton.SelectionStart = activeButton.Text.Length;
                    return;
                }

                if (activeButton.Text.Length == 13)
                {
                    activeButton.Text += " ";
                    activeButton.SelectionStart = activeButton.Text.Length;
                    return;
                }
                if (activeButton.Text.Length == 16)
                {
                    activeButton.Text += " ";
                    activeButton.SelectionStart = activeButton.Text.Length;
                    return;
                }
            }
        }

        //Возможность стирать данные
        private void General_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is Guna2TextBox txtBox)
            {
                if (txtBox.Text.Length != 0)
                {
                    if (e.KeyCode == Keys.Back)
                    {
                        if (txtBox.Text.EndsWith(" "))
                        {
                            txtBox.Text = txtBox.Text.Remove(txtBox.Text.Length - 1);
                            txtBox.Text = txtBox.Text.Remove(txtBox.Text.Length - 2);
                            txtBox.SelectionStart = txtBox.Text.Length;
                        }
                    }
                }
                if (e.KeyCode == Keys.Down && listBox1.Visible)
                {
                    listBox1.Focus();
                    listBox1.SelectedIndex = 0;
                }
            }

        }

        //Ввод только цифры
        private void General_KeyPressOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void General_KeyPressFractionalNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            
            if (e.KeyChar == '.' && (sender as Guna.UI2.WinForms.Guna2TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }


        private void General_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Guna2TextBox button)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Clipboard.SetText(button.Text);
                }
            }
            
        }

        private List<Client> clients;
        private void txtNumberSender_TextChanged(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            imgAddOrgaSender.Visible = false;
            listBox1.Items.Clear();
            clients.Clear();
            Generel_TextChanged(sender, e);
            if (IsCorrectNumber((Guna2TextBox)sender))
            {
                /////////////////////////////////////////
                FillListBox((Guna2TextBox)sender);
                listBox1.Height = listBox1.PreferredHeight;
                panelSender.Controls.Add(listBox1);
                listBox1.Location = new Point(txtNumberSender.Location.X,txtNumberSender.Location.Y + 38);
                listBox1.Visible = true;
            }
            else
            {
                cbTypeSender.Visible = false;
                txtFullNameSender.Visible = false;
            }

        }
        private void FillListBox(Guna2TextBox text)
        {
            string qry = $@"SELECT 
                Client.cl_Id, Client.cl_NumberPhone, Client.cl_Name, Client.cl_Surname, Client.cl_Patronymic, 
                City.city_Name, Client.cl_LastNumberStock 
                FROM Client
                LEFT OUTER JOIN City ON Client.cl_City = City.city_Id
                WHERE cl_NumberPhone = '{text.Text}'";

            DataTable dt = DataBaseControl.GetData(qry);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Client client = GetClientFromTable(dt.Rows[i]);
                    clients.Add(client);
                }
            }
            else
            {
                listBox1.Items.Add("Клієнта не знайдено -> Створити");
                return;
            }

            foreach (var client in clients)
            {
                for (int i = 0; i < client.Companies.Count; i++)
                {
                    listBox1.Items.Add(client.ToString() + "-> " + client.Companies[i].ToString());
                }
                listBox1.Items.Add(client.ToString() + "-> Приватна особа");
            }
        }
        private Client GetClientFromTable(DataRow row)
        {
            Client client = new Client() 
            {
                ID = Convert.ToInt32(row["cl_Id"]),
                NumberPhone = row["cl_NumberPhone"].ToString(),
                Name = row["cl_Name"].ToString(),
                Surname = row["cl_Surname"].ToString(),
                Patronymic = row["cl_Patronymic"].ToString(),
                City = row["city_Name"].ToString(),
                LastNumberStock = Convert.ToInt32(row["cl_LastNumberStock"])
            };
            string qry = $@"SELECT 
                         Companies.com_Id, Companies.com_Name, Companies.com_Number 
                         FROM Companies
                         INNER JOIN PeopleCompanies
                         ON Companies.com_Id = PeopleCompanies.com_Id
                         WHERE PeopleCompanies.cl_Id = {client.ID}";
            DataTable dt = DataBaseControl.GetData(qry);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rows in dt.Rows)
                {
                    Company company = new Company
                    {
                        ID = Convert.ToInt32(rows["com_Id"]),
                        Name = rows["com_Name"].ToString(),
                        Code = Convert.ToInt32(rows["com_Number"])
                    };
                    client.Companies.Add(company);
                }
            }

            return client;
        }


        private bool IsCorrectNumber(Guna2TextBox number)
        {
            bool correct = false;
            if (number.Text.Length == 19 && number.Text.StartsWith("+38 (") && number.Text[8] == ')')
                correct = true;

            return correct;
        }

        private void txtDesPackage_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDesPackage.Text))
            {
                char[] charArray = txtDesPackage.Text.ToCharArray();
                charArray[0] = char.ToUpper(charArray[0]);
                txtDesPackage.Text = new string(charArray);
            }
        }

        private void txtFullNameSender_Leave(object sender, EventArgs e)
        {
            if (sender is Guna2TextBox text)
                text.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.Text.ToLower());
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.Enter)
            {
                if (listBox1.SelectedItem != null)
                {
                    if (clients.Count > 0)
                    {
                        //клиент получатель - в базе есть
                        if (panelRecipient.BorderColor == Color.FromArgb(46, 186, 119))
                        {
                            listBox1.Visible = false;
                            cbTypeRecipient.Items.Clear();

                            Client cl = GetClientFromString(listBox1.SelectedItem.ToString());
                            
                            string separator = "-> ";
                            int separatorIndex = listBox1.SelectedItem.ToString().IndexOf(separator);
                            string nameCompany = listBox1.SelectedItem.ToString().Substring(separatorIndex + separator.Length).TrimStart();

                            txtNumberRecipient.Text = cl.NumberPhone;
                            imgAddOrgaRecipient.Visible = true;
                            for (int i = 0; i < cl.Companies.Count; i++)
                            {
                                cbTypeRecipient.Items.Add(cl.Companies[i].Name);
                            }
                            cbTypeRecipient.Items.Add("Приватна особа");
                            int index = cbTypeRecipient.FindStringExact(nameCompany);
                            cbTypeRecipient.SelectedIndex = index;

                            txtFullNameRecipient.Text = cl.ToString();
                            txtCityRecipient.Text = cl.City;
                            txtLastNumberStockRecipient.Text = cl.LastNumberStock.ToString();

                            cbTypeRecipient.Visible = true;
                            imgAddOrgaRecipient.Visible = true;
                            txtFullNameRecipient.Visible = true;
                            txtCityRecipient.Visible = true;
                            txtLastNumberStockRecipient.Visible = true;
                            txtFullNameRecipient.Focus();
                            txtFullNameRecipient.SelectionStart = txtFullNameRecipient.Text.Length;
                        }
                        //клиент отправитель - в базе есть
                        if (panelSender.BorderColor == Color.FromArgb(46, 186, 119))
                        {
                            listBox1.Visible = false;
                            cbTypeSender.Items.Clear();

                            Client cl = GetClientFromString(listBox1.SelectedItem.ToString());

                            string separator = "-> ";
                            int separatorIndex = listBox1.SelectedItem.ToString().IndexOf(separator);
                            string nameCompany = listBox1.SelectedItem.ToString().Substring(separatorIndex + separator.Length).TrimStart();

                            txtNumberSender.Text = cl.NumberPhone;
                            imgAddOrgaSender.Visible = true;
                            for (int i = 0; i < cl.Companies.Count; i++)
                            {
                                cbTypeSender.Items.Add(cl.Companies[i].Name);
                            }
                            cbTypeSender.Items.Add("Приватна особа");
                            int index = cbTypeSender.FindStringExact(nameCompany);
                            cbTypeSender.SelectedIndex = index;

                            txtFullNameSender.Text = cl.ToString();
                            cbTypeSender.Visible = true;
                            txtFullNameSender.Visible = true;
                            txtFullNameSender.Focus();
                            txtFullNameSender.SelectionStart = txtFullNameSender.Text.Length;
                        }

                    }
                    else
                    {
                        //клиент отправитель - в базе не было
                        if (panelSender.BorderColor == Color.FromArgb(46, 186, 119))
                        {
                            listBox1.Visible = false;
                            cbTypeSender.Items.Clear();
                            cbTypeSender.Items.Add("Приватна особа");
                            cbTypeSender.SelectedIndex = 0;
                            cbTypeSender.Visible = true;
                            txtFullNameSender.Text = string.Empty;
                            txtFullNameSender.Text = string.Empty;
                            txtFullNameSender.Visible = true;
                            imgAddOrgaSender.Visible = true;
                            cbTypeSender.Focus();
                        }
                        //клиент получатель - в базе не было
                        if (panelRecipient.BorderColor == Color.FromArgb(46, 186, 119))
                        {
                            listBox1.Visible = false;
                            cbTypeRecipient.Items.Clear();
                            cbTypeRecipient.Items.Add("Приватна особа");
                            cbTypeRecipient.SelectedIndex = 0;
                            cbTypeRecipient.Visible = true;
                            imgAddOrgaRecipient.Visible = true;
                            txtFullNameRecipient.Text = string.Empty;
                            txtFullNameRecipient.Visible = true;
                            txtCityRecipient.Text = string.Empty;
                            txtCityRecipient.Visible = true;
                            txtLastNumberStockRecipient.Text = string.Empty;
                            txtLastNumberStockRecipient.Visible = true;
                            cbTypeRecipient.Focus();
                        }
                    }
                    
                    
                }
            }
        }
        private Client GetClientFromString(string informatiomStringClient)
        {
            string strClient = listBox1.SelectedItem.ToString();
            string[] words = strClient.Split(' ');
            string fullNameClient = string.Join(" ", words.Take(3));
            fullNameClient = fullNameClient.Substring(0, fullNameClient.Length - 2);

            string separator = "-> ";
            int separatorIndex = listBox1.SelectedItem.ToString().IndexOf(separator);
            string nameCompany = listBox1.SelectedItem.ToString().Substring(separatorIndex + separator.Length).TrimStart();

            Client cl = clients.FirstOrDefault(p =>
                p.ToString() == fullNameClient && p.Companies.Any(c => c.Name == nameCompany));

            if (cl == null)
                cl = clients.FirstOrDefault(p => p.ToString() == fullNameClient);
            return cl;
        }
        private void txtNumberRecipient_TextChanged(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            imgAddOrgaRecipient.Visible = false;
            listBox1.Items.Clear();
            clients.Clear();
            Generel_TextChanged(sender, e);
            if (IsCorrectNumber((Guna2TextBox)sender))
            {
                FillListBox((Guna2TextBox)sender);
                listBox1.Height = listBox1.PreferredHeight;
                panelRecipient.Controls.Add(listBox1);
                listBox1.Location = new Point(txtNumberRecipient.Location.X, txtNumberRecipient.Location.Y + 38);
                listBox1.Visible = true;
            }
            else
            {
                cbTypeRecipient.Visible = false;
                txtFullNameRecipient.Visible = false;
                txtCityRecipient.Visible = false;
                txtLastNumberStockRecipient.Visible = false;
            }
        }

        private void imgAddOrga_Click(object sender, EventArgs e)
        {
            AddCompany form = new AddCompany();
            MainForm.BlurBackground(form);
            Company company = form.SelectedCompany;
            // if null
            //добавление компании отправителя
            if (company != null)
            {
                if (panelSender.BorderColor == Color.FromArgb(46, 186, 119))
                {
                    if (cbTypeSender.Items.Contains(company.Name))
                    {
                        int index = cbTypeSender.Items.IndexOf(company.Name);
                        cbTypeSender.SelectedIndex = index;
                    }
                    else
                    {
                        cbTypeSender.Items.Add(company.Name);
                        int index = cbTypeSender.Items.Count - 1;
                        cbTypeSender.SelectedIndex = index;
                    }
                }
                //добавление компании получателя
                else if (panelRecipient.BorderColor == Color.FromArgb(46, 186, 119))
                {
                    if (cbTypeRecipient.Items.Contains(company.Name))
                    {
                        int index = cbTypeRecipient.Items.IndexOf(company.Name);
                        cbTypeRecipient.SelectedIndex = index;
                    }
                    else
                    {
                        cbTypeRecipient.Items.Add(company.Name);
                        int index = cbTypeRecipient.Items.Count - 1;
                        cbTypeRecipient.SelectedIndex = index;
                    }
                }
            }
            
        }
    }
}
