using RepositoryPattern.BLL.CategoryControls;
using RepositoryPattern.BLL.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RepositoryPattern.UI
{
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            CategoryListControl categoryListControl = new CategoryListControl();
            if (!categoryListControl.DoesCategoriesExits())
            {
                Response.Write("<script>alert('Kayitli urun bulunmamaktadir!')</script>");
                return;
            }
            else
            {
                CategoryConcrete categoryConcrete = new CategoryConcrete();
                grdCategories.DataSource = categoryConcrete._categoryRepository.GetAll();
                grdCategories.DataKeyNames = new string[] { "CategoryID", "CategoryName" };
                grdCategories.DataBind();
                categoryConcrete._categoryUnitOfWork.Dispose();
            }
        }

        protected void grdCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            CategoryConcrete categoryConcrete = new CategoryConcrete();

            switch (e.CommandName)
            {
                case "git":
                    Response.Redirect("ProductList.aspx?CategoryId=" + e.CommandArgument);
                    break;
                case "sil":
                    categoryConcrete._categoryRepository.Delete(categoryConcrete._categoryRepository.GetById(Convert.ToInt32(e.CommandArgument)));
                    Response.Write("<script>alert('Ürün Silinmiştir...')</script>");
                    Response.Redirect("CategoryList.aspx");
                    break;
                case "guncelle":
                    Response.Redirect("UpdateCategory.aspx?CategoryId=" + e.CommandArgument);
                    break;
            }
        }

        protected void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateCategory.aspx");
        }
    }
}