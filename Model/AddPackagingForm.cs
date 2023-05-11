using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DeliveryApplication.Model
{
    public partial class AddPackagingForm : Form
    {
        private readonly string description;
        private List<PackagingMaterial> materials;
        private List<PackagingMaterial> materialsForDocument;
        private List<PackagingMaterial> currentMaterials;
        public Guna2DataGridView MainTable
        {
            get { return dataGridView1; }
            private set { dataGridView1 = value; }
        }

        public event EventHandler SaveTable;
        public AddPackagingForm()
        {
            InitializeComponent();
        }

        public AddPackagingForm(string productDescription, bool table = false) : this()
        {
            description = productDescription;
            materials = Service.Materials;
            materialsForDocument = new List<PackagingMaterial>();
            currentMaterials = new List<PackagingMaterial>();
            
            FillPackagingMaterialForDoc();
            if (table)
            {
                foreach (DataGridViewRow row in SendForm.Obj.CurrentPackaging)
                {
                    dataGridView1.Rows.Add(row);
                    var mater = materials.SingleOrDefault(m => m.Name == row.Cells["dgvName"].Value.ToString());
                    currentMaterials.Add(mater);
                }
            }
        }

        private void FillPackagingMaterialForDoc()
        {
            foreach (PackagingMaterial item in materials)
            {
                if (item.Name.Equals("Коробка 0.5 кг (пласка)") || item.Name.Equals("Коробка 1 кг (пласка)"))
                {
                    materialsForDocument.Add(item);
                }
                if (item.Name.Equals("Конверт С/13") || item.Name.Equals("Конверт С/14"))
                {
                    materialsForDocument.Add(item);
                }
                if (item.Name.Equals("Конверт для документів") || item.Name.Equals("Пакет для дрібного відпраленя 0.5 кг"))
                {
                    materialsForDocument.Add(item);
                }
                if (item.Name.Equals("Пакет для дрібного відпраленя 1 кг"))
                {
                    materialsForDocument.Add(item);
                }
            }
        }

        private void txtSearchPackaging_TextChanged(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            listBox1.Items.Clear();
            listBox1.BringToFront();
            if (description != null && description.Equals("Документи"))
            {
                for (int i = 0; i < materialsForDocument.Count; i++)
                {
                    if (materialsForDocument[i].Name.ToLower().Contains(txtSearchPackaging.Text.ToLower()))
                    {
                        listBox1.Items.Add(materialsForDocument[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < materials.Count; i++)
                {
                    if (materials[i].Name.ToLower().Contains(txtSearchPackaging.Text.ToLower()))
                    {
                        listBox1.Items.Add(materials[i]);
                    }
                }
            }

            listBox1.Height = listBox1.PreferredHeight;
            if (listBox1.Height >= this.Height || listBox1.Items.Count >= 18)
            {
                listBox1.Height = this.Height - 130;
            }
            if (txtSearchPackaging.Text != "" && listBox1.Items.Count > 0)
            {
                listBox1.Visible = true;
            }


        }

        private void txtSearchPackaging_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && listBox1.Items.Count > 0)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && listBox1.SelectedIndex == 0)
            {
                txtSearchPackaging.Focus();
            }
            if (e.KeyCode == Keys.Enter && listBox1.SelectedItem != null)
            {
                if (listBox1.SelectedItem is PackagingMaterial material)
                {
                    bool attached = false;
                    //Коробка уже добавлена
                    foreach (PackagingMaterial item in currentMaterials)
                    {
                        if (item is Container)
                        {
                            attached = true;
                            break;
                        }
                    }
                    if (listBox1.SelectedItem is Container && attached)
                    {
                        guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                        guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;

                        if (guna2MessageDialog1.Show("Заборонено додавати пакування одного типу") == DialogResult.OK)
                        {
                            txtSearchPackaging.Focus();
                            txtSearchPackaging.SelectionStart = txtSearchPackaging.Text.Length;
                        }
                    }
                    else if (!(currentMaterials.Contains(material)))
                    {
                        currentMaterials.Add(material);
                        Image rightArrow = Image.FromFile(@"D:\arrmore.png");
                        Image leftArrow = Image.FromFile(@"D:\arrdown.png");

                        dataGridView1.Rows.Add(new object[] { false, material.Name, leftArrow, 1, rightArrow, material.Price });
                        listBox1.Visible = false;
                        txtSearchPackaging.Text = string.Empty;
                        txtSearchPackaging.Focus();
                    }
                    else
                    {
                        guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                        guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        if (guna2MessageDialog1.Show("Пакування вже додано") == DialogResult.OK)
                        {
                            txtSearchPackaging.Focus();
                            txtSearchPackaging.SelectionStart = txtSearchPackaging.Text.Length;
                        }
                    }
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["dgvCheck"].Index)
            {
                DataGridViewCheckBoxCell cell = dataGridView1.Rows[e.RowIndex].Cells["dgvCheck"] as DataGridViewCheckBoxCell;
                cell.Value = !(bool)cell.Value;
            }

            if (e.ColumnIndex == dataGridView1.Columns["dgvRight"].Index)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                var item = materials.SingleOrDefault(m => m.Name.Equals(row.Cells["dgvName"].Value.ToString()));
                if (item is Container)
                {
                    guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;

                    if (guna2MessageDialog1.Show("Заборонено додавати більше 1 пакування одного типу") == DialogResult.OK)
                    {
                        txtSearchPackaging.Focus();
                        txtSearchPackaging.SelectionStart = txtSearchPackaging.Text.Length;
                    }
                }
                else
                {
                    int count = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvCount"].Value);
                    decimal price = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["dgvPrice"].Value) / count;

                    dataGridView1.Rows[e.RowIndex].Cells["dgvCount"].Value = (count + 1);
                    dataGridView1.Rows[e.RowIndex].Cells["dgvPrice"].Value = price * (count + 1);
                }

            }
            if (e.ColumnIndex == dataGridView1.Columns["dgvLeft"].Index)
            {
                int count = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvCount"].Value);
                decimal price = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["dgvPrice"].Value) / count;

                if (count > 1)
                {
                    dataGridView1.Rows[e.RowIndex].Cells["dgvCount"].Value = (count - 1);
                    dataGridView1.Rows[e.RowIndex].Cells["dgvPrice"].Value = price * (count - 1);
                }
            }

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                dataGridView1.Cursor = Cursors.Hand;
            }
            else
            {
                dataGridView1.Cursor = Cursors.Default;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["dgvCount"].Index)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                int newCount = Convert.ToInt32(row.Cells["dgvCount"].Value);
                if (newCount < 1) newCount = 1;
                decimal price = (materials.SingleOrDefault(m => m.Name == row.Cells["dgvName"].Value.ToString())).Price;
                decimal newPrice = price * newCount;

                row.Cells["dgvCount"].Value = newCount;
                row.Cells["dgvPrice"].Value = newPrice;
            }
            if (e.ColumnIndex == dataGridView1.Columns["dgvCheck"].Index)
            {
                bool checkBox = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((bool)row.Cells["dgvCheck"].Value)
                    {
                        checkBox = true;
                        break;
                    }
                }
                if (checkBox)
                {
                    btnDelete.Visible = true;
                }
                else
                {
                    guna2CheckBox1.Checked = false;
                    btnDelete.Visible = false;
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            var type = materials.SingleOrDefault(m => m.Name == row.Cells["dgvName"].Value.ToString());
            if (type is Container)
            {
                DataGridViewCell cell = row.Cells["dgvCount"];
                cell.ReadOnly = true;
            }

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["dgvCount"].Index)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            }
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["dgvCheck"] as DataGridViewCheckBoxCell;
                    checkBoxCell.Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["dgvCheck"] as DataGridViewCheckBoxCell;
                    checkBoxCell.Value = false;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if ((bool)row.Cells["dgvCheck"].Value)
                {
                    currentMaterials.Remove(currentMaterials.SingleOrDefault(m => m.Name == row.Cells["dgvName"].Value.ToString()));
                    dataGridView1.Rows.Remove(row);
                }
            }
            btnDelete.Visible = false;
            guna2CheckBox1.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            this.Close();
            SendForm.Obj.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveTable?.Invoke(this, e);
            this.Close();
            SendForm.Obj.Show();
        }
        
    }
}
