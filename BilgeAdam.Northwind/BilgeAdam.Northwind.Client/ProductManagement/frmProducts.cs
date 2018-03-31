using BilgeAdam.Northwind.Business.Repositories;
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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
            Repository = new ProductRepository();
        }
        public ProductRepository Repository { get; set; }
        private void frmProducts_Load(object sender, EventArgs e)
        {
            dgvProducts.DataSource = Repository.GetProducts();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtSearch.Clear();
                dgvProducts.DataSource = Repository.GetProducts();
                e.SuppressKeyPress = true;
            }
            else if(e.KeyCode == Keys.Enter)
            {
                dgvProducts.DataSource = Repository.GetProductsByName(txtSearch.Text.Trim());
                e.SuppressKeyPress = true;
            }
        }
    }
}
