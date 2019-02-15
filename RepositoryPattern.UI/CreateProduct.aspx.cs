using RepositoryPattern.BLL;
using RepositoryPattern.BLL.CategoryControls;
using RepositoryPattern.BLL.ProductControls;
using RepositoryPattern.DAL.Repository.Concrete;
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
            CreateProductControl createProductControl = new CreateProductControl();
            if (Tools.ValidationControl(txtProductName.Text, txtCategoryName.Text, Convert.ToInt32(txtUnitsInStock.Text), Convert.ToInt32(txtUnitPrice.Text)))
            {
                Response.Write("<script>alert('Lutfen kutucuklari doldurunuz!')</script>");
                return;
            }
            if (!createProductControl.DoesProductExists(txtProductName.Text))
            {
                Response.Write("<script>alert('Bu isimde bir urun var! Farkli bir urun ismi giriniz.')</script>");
                return;
            }
            else
            {
                CategoryConcrete categoryConcrete = new CategoryConcrete();
                ProductConcrete productConcrete = new ProductConcrete();

                int categoryId = categoryConcrete.CategoryIdByCategoryName(txtCategoryName.Text);
                if (categoryId == 0)
                    Response.Write("alert('Girdiginiz Kategori adi bulunmamaktadir!')");
                else
                {
                    Product product = new Product();
                    product.CategoryID = categoryId;
                    product.ProductName = txtProductName.Text;
                    product.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                    product.UnitsInStock = Convert.ToInt32(txtUnitsInStock.Text);

                    productConcrete._productRepository.Insert(product);
                    productConcrete._productUnitOfWork.SaveChanges();
                    productConcrete._productUnitOfWork.Dispose();
                }
            }
        }
    }
}