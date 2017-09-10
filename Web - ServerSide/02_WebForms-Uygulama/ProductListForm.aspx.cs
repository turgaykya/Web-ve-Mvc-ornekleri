using _02_WebForms_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_WebForms_Uygulama
{
    public partial class ProductListForm : System.Web.UI.Page
    {

        NorthwindEntities _dbContext;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new NorthwindEntities();

            var allProducts = _dbContext.Products.Select(
                x => new
                { 
                    x.ProductID,
                    x.ProductName,
                    x.Category.CategoryName,
                    x.UnitsInStock
                }).ToList();
            gridProducts.DataSource = allProducts;
            gridProducts.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string productIdStr = (sender as Button).Attributes["data-id"];
            int productId = int.Parse(productIdStr);

            Product product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

            }
            Response.Redirect("ProductListForm.aspx");


        }

        
    }
}