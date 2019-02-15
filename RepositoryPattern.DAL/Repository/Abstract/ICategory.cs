using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL.Repository.Abstract
{
    public interface ICategory
    {
        int CategoryIdByCategoryName(string categoryName);
    }
}
