using EmployeeManagement.EF.Entities;
using EmployeeManagement.EF.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Helpers
{
    public class LoginHelper
    {
        internal bool LoginUser(string userId, string password, string rememberMe, HttpContext httpContext)
        {
            Employee e = new DataContext().Employee
                    .FirstOrDefault(x => x.UserId == userId && x.Password == password);

            if (e != null)
            {
                httpContext.Session["PersonId"] = e.Id;

                if (!string.IsNullOrEmpty(rememberMe) && rememberMe == "on")
                {
                    httpContext.Response.Cookies["UserId"].Value = userId;
                    httpContext.Response.Cookies["UserId"].Expires = DateTime.Now.AddYears(1);

                    httpContext.Response.Cookies["Password"].Value = password;
                    httpContext.Response.Cookies["Password"].Expires = DateTime.Now.AddYears(1);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}