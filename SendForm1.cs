using DeliveryApplication.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryApplication
{
    public partial class SendForm1 : MainForm
    {
        public SendForm1()
        {
            InitializeComponent();
        }

        private void SendForm1_Load(object sender, EventArgs e)
        {
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
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            ButtonMain.obj.Show();
            
        }
    }
}
