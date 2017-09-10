using EmployeeManagement.EF.Entities;
using EmployeeManagement.EF.Mapping;
using EmployeeManagement.Filters;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    [LoginRequired]
    public class EmployeeController : Controller
    {
        DataContext _dbContext = new DataContext();

        // GET: Employee
        //public ActionResult Index()
        //{
        //    List<Employee> model = _dbContext.Employee.ToList();

        //    return View(model);
        //}

        public ActionResult Index()
        {
            List<EmployeeListModel> model = _dbContext.Employee
                .Select(x => new EmployeeListModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.EmailAddress,
                    DepartmentName = x.Department.Name,
                    Id = x.Id
                }).ToList();

            return View(model);
        }

        public ActionResult Edit(int? id)
        {

            Employee employee = null;

            if (id.HasValue)
            {
                employee = _dbContext.Employee.SingleOrDefault(e => e.Id == id);
            }
            else
            {
                employee = new Employee();
            }

            if (employee != null)
            {
                List<Department> allDepartments = _dbContext.Departments.ToList();

                SelectList departmentsSelectList = new SelectList(allDepartments, "Id", "Name");

                List<Gender> allGenders = new List<Gender>();
                allGenders.Add(Gender.Female);
                allGenders.Add(Gender.Male);


                SelectList gendersSelectList = new SelectList(allGenders);
                ViewBag.Genders = gendersSelectList;




                // view a yardımcı verileri taşımak için kullanılan bi zımbırtı.
                ViewBag.Departments = departmentsSelectList;

                // viewdata ve viewbag birebir aynı şey
                ViewData["Test"] = "Tsubasa";

                return View(employee);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (employee.Id > 0)
            {
                _dbContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _dbContext.Entry(employee).State = System.Data.Entity.EntityState.Added;
            }

            try
            {
                _dbContext.SaveChanges();
                //ViewBag.ResultMessate = "Kaydetme işlemii başarılı";    //ömrü başka bi view baslayana kadar
                TempData["ResultMessage"] = "Kaydetme işlemii başarılı";
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}