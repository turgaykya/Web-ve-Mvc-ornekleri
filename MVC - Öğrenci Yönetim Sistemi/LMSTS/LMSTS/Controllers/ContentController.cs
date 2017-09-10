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
    public class ContentController : Controller
    {
        SubjectBLL _subjectBLL = new SubjectBLL();
        Subject _subject = new Subject();
        Trainer _trainer = new Trainer();
        EducationGroupBLL _eduBLL = new EducationGroupBLL();
        TrainerBLL _trainerBLL = new TrainerBLL();
        ContentBLL _contentBLL = new ContentBLL();
        Content _content = new Content();



        // GET: Content
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult Edit(int id=0)
        {
            //(int)Session["LoginID"]
            List<Subject> subjectList = _contentBLL.GetSubject((int)Session["LoginID"]);

            return View(subjectList);
        }

        [ValidateInput(false)]
        public ActionResult AddNewContent(int SubjectId, string document)
        {
            Content content = new Content();

            content.SubjectID = SubjectId;
            content.Document = document;
            content.DateOfCreation = DateTime.Now;

            _contentBLL.Add(content);


            return View("Index");
        }


    }
}