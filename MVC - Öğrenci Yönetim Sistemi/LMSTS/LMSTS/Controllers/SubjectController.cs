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
    public class SubjectController : Controller
    {
        SubjectBLL _subjectBLL = new SubjectBLL();
        Subject _subject = new Subject();
        Trainer _trainer = new Trainer();
        EducationGroupBLL _eduBLL = new EducationGroupBLL();
        TrainerBLL _trainerBLL = new TrainerBLL();

        public ActionResult Index()
        {
            List<SubjectListModel> subjectListModel = _subjectBLL.Subject((int)Session["LoginID"])
                .Select(x => new SubjectListModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    DateOfCreation = DateTime.Now,
                    EducationGroupName = x.EducationGroup.Name,
                }).ToList();

            return View(subjectListModel);
        }

        public ActionResult Edit(int id = 0)
        {
            Subject subject;
            if (id != 0)
            {
                subject = _subjectBLL.Get(id);
            }
            else
            {
                subject = new Subject();
            }

            List<EducationGroup> allEducationGroup = _eduBLL.TrainerEducationGroup((int)Session["LoginID"]).ToList();
            SelectList educationGroupSelectList = new SelectList(allEducationGroup, "Id", "Name");
            ViewBag.EducationGroups = educationGroupSelectList;
            return View(subject);



        }
        [HttpPost]
        public ActionResult Edit(Subject subject)
        {
            if (subject.Id != 0)
            {
                _subjectBLL.Update(subject);
                TempData["ResultMessage"] = "Yaptığınız Değişiklikler Başarıyla Gerçekleşmiştir.";
            }
            else
            {
                List<Subject> subjectList = _subjectBLL.GetAll();
                subject.DateOfCreation = DateTime.Now.Date;

                _subjectBLL.Add(subject);
                TempData["ResultMessage"] = "Kaydetme İşleminiz Başarıyla Gerçekleşmiştir.";
            }
            return RedirectToAction("Index");
        }
    }
}
