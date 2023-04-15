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
    public partial class StartImage : Form
    {
        public StartImage()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void StartImage_Load(object sender, EventArgs e)
        {
            timer.Start();
            label1.Location = new Point(5, Screen.PrimaryScreen.Bounds.Height - label1.Size.Height);
            guna2CircleButton1.Text = MainForm.CurrentEmployee.Surname[0].ToString();
            Graphics g = Graphics.FromImage(guna2PictureBox1.Image);
            SolidBrush brush = new SolidBrush(Color.White);
            g.DrawString($"{MainForm.CurrentEmployee.Name}, вітаємо!\nБажаємо Вам гарного робочого дня.", new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204))), brush, new Point(98, 170));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MainForm.StartDateWork = DateTime.Now.ToString("dd-MM-yy") + $" / {label1.Text}";
            MainForm main = new MainForm();
            this.Hide();
            main.Show();
            main.AddControls(new ControlMenu());
        }
    }
}
