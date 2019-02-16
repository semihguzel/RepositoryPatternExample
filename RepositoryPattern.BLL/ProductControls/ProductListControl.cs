using RepositoryPattern.BLL.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BLL.ProductControls
{
    public class ProductListControl
    {
        public bool DoesProductsExits()
        {
            ProductConcrete productConcrete = new ProductConcrete();
            var result = productConcrete._productRepository.GetAll();
            if (result.Count == 0)
                return false;
            else
                return true;
        }
    }
}
