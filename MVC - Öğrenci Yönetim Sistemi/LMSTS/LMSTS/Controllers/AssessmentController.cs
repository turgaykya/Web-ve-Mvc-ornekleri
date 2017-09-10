using _01_Entities;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSTS.Controllers
{
    public class AssessmentController : Controller
    {
        QuestionBLL _questionBLL = new QuestionBLL();
        SubjectBLL _subjectBLL = new SubjectBLL();


        // GET: Assessment
        public ActionResult QuestionsList()
        {


            return View();
        }

        public ActionResult QuestionAdd(int id=0)
        {
            Question question;
            if (id != 0)
            {
                question = _questionBLL.Get(id);
            }
            else
            {
                question = new Question();
            }

            List<Subject> SubjectList = _subjectBLL.GetAll();//EducationGroupba göre subjectler eklenecek!
            SelectList SelectQuestionList = new SelectList(SubjectList, "Id", "Name");
            ViewBag.selectSubject = SelectQuestionList;

            return View(question);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult QuestionAdd(Question question)
        {
            if (question.Id!=0)
            {
                _questionBLL.Update(question);

            }
            else
            {
                _questionBLL.Add(question);

            }

            return RedirectToAction("QuestionsList");
        }
        
    }
}