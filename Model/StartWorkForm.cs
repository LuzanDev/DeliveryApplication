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
    public partial class StartWorkForm : Form
    {
        public StartWorkForm()
        {
            InitializeComponent();
        }

        private static Employee currentEmployee;
        public static Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; }
        }


        private void StartWorkForm_Load(object sender, EventArgs e)
        {
            timer.Start();
            Graphics g = Graphics.FromImage(guna2PictureBox1.Image);
            SolidBrush brush = new SolidBrush(Color.White);
            g.DrawString($"{currentEmployee.Name}, вітаємо!\nБажаємо Вам гарного робочого дня.", new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204))), brush, new Point(98, 170));
            guna2CircleButton1.Text = currentEmployee.Surname[0].ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            this.Hide();
            main.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
