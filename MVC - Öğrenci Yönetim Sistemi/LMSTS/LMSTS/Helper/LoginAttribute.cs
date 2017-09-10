using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSTS.Helper
{
    public class LoginAttribute:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.Session["LoginID"]==null)
            {
                if (HttpContext.Current.Request.Cookies["UserID"] != null
                    &&
                    HttpContext.Current.Request.Cookies["Password"] != null)
                {
                    string UserID = HttpContext.Current.Request.Cookies["UserID"].Value;
                    string Password = HttpContext.Current.Request.Cookies["Password"].Value;

                    LoginHelper helper = new LoginHelper();
                    int LoginSucsessed = helper.LoginUser(UserID, Password, "on", HttpContext.Current);

                    //if (LoginSucsessed != 0)
                    //{
                    //    if (LoginSucsessed % 2 == 1)
                    //    {
                    //        filterContext.Result = new RedirectResult("~/Trainer", true);
                    //    }
                    //    else
                    //    {
                    //        filterContext.Result = new RedirectResult("~/Student", true);
                    //    }
                    //}
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Login", true);
                }
            }

        }

    }
}