using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DeliveryApplication.Model
{
    public partial class Visit : Form
    {
        private List<SendForm> sending;
        public string VisitCount
        {
            get { return lblVisit.Text; }
        }
        public string CompanyName
        {
            get { return txtCompany.Text; }
        }
        public string FullNameClient
        {
            get { return txtFullNameClient.Text; }
        }
        public string PhoneClient
        {
            get { return txtPhoneClient.Text; }
        }

        public Visit()
        {
            InitializeComponent();
            sending = new List<SendForm>();

            int padding = 10;
            int workSizeWidth = (Screen.PrimaryScreen.Bounds.Width - padding * 4);
            int width = workSizeWidth / 4;

            panelClient.Width = width;
            panelDocumentVisit.Width = width * 2;
            panelPayment.Width = width;

            panelClient.Location = new Point(padding, padding + 100);
            panelDocumentVisit.Location = new Point(padding * 2 + width, padding + 100);
            panelPayment.Location = new Point(padding * 3 + width * 3, padding + 100);

            btnFinishVisit.Location = new Point(panelLower.Width - btnFinishVisit.Width - 10, 10);
            lblVisit.Text = "Візит " + MainForm.CountVisit;
            lbParcel.BringToFront();
        }

        public Visit(string numberVisit, string fullname, string typeSender, string phone, int packageID, SendForm send) : this()
        {
            if (typeSender.Equals("Приватна особа"))
            {
                
                EnabledVisibleTextBox();
            }
            else
            {
                
                EnabledVisibleTextBox(true);
            }
            lblVisit.Text = numberVisit;
            txtCompany.Text = typeSender;
            txtFullNameClient.Text = fullname;
            txtPhoneClient.Text = phone;

            AddNewSending(packageID, send);
        }
        private void EnabledVisibleTextBox(bool isCompany = false)
        {
            imgSenderLogo.Visible = true;
            txtFullNameClient.Visible = true;
            imgPhoneSender.Visible = true;
            txtPhoneClient.Visible = true;

            if (isCompany)
            {
                imgCompanySender.Visible = true;
                txtCompany.Visible = true;

                imgCompanySender.Location = new Point(17, 79);
                txtCompany.Location = new Point(51, 73);

                imgSenderLogo.Location = new Point(17, 141);
                txtFullNameClient.Location = new Point(51, 135);

                imgPhoneSender.Location = new Point(17, 203);
                txtPhoneClient.Location = new Point(51, 197);
            }
            else
            {
                imgSenderLogo.Location = new Point(17, 79);
                txtFullNameClient.Location = new Point(51, 73);

                imgPhoneSender.Location = new Point(17, 141);
                txtPhoneClient.Location = new Point(51, 135);
            }
        }
        public void AddNewSending(int packageID, SendForm send)
        {
            sending.Add(send);
            AddSendingInTable(packageID);
        }

        private void AddSendingInTable(int packageID)
        {
            AddRowsSending(packageID);
            SendPanelCount.Location = new Point(0, 3);
            lblSendCount.Text = $"ПРИЙНЯТИ ВІДПРАВЛЕННЯ ({dgvSend.Rows.Count})";
            dgvSend.Location = new Point(0, SendPanelCount.Bottom);
            SetHeight(dgvSend);
            if (dgvGetPackage.Rows.Count > 0)
            {
                GetPanelCount.Location = new Point(0, dgvSend.Bottom);
                dgvGetPackage.Location = new Point(0, GetPanelCount.Bottom);
                if (dgvSellPac.Rows.Count > 0)
                {
                    SellPanelCount.Location = new Point(0, dgvGetPackage.Bottom);
                    dgvSellPac.Location = new Point(0, SellPanelCount.Bottom);
                }

            }
            else if (dgvSellPac.Rows.Count > 0)
            {
                SellPanelCount.Location = new Point(0, dgvSend.Bottom);
                dgvSellPac.Location = new Point(0, SellPanelCount.Bottom);
            }

            SendPanelCount.Visible = true;
            dgvSend.Visible = true;
        }

        private void AddRowsSending(int packageID)
        {
            string qry = $"SELECT * FROM PackageDocument WHERE PDID = '{packageID}'";
            DataTable dt = DataBaseControl.GetData(qry);
            string weight = CalcMoreWeight(dt.Rows[0]["PDWeight"].ToString(),
                dt.Rows[0]["PDVolumeWeight"].ToString());
            float price;
            if (!(bool.Parse(dt.Rows[0]["PDFormPayCash"].ToString())) || !(bool.Parse(dt.Rows[0]["PDPayerSender"].ToString())))
            {
                price = 0;
            }
            else
            {
                price = float.Parse(dt.Rows[0]["PDPriceDelivery"].ToString());
            }
            dgvSend.Rows.Insert(0, new object[] { false, img, dt.Rows[0]["PDID"].ToString(), weight, dt.Rows[0]["PDCityRecipient"], price.ToString("N").Replace(',', '.') });
            if (price > 0.0f)
            {
                DataGridViewCell cell = dgvSend.Rows[0].Cells[5];
                cell.Style.ForeColor = Color.FromArgb(158, 4, 4);
                cell.Style.SelectionForeColor = Color.FromArgb(158, 4, 4);
            }

            dgvSend.CurrentCell = dgvSend.Rows[0].Cells[0];
        }

        private string CalcMoreWeight(string weight, string volumeWeight)
        {
            weight = weight.Replace('.', ',');
            volumeWeight = volumeWeight.Replace('.', ',');
            if (float.Parse(weight) >= float.Parse(volumeWeight))
            {
                return weight.Replace(',', '.') + " факт.";
            }
            else
            {
                return volumeWeight.Replace(',', '.') + " об'єм";
            }
        }

        Image img = Image.FromFile(@"D:\arrmore.png");
        private void Visit_Load(object sender, EventArgs e)
        {

        }


        private void SetHeight(Guna2DataGridView dataGridView)
        {
            int rowCount = dataGridView.Rows.Count;
            int rowHeight = dataGridView.RowTemplate.Height;
            int headerHeight = dataGridView.ColumnHeadersVisible ? dataGridView.ColumnHeadersHeight : 0;

            int desiredHeight = (rowCount * rowHeight) + headerHeight;

            dataGridView.Height = desiredHeight;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSellPac_Click(object sender, EventArgs e)
        {
            dgvSellPac.Rows.Insert(0, new object[] { false, "Коробка 1 кг", 10, 100.ToString("N").Replace(',', '.') });
            dgvSellPac.CurrentCell = dgvSellPac.Rows[0].Cells[0];
            SellPanelCount.Location = new Point(0, 3);
            dgvSellPac.Location = new Point(0, SellPanelCount.Bottom);
            SetHeight(dgvSellPac);
            if (dgvGetPackage.Rows.Count > 0)
            {
                GetPanelCount.Location = new Point(0, dgvSellPac.Bottom);
                dgvGetPackage.Location = new Point(0, GetPanelCount.Bottom);
                if (dgvSend.Rows.Count > 0)
                {
                    SendPanelCount.Location = new Point(0, dgvGetPackage.Bottom);
                    dgvSend.Location = new Point(0, SendPanelCount.Bottom);
                }

            }
            else if (dgvSend.Rows.Count > 0)
            {
                SendPanelCount.Location = new Point(0, dgvSellPac.Bottom);
                dgvSend.Location = new Point(0, SendPanelCount.Bottom);

            }
            SellPanelCount.Visible = true;
            dgvSellPac.Visible = true;
        }

        private void dgvSend_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSend.Rows[e.RowIndex];

                int sendingID = Convert.ToInt32(row.Cells[2].Value);
                SendForm form = sending.SingleOrDefault(s => s.SendingID.Equals(sendingID));
                form.ActiveVisit = this;
                form.Editing += Editing;
                this.Hide();
                MainForm.Instance.AddControls(form);

            }
        }

        private void Editing(int sendingID)
        {
            foreach (DataGridViewRow row in dgvSend.Rows)
            {
                if (Convert.ToInt32(row.Cells[2].Value) == sendingID)
                {
                    dgvSend.Rows.Remove(row);
                    AddRowsSending(sendingID);
                    break;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtPhoneClient.Visible)
            {
                this.Hide();
                MainForm.Instance.AddControls(new SendForm(this));
            }
            else
            {
                this.Hide();
                MainForm.Instance.AddControls(new SendForm());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm.Instance.AddControls(ControlMenu.Instance);
        }

        private void txtAddElementInVisit_TextChanged(object sender, EventArgs e)
        {
            lblNoParcel.Visible = false;
            lbParcel.Visible = false;
            lbParcel.Items.Clear();
            timer.Stop();
            timer.Start();
            List<string> list = new List<string>();
            foreach (DataRow row in Service.CurrentStockPackage.Rows)
            {
                //Поиск по ID посылки
                if (row["PDID"].ToString() == txtAddElementInVisit.Text)
                {
                    if (row["PDCategoryRecipient"].ToString().Equals("Приватна особа"))
                    {
                        lbParcel.Items.Add(row["PDFullNameRecipient"].ToString() + " -> " + row["PDID"].ToString());
                    }
                    else
                    {
                        lbParcel.Items.Add(row["PDCategoryRecipient"].ToString() + " -> " + row["PDID"].ToString());
                    }
                }
                //Поиск по номеру телефона
                if (txtAddElementInVisit.Text.Trim().Length == 10 && txtAddElementInVisit.Text.All(char.IsDigit))
                {
                    string correctNumber = Service.CorrectNumber(txtAddElementInVisit.Text);
                    if (row["PDNumberPhoneRecipient"].ToString() == correctNumber)
                    {
                        if (!(list.Contains(row["PDCategoryRecipient"].ToString(), StringComparer.OrdinalIgnoreCase)))
                        {
                            list.Add(row["PDCategoryRecipient"].ToString());
                        }


                    }
                }
                //Поиск по вставке
                if (txtAddElementInVisit.Text.Length == 19 && txtAddElementInVisit.Text.Substring(0, 5).Equals("+38 ("))
                {
                    if (row["PDNumberPhoneRecipient"].ToString() == txtAddElementInVisit.Text)
                    {
                        if (!(list.Contains(row["PDCategoryRecipient"].ToString(), StringComparer.OrdinalIgnoreCase)))
                        {
                            list.Add(row["PDCategoryRecipient"].ToString());
                        }
                    }
                }
            }
            if (list.Count > 0 && txtAddElementInVisit.Text.Length >= 10)
            {
                string number = txtAddElementInVisit.Text.Substring(0, 5).Equals("+38 (") ? txtAddElementInVisit.Text : Service.CorrectNumber(txtAddElementInVisit.Text);
                List<DeliveryNote>[] category = new List<DeliveryNote>[list.Count];
                for (int i = 0; i < category.Length; i++)
                {
                    category[i] = new List<DeliveryNote>();
                }


                for (int i = 0; i < list.Count; i++)
                {
                    foreach (DataRow row in Service.CurrentStockPackage.Rows)
                    {
                        if (row["PDNumberPhoneRecipient"].ToString() == number && row["PDCategoryRecipient"].ToString() == list[i])
                        {
                            DeliveryNote note = new DeliveryNote
                            {
                                ID = Convert.ToInt32(row["PDID"]),
                                FullNameClient = row["PDFullNameRecipient"].ToString(),
                                CategoryName = row["PDCategoryRecipient"].ToString()
                            };

                            category[i].Add(note);
                        }
                    }
                }

                for (int i = 0; i < category.Length; i++)
                {
                    lbParcel.Items.Add(category[i].First().CategoryName + "-> " + category[i].First().FullNameClient + $"\t[{category[i].Count}]");
                }
            }


            if (lbParcel.Items.Count > 0)
            {
                lbParcel.Height = lbParcel.PreferredHeight;
                lbParcel.Visible = true;
            }

            list.Clear();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (txtAddElementInVisit.Text.Trim().Length != 0 && lbParcel.Items.Count == 0)
            {
                lblNoParcel.Visible = true;
            }
        }

        private void txtAddElementInVisit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && lbParcel.Items.Count > 0)
            {
                lbParcel.Focus();
                lbParcel.SelectedIndex = 0;
            }
        }

        private void lbParcel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && lbParcel.SelectedIndex == 0)
            {
                txtAddElementInVisit.Focus();
            }
            if (e.KeyCode == Keys.Enter && lbParcel.SelectedItem != null)
            {
                
                string client = lbParcel.SelectedItem.ToString();
                string[] information = client.Split(new[] { "-> ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                if (information.Length == 2)
                {
                    int parcelID = Convert.ToInt32(information[1]);
                    DataRow row = Service.GetRowByUsingID(parcelID);
                    if (row != null)
                    {
                        AddReceivingInTable(row);
                        SetClientInfo(row);
                        txtAddElementInVisit.Text = string.Empty;
                        txtAddElementInVisit.Focus();
                    }
                    
                }
                else
                {
                    string typeClient = information[0];
                    string fullNameClient = information[1];
                    string countParcel = information[2].Replace("[", "").Replace("]", "");
                }

                



            }
        }

        private void SetClientInfo(DataRow row)
        {
            if (!txtFullNameClient.Visible && !txtPhoneClient.Visible)
            {
                txtCompany.Text = row["PDCategoryRecipient"].ToString();
                txtFullNameClient.Text = row["PDFullNameRecipient"].ToString();
                txtPhoneClient.Text = row["PDNumberPhoneRecipient"].ToString();

                if (row["PDCategoryRecipient"].ToString().Equals("Приватна особа"))
                    EnabledVisibleTextBox();
                else
                    EnabledVisibleTextBox(true);
            }
            else
            {
                if (!txtPhoneClient.Text.Equals(row["PDNumberPhoneRecipient"].ToString()) &&
                    !txtFullNameClient.Text.Equals(row["PDFullNameRecipient"].ToString()))
                {
                    panelWarning.Location = new Point(0, 62 + txtPhoneClient.Location.Y);
                    lblWarning.Location = new Point((panelWarning.Width - lblWarning.Width) / 2, 5);
                    panelWarning.Visible = true;
                }
            }

        }
        private bool Available(int parcelID)
        {
            bool result = false;
            foreach (var item in dgv)
            {

            }

            return result;
        }
        private void AddReceivingInTable(DataRow row)
        {
            string weight = CalcMoreWeight(row["PDWeight"].ToString(),
                row["PDVolumeWeight"].ToString());
            float price;
            if (bool.Parse(row["PDPaid"].ToString()))
            {
                price = 0;
            }
            else
            {
                price = float.Parse(row["PDPriceDelivery"].ToString());
            }
            dgvGetPackage.Rows.Insert(0, new object[] { false, img, row["PDID"].ToString(), row["PDLocation"].ToString(), weight, price.ToString("N").Replace(',', '.') });
            dgvGetPackage.CurrentCell = dgvGetPackage.Rows[0].Cells[0];
            GetPanelCount.Location = new Point(0, 3);
            lblGetCount.Text = $"ВИДАТИ ВІДПРАВЛЕННЯ ({dgvGetPackage.Rows.Count})";
            dgvGetPackage.Location = new Point(0, GetPanelCount.Bottom);
            SetHeight(dgvGetPackage);
            if (dgvSend.Rows.Count > 0)
            {
                SendPanelCount.Location = new Point(0, dgvGetPackage.Bottom);
                dgvSend.Location = new Point(0, SendPanelCount.Bottom);
                if (dgvSellPac.Rows.Count > 0)
                {
                    SellPanelCount.Location = new Point(0, dgvSend.Bottom);
                    dgvSellPac.Location = new Point(0, SellPanelCount.Bottom);
                }

            }
            else if (dgvSellPac.Rows.Count > 0)
            {
                SellPanelCount.Location = new Point(0, dgvGetPackage.Bottom);
                dgvSellPac.Location = new Point(0, SellPanelCount.Bottom);

            }
            GetPanelCount.Visible = true;
            dgvGetPackage.Visible = true;
        }

        
    }
}