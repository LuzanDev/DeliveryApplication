using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public Visit(string numberVisit, string fullname, string typeSender, string phone, int packageID, SendForm send) : this()
        {
            if (typeSender.Equals("Приватна особа"))
            {
                imgCompanySender.Visible = false;
                txtCompany.Visible = false;

                imgSenderLogo.Location = new Point(17, 79);
                txtFullNameClient.Location = new Point(51, 73);

                imgPhoneSender.Location = new Point(17, 141);
                txtPhoneClient.Location = new Point(51, 135);
            }
            else
            {
                imgCompanySender.Location = new Point(17, 79);
                txtCompany.Location = new Point(51, 73);

                txtCompany.Enabled = false;

                imgSenderLogo.Location = new Point(17, 141);
                txtFullNameClient.Location = new Point(51, 135);

                imgPhoneSender.Location = new Point(17, 203);
                txtPhoneClient.Location = new Point(51, 197);
            }
            lblVisit.Text = numberVisit;
            txtCompany.Text = typeSender;
            txtFullNameClient.Text = fullname;
            txtPhoneClient.Text = phone;
            txtPhoneClient.Enabled = false;
            AddNewSending(packageID, send);
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            dgvGetPackage.Rows.Insert(0, new object[] { false, img, "*4911", "074A01", 0.5f.ToString().Replace(',', '.'), 100.ToString("N").Replace(',', '.') });
            dgvGetPackage.CurrentCell = dgvGetPackage.Rows[0].Cells[0];
            GetPanelCount.Location = new Point(0, 3);
            lblGetCount.Text = $"ВИДАТИ ВІДПРАВЛЕННЯ ({dgvGetPackage.Rows.Count})";
            dgvGetPackage.Location = new Point(0, GetPanelCount.Bottom);
            SetHeight(dgvGetPackage);
            if (dgvSend.Rows.Count > 0)
            {
                SendPanelCount.Location = new Point(0,dgvGetPackage.Bottom);
                dgvSend.Location = new Point(0, SendPanelCount.Bottom);
                if (dgvSellPac.Rows.Count > 0)
                {
                    SellPanelCount.Location = new Point(0, dgvSend.Bottom);
                    dgvSellPac.Location = new Point(0, SellPanelCount.Bottom);
                }
                
            }
            else if (dgvSellPac.Rows.Count > 0)
            {
                SellPanelCount.Location = new Point(0,dgvGetPackage.Bottom);
                dgvSellPac.Location = new Point(0, SellPanelCount.Bottom);
                
            }
            GetPanelCount.Visible = true;
            dgvGetPackage.Visible = true;
        }

        private void btnSellPac_Click(object sender, EventArgs e)
        {
            dgvSellPac.Rows.Insert(0, new object[] { false, "Коробка 1 кг", 10, 100.ToString("N").Replace(',', '.') });
            dgvSellPac.CurrentCell = dgvSellPac.Rows[0].Cells[0];
            SellPanelCount.Location = new Point(0,3);
            dgvSellPac.Location = new Point(0, SellPanelCount.Bottom);
            SetHeight(dgvSellPac);
            if (dgvGetPackage.Rows.Count > 0)
            {
                GetPanelCount.Location = new Point(0, dgvSellPac.Bottom);
                dgvGetPackage.Location = new Point(0, GetPanelCount.Bottom);
                if (dgvSend.Rows.Count > 0)
                {
                    SendPanelCount.Location = new Point(0,dgvGetPackage.Bottom);
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
            if (!txtPhoneClient.Enabled)
            {
                this.Hide();
                MainForm.Instance.AddControls(new SendForm(this));
            }
        }
    }
}
