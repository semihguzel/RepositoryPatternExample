using RepositoryPattern.BLL.ProductControls;
using RepositoryPattern.DAL.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepositoryPattern.UI
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            else
            {
                ProductListControl productListControl = new ProductListControl();
                if (!productListControl.DoesProductsExits())
                {
                    Response.Write("<script>alert('Kayitli urun bulunmamaktadir!')</script>");
                    return;
                }
                else
                {
                    ProductConcrete productConcrete = new ProductConcrete();
                    int categoryId = Convert.ToInt32(Request.QueryString["CategoryId"]);
                    grdProducts.DataSource = productConcrete._productRepository.GetAll().Where(x => x.CategoryID == categoryId).Select(x => new
                    {
                        x.ProductName,
                        x.UnitPrice,
                        x.UnitsInStock,
                        x.Category.CategoryName
                    }).ToList();
                    grdProducts.DataBind();

                }
            }
        }

        protected void btnKategoriler_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryList.aspx");
        }
    }
}