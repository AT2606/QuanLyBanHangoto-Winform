using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLCHbanOTO
{
    public partial class frmXe1 : Form
    {
        public frmXe1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            frmTTKH frm = new frmTTKH();
            frm.IsCheckbox1Checked = true;
            frm.Show();
            this.Hide();
        }

    }
}
