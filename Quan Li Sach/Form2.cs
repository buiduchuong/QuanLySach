using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Li_Sach.Model;
using Quan_Li_Sach.DataBase;
using System.Windows.Forms;

namespace Quan_Li_Sach
{
    public partial class Form2 : Form
    {
        Database database = new Database();
        public Form2()
        {
            InitializeComponent();
            inDS();
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if (checkNull())
            {
                database.insert(new Sach(0, textBox_tenSach.Text.ToString(), textBox_tacGia.Text, textBox_theLoai.Text, float.Parse(textBox_donGia.Text.ToString()), dateTimePicker_ngayPH.Value));
                inDS();
                chuyenGiaTriVeNull();
            }

        }

        private void inDS()
        {
            dataGridView_bangSach.DataSource = null;
            dataGridView_bangSach.DataSource = database.select();
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (checkNull())
            {
                database.delete(int.Parse(textBox_maSach.Text));
                inDS();
                chuyenGiaTriVeNull();
            }
            
        }


        private void chuyenGiaTriVeNull()
        {
            textBox_maSach.Text = "";
            textBox_tenSach.Text = "";
            textBox_tacGia.Text = "";
            textBox_theLoai.Text = "";
            textBox_donGia.Text = "";
        }

       
        private void click(DataGridViewCellEventArgs e)
        {
            textBox_maSach.Text = dataGridView_bangSach.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            textBox_tenSach.Text = dataGridView_bangSach.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            textBox_tacGia.Text = dataGridView_bangSach.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            textBox_theLoai.Text = dataGridView_bangSach.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            textBox_donGia.Text = dataGridView_bangSach.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            if (checkNull())
            {
                database.update(new Sach(int.Parse(textBox_maSach.Text), textBox_tenSach.Text.ToString(), textBox_tacGia.Text, textBox_theLoai.Text, float.Parse(textBox_donGia.Text.ToString()), dateTimePicker_ngayPH.Value));
                inDS();
                chuyenGiaTriVeNull();
            }
           
        }

        private void button_logOut_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl != DialogResult.No)
            {
                this.Close();
            }
        }
        private bool checkNull()
        {
            if (textBox_tenSach.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Tên sách không được rỗng!","THÔNG BÁO!!!");
                return false;
            }
            if (textBox_tacGia.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Tác giả không được rỗng!", "THÔNG BÁO!!!");
                return false;
            }

            if (textBox_theLoai.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("Thể loại không được rỗng!", "THÔNG BÁO!!!");
                return false;
            }
            if (textBox_donGia.Text.ToString().Trim().Equals(""))
                {
                    MessageBox.Show("Đơn giá không được rỗng!", "THÔNG BÁO!!!");
                    return false;
            }
           
            if (dateTimePicker_ngayPH.Text.Equals(""))
            {
                MessageBox.Show("Ngày phát hành không được rỗng!", "THÔNG BÁO!!!");
                return false;
            }


            return true;
        }

        private void kiemTraNhap(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void clickConTent(object sender, DataGridViewCellEventArgs e)
        {
            click(e);
        }
    }
}
