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
            AddControls(new ControlMenu());
            guna2Button6.Text = "Зміна "+ currentDate;
            guna2CircleButton1.Text = StartWorkForm.CurrentEmployee.Surname[0].ToString();
            obj = this;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
