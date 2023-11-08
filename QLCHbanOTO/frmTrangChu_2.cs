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
    public partial class frmTrangChu_2 : Form
    {
        public frmTrangChu_2()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            frmXe1 xe1 = new frmXe1();
            xe1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmXe2 xe2 = new frmXe2();
            xe2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmXe3 xe3 = new frmXe3();
            xe3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmXe4 xe4 = new frmXe4();
            xe4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmxe5 xe5 = new frmxe5();
            xe5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmXe6 xe6 = new frmXe6();
            xe6.Show();

        }
    }
}
