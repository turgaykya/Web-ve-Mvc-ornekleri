using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _01_WebForms_Intro
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Adım 1 :
            //int random = new Random().Next(10);
            //result.InnerText = random.ToString();

            //Adım 6 (Part 1): 
            if (!Page.IsPostBack)
                FillCategories(categoryList);
        }

       


        //Adım 4 (Part 1) :
        //public int rndCount = 0; 

        public void btnRunClick(object sender, EventArgs e)
        {
            //Adım 2 :
            //int random = new Random().Next(10);
            //result.InnerText = random.ToString();


            //Adım 3 : 
            /*
            string firstNumberStr = firstNumber.Value;
            string secondNumberStr = secondNumber.Value;

            int fNum = int.Parse(firstNumberStr);
            int sNum = int.Parse(secondNumberStr);



            //Buralar hep açıklama : 
            
            //int küçük = fNum > sNum ? sNum : fNum;
            //int büyük = fNum > sNum ? fNum : sNum;
            //if (fNum > sNum)
            //{
            //    büyük = fNum;
            //    küçük = sNum;
            //}
            //else
            //{
            //    küçük = fNum;
            //    büyük = sNum;
            //}
            //new Random().Next(küçük, büyük);

            int random = new Random().Next
                (fNum > sNum ? sNum : fNum,     //Küçük sayıyı bulan Ternary If
                 fNum > sNum ? fNum : sNum      //Büyük sayıyı bulan Ternary If
                 );

            result.InnerText = random.ToString();
            */


            //Adım 4 (Part 2) :
            /*
            int fNum = int.Parse(firstNumber.Value);
            int sNum = int.Parse(secondNumber.Value);

            int random = new Random().Next
               (fNum > sNum ? sNum : fNum,     //Küçük sayıyı bulan Ternary If
                fNum > sNum ? fNum : sNum      //Büyük sayıyı bulan Ternary If
                );

            newResult.InnerText = random.ToString();
            rndCount++;
            count.InnerText = rndCount.ToString();
            */

            //Adım 5 :
            //int fNum = int.Parse(firstNumber.Value);
            //int sNum = int.Parse(secondNumber.Value);

            //string productListHTML = GetProductsHTML(
            //    fNum > sNum ? sNum : fNum,     //Küçük sayıyı bulan Ternary If
            //    fNum > sNum ? fNum : sNum);    //Büyük sayıyı bulan Ternary If

            //result.InnerHtml = productListHTML;


            //Adım 6 : 
            int fNum = int.Parse(firstNumber.Value);
            int sNum = int.Parse(secondNumber.Value);
            string categoryName = categoryList.Items[categoryList.SelectedIndex].Value;

            string productListHTML = GetProductsHTMLWithCategory(
                fNum > sNum ? sNum : fNum,     //Küçük sayıyı bulan Ternary If
                fNum > sNum ? fNum : sNum,
                categoryName);    //Büyük sayıyı bulan Ternary If

            result.InnerHtml = productListHTML;
        }

        

        /// <summary>
        /// Adım 5 : This method returns Northwind products which has enough stock
        /// </summary>
        /// <param name="small">Min Stock Count</param>
        /// <param name="large">Max Stock Count</param>
        /// <returns></returns>
        private string GetProductsHTML(int small, int large)
        {
            string htmlString = "";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=.;database=Northwind;integrated security=sspi";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"
SELECT ProductName, UnitsInStock FROM Products
WHERE UnitsInStock BETWEEN @p1 AND @p2";

            cmd.Parameters.AddWithValue("@p1", small);
            cmd.Parameters.AddWithValue("@p2", large);

            //Alışılmış try-catch blokları yazılabilir ama;
            //devam : 

            cmd.Connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                htmlString += string.Format("{0} ({1}) <br />", rdr.GetString(0), rdr.GetInt16(1).ToString());
            }

            cmd.Connection.Close();

            return htmlString;
        }

        /// <summary>
        /// Adım 6 : Fills a select with Northwind Categories
        /// </summary>
        /// <param name="categoryList">A Select Element</param>
        private void FillCategories(HtmlSelect selectElement)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=.;database=Northwind;integrated security=sspi";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT CategoryName FROM Categories";

            cmd.Connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                //Gelen select elementine option eklediğimiz yer :
                selectElement.Items.Add(rdr.GetString(0));
            }

            cmd.Connection.Close();
        }

        /// <summary>
        /// Adım 6 : This method returns Northwind products which has enough stock with specific Category
        /// </summary>
        /// <param name="small">Min Stock Count</param>
        /// <param name="large">Max Stock Count</param>
        /// <param name="categoryName">Category Name</param>
        /// <returns></returns>
        private string GetProductsHTMLWithCategory(int small, int large, string categoryName)
        {
            string htmlString = "";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=.;database=Northwind;integrated security=sspi";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"
SELECT ProductName, UnitsInStock, CategoryName FROM Products p
JOIN Categories c ON p.CategoryId = c.CategoryId
WHERE 
    CategoryName = @categoryName
AND
    UnitsInStock BETWEEN @p1 AND @p2
";

            cmd.Parameters.AddWithValue("@p1", small);
            cmd.Parameters.AddWithValue("@p2", large);
            cmd.Parameters.AddWithValue("@categoryName", categoryName);

            //Alışılmış try-catch blokları yazılabilir ama;
            //devam : 

            cmd.Connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                htmlString += string.Format("{0} ({1}) ({2}) <br />"
                    , rdr.GetString(0)              //ProductName
                    , rdr.GetInt16(1).ToString()    //UnitsInStock
                    , rdr.GetString(2));            //CategoryName
            }

            cmd.Connection.Close();

            return htmlString;
        }


    }

}