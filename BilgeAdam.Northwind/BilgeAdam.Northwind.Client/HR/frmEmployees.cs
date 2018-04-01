using BilgeAdam.Northwind.Business.Enums;
using BilgeAdam.Northwind.Business.Helpers;
using BilgeAdam.Northwind.Business.Models;
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

namespace BilgeAdam.Northwind.Client.HR
{
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
            Repository = new EmployeeRepository();
            dgvEmployees.AutoGenerateColumns = false;
        }
        public EmployeeRepository Repository { get; set; }
        private void frmEmployees_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;//bu kısım enumdan okunarak yapılacak
            dgvEmployees.DataSource = Repository.GetAllEmployees();
        }

        private void dgvEmployees_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var item = dgvEmployees.Rows[e.RowIndex].DataBoundItem as Employee;
            dgvEmployees.Rows[e.RowIndex].Cells["colStatus"].Value = GetEnumText<MarrialStatus>(item.Status);
            dgvEmployees.Rows[e.RowIndex].Cells["colGender"].Value = GetEnumText<Gender>(item.Gender);
        }

        private string GetEnumText<T>(T value)
        {
            var type = typeof(T);
            var member = type.GetMember(value.ToString())[0];
            var attribute = member.CustomAttributes.ToArray()[0];
            return attribute.NamedArguments[0].TypedValue.Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var filter = new EmployeeBasicFilter
            {
                IsMale = rdbMale.Checked,
                IsSingle = cmbStatus.SelectedIndex == 1
            };
            dgvEmployees.DataSource = Repository.GetAllEmployeesByFilter(filter);
        }

        private void ctxDelete_Click(object sender, EventArgs e)
        {
            var selected = dgvEmployees.SelectedRows[0].DataBoundItem as Employee;
            if (selected == null)
            {
                MessageBox.Show("Personel seçilemediğinden işlem gerçekleştirilemiyor");
                return;
            }
            var mresult = MessageBox.Show($"{selected.FirstName} {selected.LastName} adına kayıtlı bilgileri silmek istiyor musunuz?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mresult == DialogResult.Yes)
            {
                var result = Repository.DeleteEmployee(selected.Id);
                if (result)
                {
                    MessageBox.Show("Silme işlemi tamamlandı", "Kayıt Sil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvEmployees.DataSource = Repository.GetAllEmployees();
                }
            }
            
        }
    }
}
