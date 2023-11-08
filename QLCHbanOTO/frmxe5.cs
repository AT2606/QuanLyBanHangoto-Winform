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
    public partial class frmxe5 : Form
    {
        public frmxe5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTTKH frm = new frmTTKH();
            frm.IsCheckbox6Checked = true;
            frm.Show();
            this.Hide();

        }
    }
}
