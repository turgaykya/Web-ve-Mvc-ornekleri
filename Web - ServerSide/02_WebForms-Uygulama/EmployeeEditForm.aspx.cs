using _02_WebForms_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_WebForms_Uygulama
{
    public partial class EmployeeEditForm : System.Web.UI.Page
    {
        NorthwindEntities _dbContext;
        Employee _employee;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new NorthwindEntities();

            string employeeIdStr = Request.QueryString["id"];
            employeeIdStr = employeeIdStr ?? "0";

            int employeeId = int.Parse(employeeIdStr);

            if (employeeId == 0)
            {
                _employee = new Employee();
            }
            else
            {
                _employee = _dbContext.Employees.Find(employeeId);
                if (!Page.IsPostBack)
                {
                    txtTitleOfCourtesy.Text = _employee.TitleOfCourtesy;
                    txtLastName.Text = _employee.LastName;
                    txtFirstName.Text = _employee.FirstName;
                    txtTitle.Text = _employee.Title;
                }
                btnSave.Text = "Güncelle";
            }

            var allCategories = _dbContext.Employees.ToList();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeAdd();
        }

        private void EmployeeAdd()
        {
            _employee.TitleOfCourtesy = txtTitleOfCourtesy.Text;
            _employee.LastName = txtLastName.Text;
            _employee.FirstName = txtFirstName.Text;
            _employee.Title = txtTitle.Text;

            if (_employee.EmployeeID == 0)
            {
                _dbContext.Employees.Add(_employee);
            }

            _dbContext.SaveChanges();

            Response.Redirect("EmployeeListForm.aspx");
        }
    }
}