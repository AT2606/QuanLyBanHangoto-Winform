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
using System.Runtime.CompilerServices;

namespace QLCHbanOTO
{
    public partial class Form1 : Form
    {
        private frmTrangChu frmTrangChu;
        public Form1()
        {
            InitializeComponent();
            frmTrangChu = new frmTrangChu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QlNThat;Integrated Security=True");
            string tk = txtTK.Text;
            string mk = txtMk.Text;
            string quyen = "";

            conn.Open();
            string sql = "select taiKhoan,matKhau,Quyen from TaiKhoan where taiKhoan = @tk and matKhau = @mk ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tk", tk);
            cmd.Parameters.AddWithValue("@mk", mk);
            cmd.Parameters.AddWithValue("Quyen", quyen);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                quyen = rdr["Quyen"].ToString(); 

                if (quyen == "admin")
                {
                    MessageBox.Show("Bạn Đang đăng nhập với tài khoản Admin");
                   FlowLayoutPanel flowLayoutPanel = frmTrangChu.flowLayoutPanel();
                    flowLayoutPanel.Visible = false;

                    frmTrangChu form2 = new frmTrangChu();
                   

                    form2.Show();
                    this.Hide();
                }
                else
                {
                    Button bt2 = frmTrangChu.GetButton2();
                    bt2.Visible = false;
                    Button bt3 = frmTrangChu.GetButton3();
                    bt3.Visible = false;
                    Button bt4 = frmTrangChu.GetButton4();
                    bt4.Visible = false;
                    Button bt5 = frmTrangChu.GetBtnQLTK();
                    bt5.Visible = false;
                    Button btn6 = frmTrangChu.GetBtnSP();
                    btn6.Visible = false;
                    frmTrangChu.Show();
                    this.Hide();
                }
            }

            else if (string.IsNullOrEmpty(txtTK.Text) || string.IsNullOrEmpty(txtMk.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Tài Khoản hoặc mật khẩu không đúng\n\t Vui lòng nhập lại", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }


        }
        private bool isButtonOn = false;
        private string savedText = "";

       

    }
}
