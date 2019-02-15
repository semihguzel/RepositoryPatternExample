using RepositoryPattern.DAL.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BLL.ProductControls
{
    public class CreateProductControl
    {
       public bool DoesProductExists(string productName)
        {
            ProductConcrete productConcrete = new ProductConcrete();
            var result = productConcrete.GetProductByName(productName);
            if (result == null)
                return false;
            else
                return true;
        }
    }
}
