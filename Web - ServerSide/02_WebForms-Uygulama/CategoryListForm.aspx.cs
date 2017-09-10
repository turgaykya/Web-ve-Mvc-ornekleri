using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _02_WebForms_Uygulama.Model;

namespace _02_WebForms_Uygulama
{
    public partial class CategoryListForm : System.Web.UI.Page
    {

        NorthwindEntities _dbContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new NorthwindEntities();


            //var allCategories = (from c in _dbContext.Categories
            //                     select new
            //                     {
            //                         c.CategoryID,
            //                         c.CategoryName,
            //                         c.Description
            //                     }).ToString();

            var allCategories = _dbContext.Categories.Select(
                x => new
                {
                    x.CategoryID,
                    x.CategoryName,
                    x.Description
                }).ToList();

            gridCategories.DataSource = allCategories;
            gridCategories.DataBind();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string categoryIdStr = (sender as Button).Attributes["data-id"];
            int categoryId = int.Parse(categoryIdStr);

            Category cat = _dbContext.Categories.Find(categoryId);
            _dbContext.Categories.Remove(cat);
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

            }

            //gridCategories.DataSource = _dbContext.Categories.ToList();
            //gridCategories.DataBind();

            Response.Redirect("CategoryListForm.aspx");
        }
    }
}