using System;
using Business;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _01_Entities;
using LMSTS.Models;
using System.Text.RegularExpressions;
using LMSTS.Helper;

namespace LMSTS.Controllers
{
    [LoginAttribute]
    public class ForumController : Controller
    {
        TopicBLL _topicBLL = new TopicBLL();
        Topic _topic = new Topic();


        Comment _comment = new Comment();

        // GET: Forum
        //Topic Başlığı
        public ActionResult ForumHeadList()
        {
            List<Topic> topicDetailList = _topicBLL.GetAll((int)Session["LoginID"]).ToList();

            return View(topicDetailList);
        }

        public ActionResult OpenedTopic(int id = 0)
        {
            Topic topic;
            topic = _topicBLL.Get(id);
            topic.Hit = (short)(topic.Hit + 1);
            _topicBLL.Update(topic);
            return View(topic);
        }

        public ActionResult OpenedTopicNoHit(int id = 0)
        {
            Topic topic;
            topic = _topicBLL.Get(id);
            _topicBLL.Update(topic);
            return View("OpenedTopic",topic);
        }

        public ActionResult NewTopicAdd()
        {
            List<EducationGroup> educationList = _topicBLL.GetEducationAll(5);
            SelectList selectEducationList = new SelectList(educationList, "Id", "Name");

            ViewBag.eduList = selectEducationList;

            Topic topic = new Topic();

            return View(topic);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewTopicAdd(Topic item)
        {
          
                item.DateOfCreation = DateTime.Now;
                item.UserID = (int)Session["LoginID"];
            item.Hit = 0;
                item.IsActive = true;
                _topicBLL.Add(item);
            
            return RedirectToAction("ForumHeadList");
        }

        [ValidateInput(false)]
        public ActionResult AddComment(int Id, string CommentDescription)
        {
            Comment comment = new Comment();
            comment.TopicID = Id;
            comment.Description = CommentDescription;
            comment.DateOfComment = DateTime.Now;
            comment.UserID =(int)Session["LoginID"]; 
            _topicBLL.CommentAdd(comment);


            return RedirectToAction("OpenedTopicNoHit/" + Id);
        }

        public ActionResult BlockTopic(int id)
        {
            Topic item = _topicBLL.Get(id);
            if (item.Id != 0)
            {
                item.IsActive = false;
                item.DateOfLock = DateTime.Now;
                _topicBLL.Update(item);
            }

            return RedirectToAction("ForumHeadList");
        }

    }
}