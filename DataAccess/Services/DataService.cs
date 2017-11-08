using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repository;

namespace DataAccess.Services
{
    public class DataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Provisioner> _provisionerRepository;
        private readonly IRepository<Supply> _supplyRepository;

        public List<Supply> GetSupplies(int skip, int quantity)
        {
            var query = _supplyRepository.GetAll();
            var count = query.Count();

            var list = count > 0 ?
                query.Skip(skip).Take(Math.Min(quantity, count)).ToList() : new List<Supply>();
                       
            return list;
        }

        public Supply AddSupply(Supply supply)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                _supplyRepository.Create(supply);
                supply.Provisioner = _provisionerRepository.GetById(supply.Provisioner.Id);
                supply.Product = _productRepository.GetById(supply.Product.Id);
                _unitOfWork.Commit();
                return supply;
            } catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return null;
            }
        }

        public void DeleteSupply(int supplyId)
        {
            _unitOfWork.BeginTransaction();
            _supplyRepository.Delete(supplyId);
            _unitOfWork.Commit();
        }

        public void UpdateSupply(Supply supply)
        {
            _unitOfWork.BeginTransaction();
            _supplyRepository.Update(supply);
            _unitOfWork.Commit();
        }
        
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

        public void DeleteProduct(int productId)
        {
            _unitOfWork.BeginTransaction();
            DeleteSuppliesReferencedToProduct(productId);
            _productRepository.Delete(productId);
            _unitOfWork.Commit();
        }

        private void DeleteSuppliesReferencedToProduct(int productId)
        {
            var supplies = _supplyRepository.GetAll().Where(it => it.Product.Id == productId);
            foreach (var supply in supplies)
            {
                _supplyRepository.Delete(supply.Id);
            }
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
            _unitOfWork.BeginTransaction();
            _provisionerRepository.Update(provisioner);
            _unitOfWork.Commit();
        }

        public Product GetProvisioner(int id)
        {
            return _productRepository.GetById(id);
        }

        public void DeleteProvisioner(int provisionerId)
        {
            _unitOfWork.BeginTransaction();
            DeleteSuppliesRefencedToProvisioner(provisionerId);

            _provisionerRepository.Delete(provisionerId);
            _unitOfWork.Commit();
        }

        private void DeleteSuppliesRefencedToProvisioner(int provisionerId)
        {
            var list = _supplyRepository.GetAll().Where(it => it.Provisioner.Id == provisionerId);
            foreach (var supply in list)
            {
                _supplyRepository.Delete(supply.Id);
            }
        }
    }
}
