using _02_WebForms_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_WebForms_Uygulama
{
    public partial class EmployeeListForm : System.Web.UI.Page
    {
        NorthwindEntities _dbContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new NorthwindEntities();

            RepeatEmployeeList.DataSource = _dbContext.Employees.ToList();
            RepeatEmployeeList.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string employeeIdStr = (sender as Button).Attributes["data-id"];
            int employeeID = int.Parse(employeeIdStr);

            Employee employee = _dbContext.Employees.Find(employeeID);

            _dbContext.Employees.Remove(employee);
            try
            {
            _dbContext.SaveChanges();

            }
            catch (Exception)
            {

            }
            Response.Redirect("EmployeeListForm.aspx");
        }
    }
}