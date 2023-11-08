using DocumentFormat.OpenXml.Office.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHbanOTO
{
    public partial class frmTrangChu : Form
    {
        public FlowLayoutPanel flowLayoutPanel()
        {
            return flowLayoutPanel1;
        }


        public Button GetButton2()
        {
            // Trả về đối tượng của nút bạn muốn điều khiển
            return button2;
            
        }
        public Button GetButton3()
        {
            // Trả về đối tượng của nút bạn muốn điều khiển
           
            return button3;
           
        }
        public Button GetButton4()
        {
            // Trả về đối tượng của nút bạn muốn điều khiển
          
            return button4;
          
        }
        public Button GetBtnQLTK()
        {
            // Trả về đối tượng của nút bạn muốn điều khiển

            return btnTK;

        }
        public Button GetBtnSP()
        {
            // Trả về đối tượng của nút bạn muốn điều khiển

            return btnSanPham;

        }

        public frmTrangChu()
        {
            InitializeComponent();
        }
        
        private Form currentform;
        private void openfrm(Form formToOpen)
        {
            if (currentform != null)
            {
                currentform.Close();
            }

            currentform = formToOpen;
            formToOpen.TopLevel = false;
            formToOpen.FormBorderStyle = FormBorderStyle.None;
            formToOpen.Dock = DockStyle.Fill;
            pn_body.Controls.Add(formToOpen);
            pn_body.Size = formToOpen.Size;
            pn_body.Tag = formToOpen;
            formToOpen.BringToFront();
            formToOpen.Show();
        }
         
        private void button1_Click(object sender, EventArgs e)
        {

            //frmSanPhamHienThi frm = new frmSanPhamHienThi();

            //frm.TopLevel = false;
            //pn_body.Visible = false;
            //flowLayoutPanel1.Controls.Add(frm);
            //frm.Show();

            
                openfrm(new frmTrangChu_2());
                label1.Text = button1.Text;
           

        }
        private void button2_Click(object sender, EventArgs e)
        {
            pn_body.Visible = true;
            openfrm(new frmQLNV());
            label1.Text = button2.Text;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            pn_body.Visible = true;
            openfrm(new frmBangThongKe());
            label1.Text = "Bảng Thống Kê Số Lượng Xe ";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            pn_body.Visible = true;
            openfrm(new frmQLKH());
            label1.Text = button4.Text;
        }

       
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pn_body.Visible = true;
            Form1 frmLogin = new Form1();
            frmLogin.Show();
            this.Hide();
           
        }        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pn_body.Visible = true;
            frmgiohang gioHangForm = new frmgiohang();
            openfrm(gioHangForm);
        }
      
        private void btnTK_Click(object sender, EventArgs e)
        {
            pn_body.Visible = true;
            openfrm(new frmQLTK());
            label1.Text = "Quản Lý Tài Khoản ";
        }
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            pn_body.Visible = true;
            openfrm(new frmThemSanPham());
            label1.Text = "Quản Lý Sản Phẩm ";
        }
       
    }
    
}
