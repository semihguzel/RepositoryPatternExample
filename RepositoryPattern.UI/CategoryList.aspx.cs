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
            switch (e.CommandName)
            {
                case "ekle":
                    Response.Redirect("CreateCategory.aspx?CategoryId=" + e.CommandArgument);
                    break;

                case "git":
                    Response.Redirect("ProductList.aspx?CategoryId=" + e.CommandArgument);
                    break;
            }
        }
    }
}