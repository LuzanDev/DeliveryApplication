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
    public partial class AddPackagingForm : Form
    {
        public AddPackagingForm()
        {
            InitializeComponent();
        }

        private void AddPackagingForm_Load(object sender, EventArgs e)
        {
            // создание столбца с флажками
            //DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            //checkBoxColumn.Name = "checkBox";
            //checkBoxColumn.Width = 30;
            //dataGridView1.Columns.Add(checkBoxColumn);

            //// создание столбца с именем товара
            //DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            //nameColumn.Name = "nameColumn";
            //nameColumn.Width = 440;
            //dataGridView1.Columns.Add(nameColumn);

            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //imageColumn.Name = "imageColumn";
            //imageColumn.Width = 15;
            //dataGridView1.Columns.Add(imageColumn);
            //// создание столбца с количеством
            //DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            //quantityColumn.Name = "quantityColumn";
            //quantityColumn.Width = 30;
            //dataGridView1.Columns.Add(quantityColumn);

            //DataGridViewImageColumn imageColumn1 = new DataGridViewImageColumn();
            //imageColumn1.Name = "imageColumn1";
            //imageColumn1.Width = 15;
            //dataGridView1.Columns.Add(imageColumn1);
            //// создание столбца с ценой
            //DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            //priceColumn.Name = "priceColumn";
            //priceColumn.Width = 242;
            //dataGridView1.Columns.Add(priceColumn);

            Image image1 = Image.FromFile(@"D:\arrmore.png");
            Image image = Image.FromFile(@"D:\arrdown.png");
            // добавление строк в DataGridView
            dataGridView1.Rows.Add(new object[] { false, "Коробка (30кг) подовжена", image, 1, image1, 70.00 });
            dataGridView1.Rows.Add(new object[] { false, "Коробка (20кг)", image, 10, image1, 440.00 });
            dataGridView1.Rows.Add(new object[] { false, "Ущільнювання паперу", image, 77, image1, 1200.00 });
            //dataGridView1.Rows.Add(new object[] { false, "Товар 2", 5, 200 });
            //dataGridView1.Rows.Add(new object[] { false, "Товар 3", 2, 500 });
        }
    }
}
