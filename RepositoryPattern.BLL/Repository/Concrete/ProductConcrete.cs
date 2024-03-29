﻿using RepositoryPattern.BLL.Repository.Abstract;
using RepositoryPattern.DAL;
using RepositoryPattern.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.BLL.Repository.Concrete
{
    public class ProductConcrete : IProduct
    {
        public readonly IRepository<Product> _productRepository;
        public readonly IUnitOfWork _productUnitOfWork;
        private DbContext _dbContext;

        public ProductConcrete()
        {
            _dbContext = new Context();
            _productUnitOfWork = new EFUnitOfWork(_dbContext);
            _productRepository = _productUnitOfWork.GetRepository<Product>();
        }

        public List<Product> GetExpensiveProducts()
        {
            return _productRepository.GetEntity().OrderByDescending(x => x.UnitPrice).Take(10).ToList();
        }

        public Product GetProductByName(string name)
        {
            return _productRepository.GetEntity().Where(x => x.ProductName == name).FirstOrDefault();
        }
    }
}
