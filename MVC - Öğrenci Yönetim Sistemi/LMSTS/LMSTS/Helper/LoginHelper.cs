using _01_Entities;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMSTS.Helper
{
    public class LoginHelper
    {
        LoginBLL _loginBLL = new LoginBLL();
        internal int LoginUser(string userId, string password, string rememberMe, HttpContext httpContext)
        {
            Login login = _loginBLL.LoginUser(userId, password);
            if (login!=null)
            {
                httpContext.Session["LoginID"] = login.Id;
                if (!string.IsNullOrEmpty(rememberMe) && rememberMe == "on")
                {
                    httpContext.Response.Cookies["UserId"].Value = userId;
                    httpContext.Response.Cookies["UserId"].Expires = DateTime.Now.AddYears(1);

                    httpContext.Response.Cookies["Password"].Value = password;
                    httpContext.Response.Cookies["Password"].Expires = DateTime.Now.AddYears(1);
                }
                return login.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}