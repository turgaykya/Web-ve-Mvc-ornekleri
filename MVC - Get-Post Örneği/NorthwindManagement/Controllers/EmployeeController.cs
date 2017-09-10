using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindManagement.Controllers
{
    public class EmployeeController : Controller
    {

        public NorthwindEntities _dbContext;

        public EmployeeController()
        {
            _dbContext = new NorthwindEntities();
        }

        /// <summary>
        /// çalışanları gosteren view'ı cagırır
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
           var employeeList = _dbContext.Employees.ToList();

            return View(employeeList);
        }

        /// <summary>
        /// calısan eklemek icin gerekli olan ekleme formunu içeren View'i cagırır
        /// </summary>
        /// <returns></returns>
        public ActionResult AddForm()
        {
            return View();
        }

        /// <summary>
        /// calısan ekleme View'ından gelen dataları yeni calısan nesnesinde biriktirip database'e kaydeder ve sonrasında listeleme sayfasının Action'ına yonlendirir.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="city"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        /// string firstName, string lastName, string city, string title
        public ActionResult Add()
        {
            Employee newEmp = new Employee(/*string firstName, string lastName, string city, string title*/);
            newEmp.FirstName = Request.Form["firstName"];
            newEmp.LastName = Request.Form["lastName"];
            newEmp.City = Request.Form["city"];
            newEmp.Title = Request["title"];  // bude olur

            //newEmp.FirstName = firstName;
            //newEmp.LastName = lastName;
            //newEmp.City = city;
            //newEmp.Title = title;

            _dbContext.Employees.Add(newEmp);
            _dbContext.SaveChanges();

            //Yöntem 1:
            //return View("Index", _dbContext.Employees.ToList());

            //Yöntem 2:
            return RedirectToAction("Index");
        }

        /// <summary>
        /// parametre olarak gelen Id'ye sahip calısanı databaseden siler ve calısan listesini barındıran Action'ına yönlendirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            Employee emp = _dbContext.Employees.Find(id);
            _dbContext.Employees.Remove(emp);
            //_dbContext.Entry(emp).State = EntityState.Deleted;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// calısan guncellemek icin gerekli olan ekleme formunu iceren View ı cagırır.ilgili calısanın datası da model olarak view'a gider.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateForm(int id)
        {
            Employee emp = _dbContext.Employees.Find(id);

            return View(emp);
        }

        public ActionResult Update(int id, string firstName, string lastname, string title, string city)
        {
            Employee emp = _dbContext.Employees.Find(id);
            emp.FirstName = firstName;
            emp.LastName = lastname;
            emp.Title = title;
            emp.City = city;

            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}