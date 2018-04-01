using BilgeAdam.Northwind.Client.HR;
using BilgeAdam.Northwind.Client.ProductManagement;
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
            OpenForm<frmProducts>();
        }

        private void msbEmployees_Click(object sender, EventArgs e)
        {
            OpenForm<frmEmployees>();
        }

        private void msbAddProduct_Click(object sender, EventArgs e)
        {
            OpenForm<frmNewProduct>();
        }

        public void OpenForm<T>() where T : Form
        {
            var type = typeof(T);
            var f = Activator.CreateInstance(type) as T;
            f.MdiParent = this;
            f.Show();
        }

        private void msbNewEmployee_Click(object sender, EventArgs e)
        {
            OpenForm<frmNewEmployee>();
        }
    }
}
