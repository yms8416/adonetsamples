using BilgeAdam.Northwind.Business.Dtos;
using BilgeAdam.Northwind.Business.Enums;
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
    public partial class frmNewEmployee : Form
    {
        public frmNewEmployee()
        {
            InitializeComponent();
            ecbGender.EnumType = typeof(Gender);
            ecbMStatus.EnumType = typeof(MarrialStatus);
        }
        public EmployeeRepository Repository { get; set; }
        private void frmNewEmployee_Load(object sender, EventArgs e)
        {
            nudHealthHours.Value = 40;
            nudVacHours.Value = 196;
            dtpBirthDate.Value = DateTime.Now.AddYears(-21).AddMonths(-1).AddDays(-15);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var employee = new EmployeeDto
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                BirthDate = dtpBirthDate.Value,
                HireDate = dtpHireDate.Value,
                Gender = (Gender)ecbGender.SelectedEnumValue,
                MarrialStatus = (MarrialStatus)ecbGender.SelectedEnumValue,
                LoginName = txtLoginName.Text,
                SickLeaveHours = (int)nudHealthHours.Value,
                VacationHours = (int)nudVacHours.Value
            };
            Repository.SaveEmployee(employee)
        }
    }
}
