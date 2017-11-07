using System;
using System.Diagnostics;
using DataAccess.Entities;
using DataAccess.Repository;

namespace DataAccess.Services
{
    public class DataService
    {
        private readonly IRepository<Product> _productRepository;
        private IRepository<Provisioner> _provisionerRepository;
        private IRepository<Supply> _supplyRepository;
        private IUnitOfWork _unitOfWork;
        public DataService(IUnitOfWork unitOfWork)
        {
            _productRepository = new Repository<Product>(unitOfWork);
            _provisionerRepository = new Repository<Provisioner>(unitOfWork);
            _supplyRepository = new Repository<Supply>(unitOfWork);
            _unitOfWork = unitOfWork;
        }

        public Product AddProduct()
        {
            var product = new Product()
            {
                Code = Guid.NewGuid(),
                Name = "Новый продукт " + DateTime.Now
            };

            // По умолчанию создание продукта транзакционно
            _productRepository.Create(product);
            return product;
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                _productRepository.Update(product);
            }
            catch (Exception e)
            {                
                return false;
            }

            return true;
        }
    }
}
