using BilgeAdam.Northwind.Client.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeAdam.Northwind.Client
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void msbProducts_Click(object sender, EventArgs e)
        {
            var f = new frmProducts();
            f.MdiParent = this;
            f.Show();
        }

        private void msbEmployees_Click(object sender, EventArgs e)
        {
            var f = new frmEmployees();
            f.MdiParent = this;
            f.Show();
        }
    }
}
