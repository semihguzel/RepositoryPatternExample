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
    public partial class UpdateCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            CategoryConcrete categoryConcrete = new CategoryConcrete();
            Category category = categoryConcrete._categoryRepository.GetById(Convert.ToInt32(Request.QueryString["CategoryId"]));
            txtCategoryName.Text = category.CategoryName;
            txtDescription.Text = category.Description;
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            CreateCategoryControl createCategoryControl = new CreateCategoryControl();
            if (createCategoryControl.DoesCategoryExists(txtCategoryName.Text))
            {
                Response.Write("<script>alert('Bu isimle kayitli kategori bulunmaktadır. Farkli bir kategori adı giriniz!')</script>");
                return;
            }
            else
            {
                CategoryConcrete categoryConcrete = new CategoryConcrete();
                int id = Convert.ToInt32(Request.QueryString["CategoryId"]);
                Category category = categoryConcrete._categoryRepository.GetById(id);
                category.CategoryName = txtCategoryName.Text;
                category.Description = txtDescription.Text;

                categoryConcrete._categoryRepository.Update(category);
                categoryConcrete._categoryUnitOfWork.SaveChanges();
                categoryConcrete._categoryUnitOfWork.Dispose();
                Response.Write("<script>alert('Kategori basariyla guncellestirildi!')</script>");
            }
        }

        protected void btnKategorilereGeriDon_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryList.aspx");
        }
    }
}