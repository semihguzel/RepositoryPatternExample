using RepositoryPattern.DAL.Repository.Abstract;
using RepositoryPattern.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL.Repository.Concrete
{
    public class CategoryConcrete : ICategory
    {
        public IRepository<Category> _categoryRepository;
        public IUnitOfWork _categoryUnitOfWork;
        private DbContext _dbContext;

        public CategoryConcrete()
        {
            _dbContext = new Context();
            _categoryUnitOfWork = new EFUnitOfWork(_dbContext);
            _categoryRepository = _categoryUnitOfWork.GetRepository<Category>();
        }

        public int CategoryIdByCategoryName(string categoryName)
        {
            return _categoryRepository.GetEntity().Where(x => x.CategoryName.ToLower() == categoryName.ToLower()).FirstOrDefault().CategoryID;
        }
    }
}
