using RepositoryPattern.BLL.CategoryControls;
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
    public partial class UpdateProduct : System.Web.UI.Page
    {
        Product product;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ProductConcrete productConcrete = new ProductConcrete();
            int productId = Convert.ToInt32(Request.QueryString["ProductId"]);
            product = productConcrete._productRepository.GetById(productId);
            txtProductName.Text = product.ProductName;
            txtUnitPrice.Text = product.UnitPrice.ToString();
            txtUnitsInStock.Text = product.UnitsInStock.ToString();
            txtCategoryName.Text = product.Category.CategoryName;
        }

        protected void btnKategorilereGeriDon_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryList.aspx");
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            CreateCategoryControl createCategoryControl = new CreateCategoryControl();
            if (!createCategoryControl.DoesCategoryExists(txtCategoryName.Text))
            {
                Response.Write("<script>alert('Bu kategori bulunmamaktadır. Kategori adını doğru giriniz!')</script>");
                return;
            }
            else
            {
                //sayfada her islem yapildiginda degiskenler sifirlandigi icin urun nesnesi QueryString ile gelen id ile tanimlanip textbox'lar icerisine yazan degerler ile degistirilecek.
                ProductConcrete productConcrete = new ProductConcrete();
                CategoryConcrete categoryConcrete = new CategoryConcrete();
                int productId = Convert.ToInt32(Request.QueryString["ProductId"]);
                product = productConcrete._productRepository.GetById(productId);

                int categoryId = categoryConcrete.CategoryIdByCategoryName(txtCategoryName.Text);
                product.CategoryID = categoryId;
                product.ProductName = txtProductName.Text;
                product.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                product.UnitsInStock = Convert.ToInt32(txtUnitsInStock.Text);


                productConcrete._productRepository.Update(product);
                productConcrete._productUnitOfWork.SaveChanges();
                productConcrete._productUnitOfWork.Dispose();
                Response.Write("<script>alert('Urun basariyla guncellestirilmistir!')</script>");

            }
        }
    }
}