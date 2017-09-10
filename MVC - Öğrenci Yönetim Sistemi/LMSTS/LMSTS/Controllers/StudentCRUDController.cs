using _01_Entities;
using Business;
using LMSTS.Helper;
using LMSTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LMSTS.Controllers
{
    [LoginAttribute]
    public class StudentCRUDController : Controller
    {
        // GET: StudentCRUD
        StudentBLL _studentBLL = new StudentBLL();
        Student _student = new Student();

        public ActionResult Index()
        {
            List<StudentListModel> studentListModel = _studentBLL.GetAll()
                .Select(x => new StudentListModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    GenderName = x.Gender.Name,
                    EducationBranchName = x.EducationBranch.Name,
                    DateOfBirth = x.DateOfBirth,
                    DateOfRegistration = x.DateOfRegistration,
                    IsOnline = x.IsOnline,
                    Status = x.Status
                }).ToList();
            return View(studentListModel);
        }

        public ActionResult Edit(int id = 0)
        {
            Student student;
            if (id != 0)
            {
                student = _studentBLL.Get(id);
            }
            else
            {
                student = new Student();
            }

            List<EducationBranch> allEducationBranch = _studentBLL.EducationList();
            SelectList educationBranchSelectList = new SelectList(allEducationBranch, "Id", "Name");

            List<Gender> allGender = _studentBLL.GenderList();
            SelectList genderSelectList = new SelectList(allGender, "Id", "Name");

            ViewBag.EducationBranchs = educationBranchSelectList;
            ViewBag.Genders = genderSelectList;

            return View(student);

        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
          

            if (student.Id != 0)
            {

                student.Login.Id = student.Id;               
                _studentBLL.Update(student);
                TempData["ResultMessage"] = "Yaptığınız Değişiklikler Başarıyla Gerçekleşmiştir.";
            }
            else
            {
                int id = 2;
                List<Student> studentList = _studentBLL.GetAll();
                if (studentList.Count != 0)
                {
                    id = studentList[studentList.Count - 1].Id + 2;
                }
                student.Id = id;
                student.IsOnline = false;
                student.EducationGrouoStatus = false;
                student.Status = true;
                student.DateOfRegistration = DateTime.Now.Date;
                student.Login.Id = student.Id;
                if (_studentBLL.Add(student))
                {
                    if (MailHelper.SentMail(student.Login.Mail, "Sisteme Kaydınız ile İlgili",
                        string.Format("Merhaba : {0} {1}\n\n Sisteme giriş bilgileriniz aşağıda verilmiştir. \n\n\n\nKullanıcı Adınız : {2}\nParolanız :{3} \n\nGiriş bilgilerinizi kimseyle paylaşmayınız",student.FirstName,student.LastName,student.Login.UserName,student.Login.Password) ))
                    {
                        TempData["ResultMessage"] = "Kaydetme İşleminiz Başarıyla Gerçekleşmiştir.";
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}