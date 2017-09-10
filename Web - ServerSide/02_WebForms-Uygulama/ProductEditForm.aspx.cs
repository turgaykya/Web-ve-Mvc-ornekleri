using _02_WebForms_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_WebForms_Uygulama
{
    public partial class ProductEditForm : System.Web.UI.Page
    {
        NorthwindEntities _dbContext;
        Product _product;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new NorthwindEntities();

            string productIdStr = Request.QueryString["id"];
            productIdStr = productIdStr ?? "0";

            int productId = int.Parse(productIdStr);

            if (productId==0)
            {
                _product = new Product();
            }
            else
            {
                _product = _dbContext.Products.Find(productId);

                if (!Page.IsPostBack)
                {
                    txtProductName.Text = _product.ProductName;
                    txtUnitsInStock.Text = _product.UnitsInStock.ToString();
                }
                btnSave.Text = "Güncelle";
            }

            var allCategories = _dbContext.Categories.Select(
                x => new
                {
                    x.CategoryID,
                    x.CategoryName
                }).ToList();

            if (!IsPostBack)
            {
                dropDownCategory.DataSource = allCategories;
                dropDownCategory.DataValueField = "CategoryID";
                dropDownCategory.DataTextField = "CategoryName";
                dropDownCategory.DataBind(); 
            }   

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ProductAdd();
        }

        private void ProductAdd()
        {
            _product.ProductName = txtProductName.Text;
            _product.CategoryID = int.Parse(dropDownCategory.SelectedValue);
            _product.UnitsInStock = short.Parse(txtUnitsInStock.Text);


            if (_product.ProductID==0)
            {
                _dbContext.Products.Add(_product);
            }
            _dbContext.SaveChanges();

            Response.Redirect("ProductListForm.aspx");
        }
    }
}