using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DeliveryApplication.Model
{
    public partial class SendForm : Form
    {
        private List<Client> clients;
        private List<Stock> stocks;
        private List<DataGridViewRow> currentPackaging;
        public List<DataGridViewRow> CurrentPackaging
        {
            get { return currentPackaging; }
        }

        public static SendForm Obj { get; private set; }

        public SendForm()
        {
            InitializeComponent();
            Obj = this;
        }


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

            //txtVolumeWeight.Location = new Point((VolumeWeightPanel.Width - txtVolumeWeight.Width) / 2, 11);
            //imgBox.Location = new Point(txtVolumeWeight.Location.X - 24, 11);
            //txtValue.Location = new Point(txtVolumeWeight.Location.X + 116, 12);


            lblWidthError.Location = new Point(txtWidth.Location.X, txtWidth.Location.Y + 36);
            lblLengthError.Location = new Point(txtLength.Location.X, txtLength.Location.Y + 36);
            lblHeightError.Location = new Point(txtHeight.Location.X, txtHeight.Location.Y + 36);
            clients = new List<Client>();
            stocks = new List<Stock>();
            listBox1.Size = new Size(txtNumberSender.Width, 20);
            panelSender.Focus();
            txtNumberSender.Focus();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MainForm.Instance.AddControls(new ControlMenu());
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            txtDesPackage.BorderColor = Color.FromArgb(213, 218, 223);
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (sender as Guna.UI2.WinForms.Guna2TextBox).Text.IndexOf(',') > -1)
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
                listBox1.Location = new Point(txtNumberSender.Location.X, txtNumberSender.Location.Y + 38);
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
                City.city_Name, Stock.StockNumber, Stock.StockAddress, Stock.StockSityID 
                FROM Client
                LEFT OUTER JOIN Stock ON Client.cl_LastNumberStock = Stock.StockID
                JOIN City ON Stock.StockSityID = City.city_Id
                WHERE cl_NumberPhone = '{text.Text}'";
            //LEFT OUTER JOIN City ON Client.cl_City = City.city_Id
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
                LastNumberStock = "Відділення №" + row["StockNumber"].ToString() + ": " + row["StockAddress"].ToString()
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
                            FillListStockByCity();
                            cbTypeRecipient.Visible = true;
                            imgAddOrgaRecipient.Visible = true;
                            imgListStocks.Visible = true;
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
                            imgListStocks.Visible = true;
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
            imgListStocks.Visible = false;
            lbStocks.Visible = false;
            lbStocks.Items.Clear();
            stocks.Clear();
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
            AddCompanyForm form = new AddCompanyForm();
            MainForm.BlurBackground(form);
            Company company = form.SelectedCompany;

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
        private void txtCityRecipient_TextChanged(object sender, EventArgs e)
        {
            txtCityRecipient.BorderColor = Color.FromArgb(213, 218, 223);
            txtLastNumberStockRecipient.Text = string.Empty;
            stocks.Clear();
            lbStocks.Items.Clear();
        }

        private void txtLastNumberStockRecipient_TextChanged(object sender, EventArgs e)
        {
            lbStocks.Visible = false;
            lbStocks.Items.Clear();
            int number;
            if (int.TryParse(txtLastNumberStockRecipient.Text, out number))
            {
                for (int i = 0; i < stocks.Count; i++)
                {
                    if (stocks[i].Number.Equals(number))
                    {
                        lbStocks.Items.Add(stocks[i]);
                    }
                }
            }
            if (lbStocks.Items.Count > 0)
            {
                lbStocks.Visible = true;
            }

        }

        private void txtCityRecipient_Leave(object sender, EventArgs e)
        {
            txtCityRecipient.Text = txtCityRecipient.Text.Trim();
            stocks.Clear();
            FillListStockByCity();
        }


        private void FillListStockByCity()
        {
            if (txtCityRecipient.AutoCompleteCustomSource.Contains(txtCityRecipient.Text))
            {
                int cityID = DataBaseControl.GetCityIDByName(txtCityRecipient.Text);
                string qry = $@"SELECT Stock.StockID, Stock.StockNumber, Stock.StockAddress, City.city_Name 
                         FROM Stock 
                         JOIN City ON Stock.StockSityID = City.city_Id 
                         WHERE StockSityID = {cityID} ORDER BY StockNumber ASC";
                DataTable dt = DataBaseControl.GetData(qry);
                foreach (DataRow row in dt.Rows)
                {
                    Stock stock = new Stock
                    {
                        ID = Convert.ToInt32(row["StockID"]),
                        Number = Convert.ToInt32(row["StockNumber"]),
                        Address = row["StockAddress"].ToString(),
                        City = row["city_Name"].ToString()
                    };
                    stocks.Add(stock);
                }
            }
            else
            {
                txtCityRecipient.BorderColor = Color.Red;
            }
        }
        private void imgListStocks_Click(object sender, EventArgs e)
        {
            lbStocks.Items.Clear();
            foreach (Stock stock in stocks)
            {
                lbStocks.Items.Add(stock);
            }
            lbStocks.Visible = true;

            if (lbStocks.Items.Count > 0)
            {
                lbStocks.Focus();
                lbStocks.SelectedIndex = 0;
            }

        }

        private void txtLastNumberStockRecipient_Leave(object sender, EventArgs e)
        {
            if (lbStocks.Items.Count > 0)
            {
                lbStocks.TabStop = true;
                lbStocks.Focus();
                lbStocks.SelectedIndex = 0;
            }
            else
            {
                lbStocks.TabStop = false;
                //panelPayment.Focus();
            }
        }

        private void txtLastNumberStockRecipient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && lbStocks.Items.Count > 0)
            {
                lbStocks.Focus();
                lbStocks.SelectedIndex = 0;
                e.Handled = true;
            }
        }

        private void lbStocks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lbStocks.SelectedItem != null)
            {
                txtLastNumberStockRecipient.Text = lbStocks.SelectedItem.ToString();
                panelPayment.Focus();
            }
        }

        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            if (currentPackaging == null)
            {
                currentPackaging = new List<DataGridViewRow>();
                AddPackagingForm form = new AddPackagingForm(txtDesPackage.Text);
                form.SaveTable += Form_SaveTable;
                MainForm.BlurBackground(form);
            }
            else
            {
                AddPackagingForm form = new AddPackagingForm(txtDesPackage.Text, true);
                form.SaveTable += Form_SaveTable;
                MainForm.BlurBackground(form);
            }

        }

        private void Form_SaveTable(object sender, EventArgs e)
        {
            currentPackaging.Clear();
            foreach (DataGridViewRow row in ((AddPackagingForm)sender).MainTable.Rows)
            {
                DataGridViewRow newRow = (DataGridViewRow)row.Clone();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = row.Cells[i].Value;
                }
                currentPackaging.Add(newRow);
            }
            ResetDimensionDefault();
            if (((AddPackagingForm)sender).CurrentMaterials.Count > 1)
            {
                btnAddPackage.Text = $"Всього: {((AddPackagingForm)sender).CurrentMaterials.Count} пакувань";
                foreach (PackagingMaterial mat in ((AddPackagingForm)sender).CurrentMaterials)
                {
                    if (mat is Container box)
                    {
                        SetBoxDimensions(box);
                        break;
                    }
                }
            }
            else if (((AddPackagingForm)sender).CurrentMaterials.Count == 1)
            {
                if (((AddPackagingForm)sender).CurrentMaterials[0] is Container box)
                {
                    SetBoxDimensions(box);
                    btnAddPackage.Text = $"1x {box.Name}";
                }
                else
                {
                    btnAddPackage.Text = $"1x {((AddPackagingForm)sender).CurrentMaterials[0].Name} {currentPackaging[0].Cells[3].Value.ToString()} м";
                }
            }
            ShowVolumeWeight();
        }
        #region Установка габаритов упаковки (если она есть)
        private void SetBoxDimensions(Container box)
        {
            txtWidth.Text = box.Width.ToString();
            txtWidth.Enabled = false;
            txtLength.Text = box.Length.ToString();
            txtLength.Enabled = false;
            txtHeight.Text = box.Height.ToString();
            txtHeight.Enabled = false;
        }
        private void ResetDimensionDefault()
        {
            btnAddPackage.Text = "Додати пакування";
            txtWidth.Enabled = true;
            txtLength.Enabled = true;
            txtHeight.Enabled = true;
        }
        #endregion
        private void ShowVolumeWeight()
        {
            VolumeWeightPanel.Visible = false;
            txtValue.Visible = false;
            float width;
            float height;
            float length;

            if (float.TryParse(txtWidth.Text, out width)
                && float.TryParse(txtLength.Text, out length)
                && float.TryParse(txtHeight.Text, out height))
            {
                float volumeWeight = (width * height * length) / 4000;

                if (volumeWeight > 1000.00f)
                {
                    txtValue.Text = $"> 1000 кг";
                }
                else
                {
                    txtValue.Text = $"{volumeWeight.ToString("F2").Replace(',', '.')} кг";
                }

                VolumeWeightPanel.Width = imgBox.Width + txtValue.Width + txtVolumeWeight.Width;
                VolumeWeightPanel.Location = new Point((panelPackageInfo.Width - VolumeWeightPanel.Width) / 2, 373);
                VolumeWeightPanel.Visible = true;
                txtValue.Visible = true;
            }
        }

        private void txtDimensions_TextChanged(object sender, EventArgs e)
        {
            txtWidth.BorderColor = Color.FromArgb(213, 218, 223);
            txtLength.BorderColor = Color.FromArgb(213, 218, 223);
            txtHeight.BorderColor = Color.FromArgb(213, 218, 223);

            lblWidthError.Visible = false;
            lblLengthError.Visible = false;
            lblHeightError.Visible = false;

            float width;
            float length;
            float height;

            if (float.TryParse(txtWidth.Text, out width))
            {
                if (width > 300.00f)
                {
                    txtWidth.BorderColor = Color.Red;
                    lblWidthError.Visible = true;
                }
            }
            if (float.TryParse(txtLength.Text, out length))
            {
                if (length > 300.00f)
                {
                    txtLength.BorderColor = Color.Red;
                    lblLengthError.Visible = true;
                }
            }
            if (float.TryParse(txtHeight.Text, out height))
            {
                if (height > 170.00f)
                {
                    txtHeight.BorderColor = Color.Red;
                    lblHeightError.Visible = true;
                }
            }
            ShowVolumeWeight();
        }
        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            txtWeight.BorderColor = Color.FromArgb(213, 218, 223);
            lblWeightError.Visible = false;
            float weight;

            if (float.TryParse(txtWeight.Text, out weight))
            {
                if (weight > 1000.00f)
                {
                    txtWeight.BorderColor = Color.Red;
                    lblWeightError.Visible = true;
                }
            }
        }
        private void PriceСalculation()
        {
            if (PackageIsCorrect())
            {
                Hashtable ht = new Hashtable();
                Location locality = GetLocal();

                float weight = (float.Parse(txtWeight.Text) >= float.Parse(txtValue.Text.Replace(" кг", string.Empty).Replace('.', ',')))
                    ? float.Parse(txtWeight.Text) :
                    float.Parse(txtValue.Text.Replace(" кг", string.Empty).Replace('.', ','));
                ParcelCategory category = GetCategory(weight);
                int priceDelivery = Service.CalcShippingCost(category, locality, weight, cbTypeDelivery.SelectedIndex);

                int insurance = 0;
                if (float.Parse(txtPriceParcel.Text) > 500.00f)
                {
                    //сумма процента от оценки
                    insurance = CalcPercent();
                }
                int packingPrice = CalcPackingPrice();
                FillHashTable(ht, locality,priceDelivery, insurance, packingPrice);
                ShowPriceDelivery(ht, priceDelivery + insurance + packingPrice);
            }


        }

        private void ShowPriceDelivery(Hashtable ht, int mainSum)
        {
            Label[] labelsName = { lblName1, lblName2, lblName3 }; 
            Label[] labelsPrice = { lblPrice1, lblPrice2, lblPrice3 };
            int i = 0;
            foreach (DictionaryEntry entry in ht)
            {
                labelsName[i].Text = entry.Key.ToString();
                labelsPrice[i].Text = $"₴ {Convert.ToInt32(entry.Value).ToString("N").Replace(',', '.')}";
                labelsName[i].Visible = true;
                labelsPrice[i].Visible = true;
                i++;
            }
            lblPriceMain.Text = $"₴ {mainSum.ToString("N").Replace(',','.')}";
            lblPriceMain.Visible = true;
        }

        private void FillHashTable(Hashtable ht, Location locality, int priceDelivery, int insurance, int packingPrice)
        {
            switch (locality)
            {
                case DeliveryApplication.Location.City:
                    ht.Add("Доставка посилок по місту", priceDelivery);
                    break;
                case DeliveryApplication.Location.Ukraine:
                    ht.Add("Доставка посилок по Україні", priceDelivery);
                    break;
                case DeliveryApplication.Location.Villages:
                    ht.Add("Доставка посилок у смт або село", priceDelivery);
                    break;
            }
            if (insurance != 0)
            {
                ht.Add("Комісія від вартості", insurance);
            }
            if (packingPrice != 0)
            {
                ht.Add("Пакування відправлення", packingPrice);
            }
        }

        private int CalcPackingPrice()
        {
            int result = 0;
            foreach (var item in CurrentPackaging)
            {
                result += (int)Convert.ToDecimal(item.Cells[5].Value.ToString());
            }
            return result;
        }

        private int CalcPercent()
        {
            float price;
            float percent = 0;
            float roundedPercent = 0;
            if (float.TryParse(txtPriceParcel.Text, out price))
            {
                percent = price * 0.005f;
                
                if (percent % 1 >= 0.5)
                {
                    roundedPercent = (float)Math.Ceiling(percent);
                }
                else
                {
                    roundedPercent = (float)Math.Floor(percent);
                }
            }
            return (int)roundedPercent;
        }

        private ParcelCategory GetCategory(float weight)
        {
            if (weight <= 2.00f)
            {
                if (txtDesPackage.Text != "Документи")
                {
                    return ParcelCategory.small;
                }
                else
                {
                    return ParcelCategory.documentation;
                }
            }
            else if (weight > 2.00f && weight <= 10.00f)
            {
                return ParcelCategory.average;
            }
            else if (weight > 10.00f && weight <= 30.00f)
            {
                return ParcelCategory.big;
            }
            else
            {
                return ParcelCategory.huge;
            }
        }

        private Location GetLocal()
        {
            if (txtCityRecipient.Text == Service.SityLocation)
            {
                return DeliveryApplication.Location.City;
            }
            else if (txtCityRecipient.Text.Contains("(смт)") || txtCityRecipient.Text.Contains("(село)"))
            {
                return DeliveryApplication.Location.Villages;
            }
            else
            {
                return DeliveryApplication.Location.Ukraine;
            }
        }

        private void txtPriceParcel_TextChanged(object sender, EventArgs e)
        {
            txtPriceParcel.BorderColor = Color.FromArgb(213, 218, 223);
        }

        private bool PackageIsCorrect()
        {
            if (txtDesPackage.Text.Trim().Length < 2)
            {
                txtDesPackage.BorderColor = Color.Red;
            }
            float price;
            if (!float.TryParse(txtPriceParcel.Text, out price))
            {
                txtPriceParcel.BorderColor = Color.Red;
            }
            float weight;
            if (!float.TryParse(txtWeight.Text, out weight))
            {
                txtWeight.BorderColor = Color.Red;
            }
            float width;
            float height;
            float length;

            if (!float.TryParse(txtWidth.Text, out width))
            {
                txtWidth.BorderColor = Color.Red;
            }
            if (!float.TryParse(txtLength.Text, out length))
            {
                txtLength.BorderColor = Color.Red;
            }
            if (!float.TryParse(txtHeight.Text, out height))
            {
                txtHeight.BorderColor = Color.Red;
            }
            if (!txtCityRecipient.AutoCompleteCustomSource.Contains(txtCityRecipient.Text))
            {
                txtCityRecipient.BorderColor = Color.Red;
            }
            if (float.TryParse(txtWidth.Text, out width)
                && float.TryParse(txtLength.Text, out length)
                && float.TryParse(txtHeight.Text, out height))
            {
                float volume = (width * length * height) / 4000;
                if (volume > 1000.00f)
                {
                    txtWidth.BorderColor = Color.Red;
                    txtHeight.BorderColor = Color.Red;
                    txtLength.BorderColor = Color.Red;
                }
            }
            foreach (Control item in panelPackageInfo.Controls)
            {
                if (item is Guna2TextBox box)
                {
                    if (box.BorderColor == Color.Red)
                    {
                        return false;
                    }
                }
            }
            if (txtCityRecipient.BorderColor == Color.Red)
            {
                return false;
            }
            return true;
        }

        private void panelPayment_Enter(object sender, EventArgs e)
        {
            panel_Enter(sender,e);
            PriceСalculation();
        }

        private void panelPayment_Leave(object sender, EventArgs e)
        {
            panel_Leave(sender,e);
            HideLabelsPrice();
        }

        private void HideLabelsPrice()
        {
            lblPrice1.Visible = false;
            lblPrice2.Visible = false;
            lblPrice3.Visible = false;

            lblName1.Visible = false;
            lblName2.Visible = false;
            lblName3.Visible = false;

            lblPriceMain.Visible = false;
        }
    }
}
