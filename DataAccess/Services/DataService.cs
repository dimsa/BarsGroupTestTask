using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repository;

namespace DataAccess.Services
{
    public class DataService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Provisioner> _provisionerRepository;
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

        public List<Product> GetProducts(int skip, int quantity)
        {
            var query = _productRepository.GetAll();
            var count = query.Count();

            var list = count > 0 ?
                query.Skip(skip).Take(Math.Min(quantity, count)).ToList() : new List<Product>();

            return list;
        }

        public void UpdateProduct(Product product)
        {
            _unitOfWork.BeginTransaction();
            _productRepository.Update(product);
            _unitOfWork.Commit();
                     
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetById(id);
        }

        public void DeleteProduct(Product product)
        {
            _unitOfWork.BeginTransaction();
            _productRepository.Delete(product.Id);
            _unitOfWork.Commit();
        }

        public Provisioner AddProvisioner()
        {
            var provisioner = new Provisioner()
            {                
                Name = "Новый поставщик " + DateTime.Now
            };

            // По умолчанию создание продукта транзакционно
            _provisionerRepository.Create(provisioner);
            return provisioner;
        }

        public List<Provisioner> GetProvisioner(int skip, int quantity)
        {
            var query = _provisionerRepository.GetAll();
            var count = query.Count();

            var list = count > 0 ? 
                query.Skip(skip).Take(Math.Min(quantity, count)).ToList() : new List<Provisioner>();

            return list;
        }

        public void UpdateProvisioner(Provisioner provisioner)
        {
            _provisionerRepository.Update(provisioner);
        }

        public Product GetProvisioner(int id)
        {
            return _productRepository.GetById(id);
        }

        public void DeleteProvisioner(Provisioner provisioner)
        {
            _provisionerRepository.Delete(provisioner.Id);
        }

    }
}
