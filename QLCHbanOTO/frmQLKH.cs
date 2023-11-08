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

namespace QLCHbanOTO
{
    public partial class frmQLKH : Form
    {
        public frmQLKH()
        {
            InitializeComponent();
        }
        
        SqlConnection conn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS01;Initial Catalog=QLoto;Integrated Security=True");
        private void frmQLKH_Load(object sender, EventArgs e)
        {
           
            conn.Open();
            string sql = "select maKhachHang,hoTen,diaChi,gioiTinh,SDt,loaiXe,soLuong,donGia,thanhTien,FORMAT(ngayDatHang, 'dd/MM/yyyy HH:mm:ss') as ngayDatHang from khachHang";
            SqlCommand cmd = new SqlCommand(sql, conn);
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Duyệt qua từng dòng trong DataTable và thêm nó vào ListView
                foreach (DataRow row in dataTable.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaKhachHang"].ToString());
                    item.SubItems.Add(row["HoTen"].ToString());
                    item.SubItems.Add(row["DiaChi"].ToString());
                    item.SubItems.Add(row["GioiTinh"].ToString());
                    item.SubItems.Add(row["SDT"].ToString());
                    item.SubItems.Add(row["LoaiXe"].ToString());
                    item.SubItems.Add(row["SoLuong"].ToString());
                    item.SubItems.Add(row["DonGia"].ToString());
                    item.SubItems.Add(row["ThanhTien"].ToString());
                    item.SubItems.Add(row["NgayDatHang"].ToString());

                    listView1.Items.Add(item);
                }
            }
        }
       
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];


                txtmakhachhang.Text = selectedItem.SubItems[0].Text;
                txthoten.Text = selectedItem.SubItems[1].Text;
                txtdc.Text = selectedItem.SubItems[2].Text;
                txtgt.Text = selectedItem.SubItems[3].Text;
                txtsdt.Text = selectedItem.SubItems[4].Text;
                txtloaixe.Text = selectedItem.SubItems[5].Text;
                txtSL.Text = selectedItem.SubItems[6].Text;
                txtdongia.Text = selectedItem.SubItems[7].Text;
                txtthanhtien.Text = selectedItem.SubItems[8].Text;
                txtngaydathang.Text = selectedItem.SubItems[9].Text;

            }
        }
        
    }
}
