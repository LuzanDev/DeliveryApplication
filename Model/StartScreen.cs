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
    public partial class StartScreen : MainForm
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(guna2PictureBox1.Image);
            SolidBrush brush = new SolidBrush(Color.White);
            g.DrawString($"{CurrentEmployee.Name}, вітаємо!\nБажаємо Вам гарного робочого дня.", new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204))), brush, new Point(98, 170));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // фиксация
            this.Hide();
            ButtonMain form = new ButtonMain();
            MainForm.StartDateWork = DateTime.Now.ToString("dd-MM-yy / HH:mm:ss").Replace('.', '/');
            form.Show();
        }
    }
}
