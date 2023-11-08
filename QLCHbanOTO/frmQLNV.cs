using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DocumentFormat.OpenXml.Office.Word;

namespace QLCHbanOTO
{
    public partial class frmQLNV : Form
    {
        public frmQLNV()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QLoto;Integrated Security=True");
        private void frmQLNV_Load(object sender, EventArgs e)
        {

            conn.Open();
            string query = "select * from NhanVien";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {

                ListViewItem item = new ListViewItem(reader["MaNhanVien"].ToString());
                item.SubItems.Add(reader["TenNhanVien"].ToString());
                item.SubItems.Add(reader["DiaChi"].ToString());
                item.SubItems.Add(reader["SDT"].ToString());
                item.SubItems.Add(reader["Email"].ToString());
                item.SubItems.Add(reader["ChucVu"].ToString());

                listView1.Items.Add(item);
            }

            reader.Close();
            conn.Close();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];


                txtmnv.Text = selectedItem.SubItems[0].Text;
                txttnv.Text = selectedItem.SubItems[1].Text;
                txtdc.Text = selectedItem.SubItems[2].Text;
                txtsdt.Text = selectedItem.SubItems[3].Text;
                txtemail.Text = selectedItem.SubItems[4].Text;
                txtcv.Text = selectedItem.SubItems[5].Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttnv.Text) || string.IsNullOrEmpty(txtdc.Text)
                || string.IsNullOrEmpty(txtsdt.Text) || string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txtcv.Text))
            {
                MessageBox.Show("Bạn không được để trống thông tin nhập ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                string query = "INSERT INTO NhanVien (TenNhanVien, DiaChi, SDT, Email, ChucVu) VALUES (@tenNhanVien, @diaChi, @SDT, @email, @chucVu)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenNhanVien", txttnv.Text);
                    cmd.Parameters.AddWithValue("@diaChi", txtdc.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtsdt.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@chucVu", txtcv.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                frmQLNV_Load(sender, e);
            }
            MessageBox.Show("Bạn đã thêm nhân viên thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            txtmnv.Clear();
            txttnv.Clear();
            txtdc.Clear();
            txtemail.Clear();
            txtcv.Clear();
            txtsdt.Clear();
        }
    


    private void button2_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count > 0)
        {
            MessageBox.Show("Bạn chắc chắn muốn sửa thông tin của nhân viên?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            ListViewItem selectedItem = listView1.SelectedItems[0];

                if (listView1.SelectedItems.Count > 0)
                {
                    string selectedMaNhanVien = listView1.SelectedItems[0].SubItems[0].Text;

                    string query = "UPDATE NhanVien SET TenNhanVien = @tenNhanVien, DiaChi = @diaChi, SDT = @SDT, Email = @email, ChucVu = @chucVu WHERE MaNhanVien = @maNhanVien";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tenNhanVien", txttnv.Text);
                        cmd.Parameters.AddWithValue("@diaChi", txtdc.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtsdt.Text);
                        cmd.Parameters.AddWithValue("@email", txtemail.Text);
                        cmd.Parameters.AddWithValue("@chucVu", txtcv.Text);
                        cmd.Parameters.AddWithValue("@maNhanVien", selectedMaNhanVien);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    // After updating the data, you can refresh the ListView to reflect the changes
                    frmQLNV_Load(sender, e);
                }
            }
    }
    private void button3_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count > 0)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xoá nhân viên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                using (SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QLoto;Integrated Security=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", selectedItem.SubItems[0].Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                listView1.Items.Remove(selectedItem);
            }
            txtmnv.Clear();
            txttnv.Clear();
            txtdc.Clear();
            txtsdt.Clear();
            txtemail.Clear();
            txtcv.Clear();
        }
    }

    private void btnBoChon_Click(object sender, EventArgs e)
    {
        txtmnv.Clear();
        txttnv.Clear();
        txtdc.Clear();
        txtsdt.Clear();
        txtemail.Clear();
        txtcv.Clear();
    }
}
}
