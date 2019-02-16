using RepositoryPattern.BLL.ProductControls;
using RepositoryPattern.BLL.Repository.Concrete;
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
                        x.ProductID,
                        x.ProductName,
                        x.UnitPrice,
                        x.UnitsInStock,
                        x.CategoryID,
                        x.Category.CategoryName
                    }).ToList();
                    grdProducts.DataKeyNames = new string[] { "ProductID" };
                    grdProducts.DataBind();

                }
            }
        }

        protected void btnKategoriler_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryList.aspx");
        }

        protected void grdProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ProductConcrete productConcrete = new ProductConcrete();
            switch (e.CommandName)
            {

                case "sil":
                    Response.Write("<script>alert('Ürün Silinmiştir...')</script>");
                    productConcrete._productRepository.Delete(productConcrete._productRepository.GetById(Convert.ToInt32(e.CommandArgument)));
                    Response.Redirect("CategoryList.aspx");
                    break;
                case "guncelle":
                    Response.Redirect("UpdateProduct.aspx?ProductId=" + e.CommandArgument);
                    break;
            }
        }

        protected void btnUrunEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateProduct.aspx");

        }
    }
}