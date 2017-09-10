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
    public class EducationGroupController : Controller
    {
        // GET: StudentCRUD
        EducationGroupBLL _educationGroupBLL = new EducationGroupBLL();
        StudentBLL _stuBLL = new StudentBLL();
        EducationGroupStudentBLL _educationGroupStuBLL = new EducationGroupStudentBLL();

        Student _student = new Student();
        EducationGroup _educationGroup = new EducationGroup();
        Education_Group_Student _eduGroupStu = new Education_Group_Student();





        public ActionResult Index()
        {
            List<EducationGroupListModel> educationGroupListModel = _educationGroupBLL.TrainerEducationGroup((int)Session["LoginID"])
                .Select(x => new EducationGroupListModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    DateOfCrecation = x.DateOfCreation,
                    DateOfEnd = x.DateOfEnd,
                    TrainerFirstName = x.Trainer.FirstName,
                    TrainerLastName = x.Trainer.LastName

                }).ToList();

            return View(educationGroupListModel);
        }




        public ActionResult Edit(int id = 0)
        {
            EducationGroup educationGroup;

            List<Student> allStudent = _stuBLL.GetAll();
            ViewBag.StudentList = new MultiSelectList((from s in _stuBLL.GetAll() select new { ID = s.Id, FullName = s.FirstName + " " + s.LastName }), "ID", "FullName", null);

            List<Gender> allGender = _stuBLL.GenderList();
            SelectList genderSelectList = new SelectList(allGender, "Id", "Name");
            ViewBag.GenderList = genderSelectList;

         
            List<EducationGroupListModel> educationGroupListModel = _educationGroupBLL.TrainerEducationGroup((int)Session["LoginID"])
                .Select(x => new EducationGroupListModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    DateOfCrecation = x.DateOfCreation,
                    DateOfEnd = x.DateOfEnd,
                    TrainerFirstName = x.Trainer.FirstName,
                    TrainerLastName = x.Trainer.LastName

                }).ToList();


            if (id != 0)
            {
                educationGroup = _educationGroupBLL.Get(id);

            }
            else
            {
                educationGroup = new EducationGroup();
            }



            ViewBag.SelectStudentList = new MultiSelectList((from stu in _stuBLL.GetAll() join egs in _educationGroupStuBLL.GetAll() on stu.Id equals egs.StudentID join eg in _educationGroupBLL.GetAll() on egs.EducationGroupID equals eg.Id where (egs.EducationGroupID == educationGroup.Id && stu.EducationGrouoStatus == true) select new { ID = egs.StudentID, FullName = stu.FirstName + " " + stu.LastName }).Distinct(), "ID", "FullName", null);

            ViewBag.NotSelectStudentList = new MultiSelectList((from stu in _stuBLL.GetAll() where (stu.EducationGrouoStatus == false) select new { ID = stu.Id, FullName = stu.FirstName + " " + stu.LastName }).Distinct(), "ID", "FullName", null);

            return View(educationGroup);
        }

        [HttpPost]
        public ActionResult Edit(EducationGroup educationGroup, int[] studentId, int[] notStudentId)
        {

            if (educationGroup.Id > 0)
            {
              
                if (studentId != null)
                {


                    for (int i = 0; i < studentId.Length; i++)
                    {
                        _student = _stuBLL.Get(studentId[i]);
                        _student.EducationGrouoStatus = false;
                       
                        _stuBLL.Update(_student);              
                    }
                }
                if (notStudentId != null)
                {
                    for (int i = 0; i < notStudentId.Length; i++)
                    {
                        educationGroup.TrainerID = (int)Session["LoginID"];
                        _eduGroupStu = new Education_Group_Student();
                        _eduGroupStu.StudentID = notStudentId[i];
                        _eduGroupStu.EducationGroupID = educationGroup.Id;
                        _student = _stuBLL.Get(notStudentId[i]);
                        _eduGroupStu.DateOfJoin = DateTime.Now;
                        _student.EducationGrouoStatus = true;

                        _stuBLL.Update(_student);
                        _educationGroupStuBLL.Add(_eduGroupStu);
                    }
                }            
                educationGroup.TrainerID = (int)Session["LoginID"];
                _educationGroupBLL.Update(educationGroup);

                TempData["ResultMessage"] = "Yaptığınız Değişiklikler Başarıyla Gerçekleşmiştir.";
            }
            else
            {
                educationGroup.DateOfCreation = DateTime.Now.Date;

                educationGroup.TrainerID = (int)Session["LoginID"];

                _educationGroupBLL.Add(educationGroup);

                for (int i = 0; i < studentId.Length; i++)
                {
                    _eduGroupStu = new Education_Group_Student();
                    _eduGroupStu.DateOfJoin = DateTime.Now.Date;
                    _eduGroupStu.EducationGroupID = educationGroup.Id;
                    _eduGroupStu.StudentID = studentId[i];
                    _student = _stuBLL.Get(studentId[i]);
                    _student.EducationGrouoStatus = true;

                    _stuBLL.Update(_student);
                    _educationGroupStuBLL.Add(_eduGroupStu);
                }
            }
            TempData["ResultMessage"] = "Kaydetme İşleminiz Başarıyla Gerçekleşmiştir.";

            return RedirectToAction("Index");
        }



        //public JsonResult GetStudent(int id)
        //{
        //    Student stud = _stuBLL.Get(id);
        //       StudentListModel student = new StudentListModel() { FirstName=stud.FirstName,LastName=stud.LastName,CitizenNumber=stud.Login.CitizenNumber,UserName=stud.Login.UserName,Email=stud.Login.Mail,DateOfBirth=stud.DateOfBirth,GenderID=stud.GenderID};

        //       return Json(student, JsonRequestBehavior.AllowGet);
        //}

    }
}