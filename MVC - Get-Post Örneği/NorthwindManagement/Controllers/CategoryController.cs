using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindManagement.Controllers
{
    
    public class CategoryController : Controller
    {
        NorthwindEntities _dbContext = new NorthwindEntities();
       

        // GET: Category
        public ActionResult Index()
        {
            //List<Category> categoryList = _dbContext.Categories.ToList();

            var categoryList = _dbContext
                .Categories
                .Select(c => new Models.CategoryListItemVM
                {
                    Id = c.CategoryID,
                    Name = c.CategoryName
                })
                .ToList();

            return View(categoryList);
        }

        //Action'ı HttpGet Attribute'ü ile işaretlemesen de varsayılan değer Get metodudur.
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category category =
                _dbContext
                .Categories
                .SingleOrDefault(c => c.CategoryID == id);

            if (category != null)
            {
                return View(category);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            //Category currentCategory = _dbContext
            //    .Categories
            //    .SingleOrDefault(c => c.CategoryID == category.CategoryID);

            //currentCategory.CategoryName = category.CategoryName;
            //currentCategory.Description = category.Description;


            _dbContext.Entry(category).State = System.Data.Entity.EntityState.Modified;
            _dbContext.Entry(category).Property("Picture").IsModified = false;

            _dbContext.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}