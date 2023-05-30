using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
            loadstaff();
            setshifttpype();
        }
        private void setshifttpype()
        {
            DataProvider provider = new DataProvider();
            DataTable table = provider.loadshifttype();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBox1.Items.Add(table.Rows[i][0].ToString());
            }
        }
        private void loadstaff()
        {
            try
            {
                DataProvider provider = new DataProvider();
                DataTable table = provider.loadstaff();
                dataGridView1.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Tải không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void clear()
        {
            textBox1.ResetText();
            comboBox1.ResetText();
            comboBox1.Focus();
            txtAddName.ResetText();
            textBox2.ResetText() ;
            textBox3.ResetText();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataProvider provider = new DataProvider();
                provider.addstaff(textBox1.Text,txtAddName.Text,textBox2.Text,textBox3.Text,comboBox1.Text);
                MessageBox.Show("Thêm thành công", "Đã thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                loadstaff();
            }
            catch
            {
                MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataProvider provider = new DataProvider();
                provider.updatestaff(textBox1.Text, txtAddName.Text, textBox2.Text, textBox3.Text, comboBox1.Text);
                MessageBox.Show("Sửa thành công!", "Đã sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                loadstaff();
            }
            catch
            {
                MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Nhan yes
                    DataProvider provider = new DataProvider();
                    provider.deletestaff(textBox1.Text);
                    MessageBox.Show("Xóa thành công!", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    loadstaff();
                }
                //nhan no
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    textBox1.Text = row.Cells[0].Value.ToString();
                    txtAddName.Text = row.Cells[1].Value.ToString();
                    comboBox1.Text = row.Cells[4].Value.ToString();
                    textBox2.Text = row.Cells[2].Value.ToString();
                    textBox3.Text = row.Cells[3].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi data!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
