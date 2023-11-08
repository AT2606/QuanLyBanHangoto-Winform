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
    public partial class frmXe4 : Form
    {
        public frmXe4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTTKH frm = new frmTTKH();
            frm.IsCheckbox4Checked = true;
            frm.Show();
            this.Hide();
        }
    }
}
