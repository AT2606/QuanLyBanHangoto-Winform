using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLCHbanOTO
{
    public partial class frmTTKH : Form
    {

        public frmTTKH()
        {
            InitializeComponent();

        }
        public bool IsCheckbox1Checked
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
            }
        }
        public bool IsCheckbox2Checked
        {
            get { return checkBox2.Checked; }
            set { checkBox2.Checked = value;
                checkBox3.Visible = false;
                checkBox1.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
            }
        }
        public bool IsCheckbox3Checked
        {
            get { return checkBox3.Checked; }
            set { checkBox3.Checked = value;
                checkBox2.Visible = false;
                checkBox1.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
            }
        }
        public bool IsCheckbox4Checked
        {
            get { return checkBox4.Checked; }
            set { checkBox4.Checked = value;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox1.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
            }
        }
        public bool IsCheckbox5Checked
        {
            get { return checkBox5.Checked; }
            set { checkBox5.Checked = value;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox1.Visible = false;
                checkBox6.Visible = false;
            }
        }
        public bool IsCheckbox6Checked
        {
            get { return checkBox6.Checked; }
            set { checkBox6.Checked = value;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox1.Visible = false;
            }
        }

        public string TenSanPham
        {
            get
            {
                if (checkBox1.Checked)
                {
                    return "Mercedes A35 - 4 Matic";
                }
                else if (checkBox2.Checked)
                {
                    return "Mercedes Benz - Class";
                }
                else if (checkBox3.Checked)
                {
                    return "Mercedes E 180";
                }
                else if (checkBox4.Checked)
                {
                    return "Mercedes G63 - 4 Matic";
                }
                else if (checkBox5.Checked)
                {
                    return "Mercedes S450";
                    
                }
                else 
                {
                    return "Mercedes GLC 300";
                }
            }
        }
        public int DonGia
        {
            get
            {
                if (checkBox1.Checked)
                {
                    return 1000000;
                }
                else if (checkBox2.Checked)
                {
                    return 1200000;
                }
                else if (checkBox3.Checked)
                {
                    return 900000;
                }
                else if (checkBox4.Checked)
                {
                    return 500000;
                }
                else if (checkBox5.Checked)
                {
                    return 1200000;
                    
                }
                else
                {
                    return 300000;
                }
            }
        }
        public string ThanhTien
        {
            get
            {
                if (checkBox1.Checked)
                {
                    return "";
                }
                else if (checkBox2.Checked)
                {
                    return "";
                }
                else if (checkBox3.Checked)
                {
                    return "";
                }
                else if (checkBox4.Checked)
                {
                    return "";
                }
                else if (checkBox5.Checked)
                {
                    return "";
                }
                else
                {
                    return "";
                }
            }
        }

        public string SoLuong => txtSL.Text;
        private bool IsNumeric(string input) // kiểm tra số lượng phải là số
        {
            return int.TryParse(input, out _);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

             if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSL.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) ||
                    (!checknam.Checked && !checknu.Checked)||(!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked && !checkBox5.Checked && !checkBox6.Checked))
                 {

                          MessageBox.Show("Quý Khách phải điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 }
           else if (!IsNumeric(txtSL.Text))
            {
                MessageBox.Show("Vui lòng nhập đúng Giá Trị Số Lượng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSL.Clear();
            }
            else
            {
                // Lưu thông tin khách hàng vào cơ sở dữ liệu
                string connectionString = @"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QLoto;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO khachHang (hoTen, diaChi, gioiTinh, SDT, loaiXe, soLuong,ngayDatHang,donGia,thanhTien) VALUES (@hoTen, @diaChi, @gioiTinh, @SDT,@loaiXe,@soLuong,@ngayDatHang,@donGia,@thanhTien)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@hoTen", txtHoTen.Text);                        
                        cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@gioiTinh", checknam.Checked ? "Nam" : "Nữ");
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmd.Parameters.AddWithValue("@soLuong", txtSL.Text);
                        
                        string loaiXe = "";
                        int donGia = 0 ;
                       

                        if (checkBox1.Checked)
                        {
                            loaiXe = "Mercedes A35 - 4 Matic";
                            donGia = 1000000;
       
                        }
                        else if (checkBox2.Checked)
                        {
                            loaiXe = "Mercedes Benz - Class";
                            donGia = 1200000;
                        }
                        else if (checkBox3.Checked)
                        {
                            loaiXe = "Mercedes E 180";
                            donGia = 900000;
                        }
                        else if (checkBox4.Checked)
                        {
                            loaiXe = "Mercedes G63 - 4 Matic";
                            donGia = 500000;
                        }
                        else if (checkBox5.Checked)
                        {
                            loaiXe = "Mercedes S450";
                            donGia = 1200000;
                            
                        }
                        else if (checkBox6.Checked)
                        {
                            loaiXe = "Mercedes GLC 300";
                            donGia = 500000;
                        }
                        int ThanhTien = donGia * int.Parse(txtSL.Text);
                        cmd.Parameters.AddWithValue("@loaiXe", loaiXe);
                        cmd.Parameters.AddWithValue("@ngayDatHang", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@donGia", donGia);
                        cmd.Parameters.AddWithValue("@thanhTien", ThanhTien);
                        int SoLuong;
                        int.TryParse(txtSL.Text, out SoLuong);
                            // Thực hiện truy vấn SQL
                            cmd.ExecuteNonQuery();

                        MessageBox.Show("Quý Khách đặt hàng Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        frmgiohang gioHangForm = new frmgiohang();
                        gioHangForm.ThemKhachHangVaoListView(loaiXe, SoLuong, donGia, ThanhTien);
                        gioHangForm.Show();
                    }
                }                
                                       
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checknam.Checked)
            {
                checknu.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checknu.Checked)
            {
                checknam.Checked = false;
            }
        }

        
        private void frmTTKH_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
