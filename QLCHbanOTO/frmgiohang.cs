using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QLCHbanOTO.frmTTKH;

namespace QLCHbanOTO
{
    public partial class frmgiohang : Form
    {
        public frmgiohang()
        {
            InitializeComponent();
        }
        List<ListViewItem> danhSachSanPham = new List<ListViewItem>();
        public void ThemKhachHangVaoListView(string TenSanPham ,int SoLuong,int DonGia,int ThanhTien)
        {
            ListViewItem item = new ListViewItem(TenSanPham);
           
            item.SubItems.Add(SoLuong.ToString());
            item.SubItems.Add(DonGia.ToString());
            item.SubItems.Add(ThanhTien.ToString());
            danhSachSanPham.Add(item);

            // Thêm ListViewItem vào ListView
            listView1.Items.Add(item);
        }
      
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Duyệt qua các mục được chọn và xóa chúng
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    listView1.Items.Remove(item);
                }
            }
        }
    }
}
