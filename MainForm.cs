using System;
using System.Drawing;
using System.Windows.Forms;

namespace DeliveryApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        string currentDate = DateTime.Now.ToString("dd-MM-yy / HH:mm:ss").Replace('.','/');
       

        private void MainForm_Load(object sender, EventArgs e)
        {
            int padding = 16;
            int workSize = (this.Width - padding * 5);
            int widthCvadrat = guna2Button3.Height;
            int width = (workSize - (widthCvadrat * 2)) / 2;
            guna2GradientButton1.Width = width;
            guna2Button2.Width = width;
            guna2Button3.Width = widthCvadrat;
            guna2Button4.Width = widthCvadrat;

            guna2GradientButton1.Location = new Point(padding, padding);
            guna2Button2.Location = new Point(padding * 2 + width, padding);
            guna2Button3.Location = new Point(padding * 3 + width * 2, padding);
            guna2Button4.Location = new Point(padding * 4 + width * 2 + widthCvadrat, padding);
            guna2Button6.Text = "Зміна "+ currentDate;
            

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
