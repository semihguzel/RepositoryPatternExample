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
    public partial class CreateCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            CreateProductControl createProductControl = new CreateProductControl();
            CreateCategoryControl createCategoryControl = new CreateCategoryControl();

            if (createCategoryControl.DoesCategoryExists(txtCategoryName.Text))
            {
                Response.Write("<script>alert('Bu isimde kategori var! Farkli bir kategori ismi giriniz.')</script>");
                return;
            }
            else
            {
                CategoryConcrete categoryConcrete = new CategoryConcrete();
                Category category = new Category();

                category.CategoryName = txtCategoryName.Text;
                category.Description = txtDescription.Text;

                categoryConcrete._categoryRepository.Insert(category);
                categoryConcrete._categoryUnitOfWork.SaveChanges();
                categoryConcrete._categoryUnitOfWork.Dispose();

                Response.Write("<script>alert('Kayıt işlemi başarıyla gerçekleştirilmiştir!')</script>");
            }
        }

        protected void btnKategorilereGeriDon_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryList.aspx");
        }
    }
}