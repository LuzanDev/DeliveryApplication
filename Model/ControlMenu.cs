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
    public partial class ControlMenu : Form
    {
        private  static ControlMenu obj;

        public static ControlMenu Instance
        {
            get { return obj; }
            //set { obj = value; }
        }

        public ControlMenu()
        {
            InitializeComponent();
            obj = this;

            int padding = 16;
            int workSize = (Screen.PrimaryScreen.Bounds.Width - padding * 4);
            //int widthSquare = btnSaleBoxes.Height;
            int width = workSize / 3;
            btnAcceptParcel.Width = width;
            btnGiveParcel.Width = width;
            btnSaleBoxes.Width = width;
            //guna2Button4.Width = widthSquare;

            btnAcceptParcel.Location = new Point(padding, padding);
            btnGiveParcel.Location = new Point(padding * 2 + width, padding);
            btnSaleBoxes.Location = new Point(padding * 3 + width * 2, padding);
            //guna2Button4.Location = new Point(padding * 4 + width * 2 + widthSquare, padding);
        }

        private void btnAcceptParcel_Click(object sender, EventArgs e)
        {
            MainForm.CountVisit++;
            MainForm.Instance.AddControls(new SendForm ());
            
        }

        private void btnGiveParcel_Click(object sender, EventArgs e)
        {
            MainForm.CountVisit++;
            MainForm.Instance.AddControls(new Visit());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MainForm.Instance.AddControls(new SendForm(1));
        }
    }
}
