using EmployeeManagement.EF.Entities;
using EmployeeManagement.EF.Mapping;
using EmployeeManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userId, string password ,string rememberMe)
        {

            LoginHelper helper = new LoginHelper();
            bool loginSuccess = helper.LoginUser(userId, password, rememberMe, System.Web.HttpContext.Current);           

            if (loginSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı ve şifre kombinasyonu hatalı!";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session["PersonId"] = null;

            Response.Cookies["UserId"].Value = null;
            Response.Cookies["Password"].Value = null;


            return RedirectToAction("Index");
        }

        
	}
}