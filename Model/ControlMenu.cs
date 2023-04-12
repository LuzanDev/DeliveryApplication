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
        public ControlMenu()
        {
            InitializeComponent();

            int padding = 16;
            int workSize = (Screen.PrimaryScreen.Bounds.Width - padding * 5);
            int widthSquare = btnSaleBoxes.Height;
            int width = (workSize - (widthSquare * 2)) / 2;
            btnAcceptParcel.Width = width;
            btnGiveParcel.Width = width;
            btnSaleBoxes.Width = widthSquare;
            guna2Button4.Width = widthSquare;

            btnAcceptParcel.Location = new Point(padding, padding);
            btnGiveParcel.Location = new Point(padding * 2 + width, padding);
            btnSaleBoxes.Location = new Point(padding * 3 + width * 2, padding);
            guna2Button4.Location = new Point(padding * 4 + width * 2 + widthSquare, padding);
        }

        private void btnAcceptParcel_Click(object sender, EventArgs e)
        {
            //MainForm.Instance.AddControls(new SendForm ());
        }


    }
}
