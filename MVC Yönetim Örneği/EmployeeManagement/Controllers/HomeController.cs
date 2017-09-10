using EmployeeManagement.EF.Entities;
using EmployeeManagement.EF.Mapping;
using EmployeeManagement.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    [LoginRequired]
    public class HomeController : Controller
    {

        //
        // GET: /Home/
        public ActionResult Index()
        {
            //if (Session["PersonId"] == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}

            int loginEmpId = Convert.ToInt32(Session["PersonId"]);
            Employee loginEmp = new DataContext().Employee.FirstOrDefault(x => x.Id == loginEmpId);

            object loginEmpName = loginEmp.FirstName + " " + loginEmp.LastName;

            return View(loginEmpName);
        }

        public ActionResult LoginUser()
        {
            int loginEmpId = Convert.ToInt32(Session["PersonId"]);
            Employee loginEmp = new DataContext().Employee.FirstOrDefault(x => x.Id == loginEmpId);

            object loginEmpName = loginEmp.FirstName + " " + loginEmp.LastName;

            return PartialView(loginEmp);
        }
    }
}