using EmployeeManagement.Controllers;
using EmployeeManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Filters
{
    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["PersonId"] == null)
            {
                if (
                    HttpContext.Current.Request.Cookies["UserId"] != null
                    &&
                    HttpContext.Current.Request.Cookies["Password"] != null
                    )
                {
                    string userId = HttpContext.Current.Request.Cookies["UserId"].Value;
                    string password = HttpContext.Current.Request.Cookies["Password"].Value;

                    //LoginController loginController = new LoginController();
                    //loginController.Index(userId, password, "on");

                    //HttpContext.Current.Response.RedirectToRoutePermanent(
                    //    new
                    //    {
                    //        controller = "Login",
                    //        action = "Index",
                    //        userId = userId,
                    //        password = password,
                    //        rememberMe = "on"
                    //    });

                    LoginHelper helper = new LoginHelper();
                    bool loginSuccessed = helper.LoginUser(userId, password, "on", HttpContext.Current);

                    if (!loginSuccessed)
                    {
                        //filterContext.HttpContext.Response.RedirectPermanent("~/Home/Index");

                        // true değerini permanent kısmına gönderiyoruz
                        // Eğer ki cookie ile giriş işlemi başarılı değilse Login ekranına yönlendiriyoruz
                        filterContext.Result = new RedirectResult("~/Login", true);
                    }


                }
                else
                {
                    //filterContext.HttpContext.Response.Redirect("~/Login");
                    filterContext.HttpContext.Response.RedirectPermanent("~/Login");
                    //filterContext.HttpContext.Response.RedirectToRoute("~/Login");


                }

            }
        }
    }
}