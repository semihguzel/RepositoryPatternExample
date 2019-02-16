using RepositoryPattern.BLL.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BLL.CategoryControls
{
    public class CategoryListControl
    {
        public bool DoesCategoriesExits()
        {
            CategoryConcrete productConcrete = new CategoryConcrete();
            var result = productConcrete._categoryRepository.GetAll();
            if (result.Count == 0)
                return false;
            else
                return true;
        }
    }
}
