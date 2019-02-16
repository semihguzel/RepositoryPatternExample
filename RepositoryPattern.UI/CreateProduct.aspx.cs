using RepositoryPattern.BLL;
using RepositoryPattern.BLL.CategoryControls;
using RepositoryPattern.BLL.ProductControls;
using RepositoryPattern.BLL.Repository.Concrete;
using RepositoryPattern.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepositoryPattern.UI
{
    public partial class CreateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            CreateProductControl createProductControl = new CreateProductControl();
            CreateCategoryControl createCategoryControl = new CreateCategoryControl();

            if (createProductControl.DoesProductExists(txtProductName.Text))
            {
                Response.Write("<script>alert('Bu isimde bir urun var! Farkli bir urun ismi giriniz.')</script>");
                return;
            }
            else
            {
                CategoryConcrete categoryConcrete = new CategoryConcrete();
                ProductConcrete productConcrete = new ProductConcrete();

                if (!createCategoryControl.DoesCategoryExists(txtCategoryName.Text))
                {
                    Response.Write("<script>alert('Bu kategori bulunmamaktadır. Kategori adını doğru giriniz!')</script>");
                    return;
                }
                else
                {

                    int categoryId = categoryConcrete.CategoryIdByCategoryName(txtCategoryName.Text);
                    Product product = new Product();
                    product.CategoryID = categoryId;
                    product.ProductName = txtProductName.Text;
                    product.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                    product.UnitsInStock = Convert.ToInt32(txtUnitsInStock.Text);

                    productConcrete._productRepository.Insert(product);
                    productConcrete._productUnitOfWork.SaveChanges();
                    productConcrete._productUnitOfWork.Dispose();

                    Response.Write("<script>alert('Kayıt işlemi başarıyla gerçekleştirilmiştir!')</script>");
                }
            }
        }
        protected void btnKategorilereGeriDon_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryList.aspx");

        }
    }
}