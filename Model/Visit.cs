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
        public Visit()
        {
            InitializeComponent();
        }
        Image img = Image.FromFile(@"D:\arrmore.png");
        private void Visit_Load(object sender, EventArgs e)
        {
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

            //

            //for (int i = 0; i < 24; i++)
            //{
            //    dgvGetPackage.Rows.Add(new object[] { false, img, "*4911", "074A01", 0.5f.ToString().Replace(',', '.'), 100.ToString("N").Replace(',', '.') });
            //    dgvSend.Rows.Add(new object[] { false, img, "*4911", img, 0.5f.ToString().Replace(',', '.'), "Київ", 100.ToString("N").Replace(',', '.') });
            //}

            //SetHeight(dgvGetPackage);
            //SetHeight(dgvSend);
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
            dgvSend.Rows.Insert(0, new object[] { false, img, "*4911", img, 0.5f.ToString().Replace(',', '.'), "Київ", 100.ToString("N").Replace(',', '.') });
            dgvSend.CurrentCell = dgvSend.Rows[0].Cells[0];
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
    }
}
