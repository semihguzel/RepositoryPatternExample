using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BLL
{
    public class Tools
    {
        public static bool ValidationControl(string productName, string categoryName, int UnitsInStock, decimal UnitPrice)
        {
            if (productName == "" || categoryName == "" || UnitsInStock == 0 || UnitPrice == 0)
                return true;
            else
                return false;
        }
    }
}
