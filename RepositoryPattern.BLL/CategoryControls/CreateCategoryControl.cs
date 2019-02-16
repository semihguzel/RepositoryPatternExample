using RepositoryPattern.BLL.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BLL.CategoryControls
{
    public class CreateCategoryControl
    {
        public bool DoesCategoryExists(string categoryName)
        {
            CategoryConcrete categoryConcrete = new CategoryConcrete();
            var query = categoryConcrete._categoryRepository.GetEntity().Where(x => x.CategoryName == categoryName).FirstOrDefault();
            if (query == null)
                return false;
            else
                return true;
        }
    }
}
