using _02_WebForms_Uygulama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_WebForms_Uygulama
{
    public partial class CategoryEditForm : System.Web.UI.Page
    {
        NorthwindEntities _dbContext;
        Category _category;

        protected void Page_Load(object sender, EventArgs e)
        {
            _dbContext = new NorthwindEntities();
            string categoryIdStr = Request.QueryString["id"];

            //TODO: Özel Ternary if kullanımı (null check)
            categoryIdStr = categoryIdStr ?? "0";
            //--------    eğer categoryIdStr ye gelen değer null ise, onun yerine 0 at

            int categoryId = int.Parse(categoryIdStr);

            //TODO: Görev ataması için todo kullanırız. TaskList'de görünür. wiew den açılır.

            if (categoryId == 0)
            {
                //YENİ KAYIT
                _category = new Category();
            }
            else
            {
                //GÜNCELLEME
                _category = _dbContext.Categories.Find(categoryId);


#if DEBUG
                if (!Page.IsPostBack)
                {
                    txtCategoryName.Text = _category.CategoryName;
                    txtDescription.Text = _category.Description; 
                }
#endif


                btnSave.Text = "Güncelle";
            }

        }

      


        /// <summary>
        /// Category Add Method
        /// </summary>
       public void CategoryAdd()
       {
           //Category cat = new Category();

           _category.CategoryName = txtCategoryName.Text;
           _category.Description = txtDescription.Text;

           if (_category.CategoryID == 0)
           {
               //YENİ KAYIT
               _dbContext.Categories.Add(_category);
           }

           _dbContext.SaveChanges();

           Response.Redirect("CategoryListForm.aspx");
       }

       protected void btnSave_Click(object sender, EventArgs e)
       {
           CategoryAdd();
       }

       
    }
}