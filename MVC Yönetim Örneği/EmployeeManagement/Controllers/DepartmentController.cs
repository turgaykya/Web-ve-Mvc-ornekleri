using EmployeeManagement.EF.Entities;
using EmployeeManagement.EF.Mapping;
using EmployeeManagement.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    [LoginRequired]
    public class DepartmentController : Controller
    {
        DataContext _dbContext = new DataContext();
        // GET: Department
        public ActionResult Index()
        {
            List<Department> model = _dbContext.Departments.ToList();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Department department)
        {
            _dbContext.Entry(department).State = System.Data.Entity.EntityState.Added;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Department model;
            if (id.HasValue)
            {
                model = _dbContext.Departments.SingleOrDefault(d => d.Id == id);  //Güncelleme
            }
            else
            {
                model = new Department(); //Yeni Kayıt
            }

            if (model != null)
            {
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {

            if (department.Id != 0)
            {
                _dbContext.Entry(department).State = System.Data.Entity.EntityState.Modified;

            }
            else
            {
                _dbContext.Entry(department).State = System.Data.Entity.EntityState.Added;

            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Department silinecekDep = _dbContext.Departments.FirstOrDefault(x => x.Id == id);

                return View(silinecekDep);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            Department silinecekDep = _dbContext.Departments.FirstOrDefault(x => x.Id == id);


            if (silinecekDep != null)
            {
                _dbContext.Departments.Remove(silinecekDep);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}