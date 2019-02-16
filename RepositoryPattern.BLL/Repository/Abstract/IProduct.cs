using RepositoryPattern.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BLL.Repository.Abstract
{
    public  interface IProduct
    {
        List<Product> GetExpensiveProducts();
        Product GetProductByName(string name);
    }
}
