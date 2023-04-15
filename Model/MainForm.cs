using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace DeliveryApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();
            obj = this;
            guna2Button6.Text = "Зміна " + startDateWork;
            if (CurrentEmployee != null)
                guna2CircleButton1.Text = CurrentEmployee.Surname[0].ToString();
        }

        private static string startDateWork;
        public static string StartDateWork
        {
            get { return startDateWork; }
            set { startDateWork = value; }
        }


        private static Employee currentEmployee;
        public static Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; }
        }

        private static MainForm obj;
        public static MainForm Instance
        {
            get
            {
                if (obj == null)
                {
                    obj = new MainForm();
                }
                return obj;
            }
        }


        public void AddControls(Form form)
        {
            centerPanel.Controls.Clear();
            form.TopLevel = false;
            centerPanel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //label1.Location = new Point(5, Screen.PrimaryScreen.Bounds.Height - label1.Size.Height);



        }

        private void timer_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
