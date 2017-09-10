using _01_Entities;
using Business;
using LMSTS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSTS.Controllers
{
    public class LoginController : Controller
    {
        TrainerBLL _trainerBLL = new TrainerBLL();
        SelectList genderSelectList, branchSelectList, titleSelectList;
        List<Title> allTitle;
        List<Branch> allBranch;
        List<Gender> allGender;

        // GET: Login
        public ActionResult Index()
        {

            if (Request.Cookies["UserId"] != null && Request.Cookies["Password"] != null)
            {
                string UserId = Request.Cookies["UserId"].Value;
                string Password = Request.Cookies["Password"].Value;
                string rememberMe = "on";
                LoginHelper helper = new LoginHelper();
                int LoginID = helper.LoginUser(UserId, Password, rememberMe, System.Web.HttpContext.Current);

                Session["LoginID"] = LoginID;
                if (LoginID != 0)
                {
                    if (LoginID % 2 == 0)
                    {
                        return RedirectToAction("Index", "Student");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Trainer");
                    }
                }
                return View();
            }
            else
            {
                ViewBag.PanelSgin = "none";
                ViewBag.PanelLogin = "inline";
                Trainer trainer = new Trainer();

                allTitle = _trainerBLL.TitleList();
                titleSelectList = new SelectList(allTitle, "Id", "Name");

                allBranch = _trainerBLL.BranchList();
                branchSelectList = new SelectList(allBranch, "Id", "Name");

                allGender = _trainerBLL.GenderList();
                genderSelectList = new SelectList(allGender, "Id", "Name");

                ViewBag.Branch = branchSelectList;
                ViewBag.Title = titleSelectList;
                ViewBag.Gender = genderSelectList;
                return View(trainer);

            }
        }

        [HttpPost]
        public ActionResult Index(string UserId, string Password, string rememberMe)
        {

            ViewBag.PanelSgin = "none";
            ViewBag.PanelLogin = "inline";
            LoginHelper helper = new LoginHelper();
            allTitle = _trainerBLL.TitleList();
            titleSelectList = new SelectList(allTitle, "Id", "Name");

            allBranch = _trainerBLL.BranchList();
            branchSelectList = new SelectList(allBranch, "Id", "Name");

            allGender = _trainerBLL.GenderList();
            genderSelectList = new SelectList(allGender, "Id", "Name");

            ViewBag.Branch = branchSelectList;
            ViewBag.Title = titleSelectList;
            ViewBag.Gender = genderSelectList;
            int LoginID = helper.LoginUser(UserId, Password, rememberMe, System.Web.HttpContext.Current);
            if (LoginID != 0)
            {
                Session["LoginID"] = LoginID;
                if (LoginID % 2 == 0)
                {
                    return RedirectToAction("Index","Student");

                }
                else
                {
                    return RedirectToAction("Index", "Trainer");
                }
            }
            ViewBag.ErrorMessage = "Hatalı Giriş Bilgileri Lütfen Kontrol Ederek Tekrar Deneyiniz...";
            return View();
        }

        [HttpPost]
        public ActionResult Sgin(Trainer Trainer, string Mail, string Password, string Contract)
        {
            string messaj;
            bool result = _trainerBLL.Add(Trainer, Mail, Password, Contract, out messaj);
            if (result)
            {
                TempData["Messaj"] = messaj;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.PanelSgin = "inline";
                ViewBag.PanelLogin = "none";
                LoginHelper helper = new LoginHelper();
                allTitle = _trainerBLL.TitleList();
                titleSelectList = new SelectList(allTitle, "Id", "Name");
                allBranch = _trainerBLL.BranchList();
                branchSelectList = new SelectList(allBranch, "Id", "Name");
                allGender = _trainerBLL.GenderList();
                genderSelectList = new SelectList(allGender, "Id", "Name");
                ViewBag.Branch = branchSelectList;
                ViewBag.Title = titleSelectList;
                ViewBag.Gender = genderSelectList;
                ViewBag.Messaj = messaj;
                return View("Index");
            }
        }
        public JsonResult ValControl(string val)
        {
            Login result;
            result = _trainerBLL.LoginControl(val);
            if (result == null)
            {
                result = new Login();
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    
        public ActionResult Logout()
        {

            Response.Cookies["UserId"].Expires = DateTime.Now.AddMilliseconds(-100);
            Response.Cookies["Password"].Expires = DateTime.Now.AddMilliseconds(-100);
            


            return RedirectToAction("Index");

        }
    }
}