using JuiceStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceStock.Application.Products
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Guid CreateProduct(string name, decimal price, Guid categoryId, Guid supplierId)
        {
            var product = new Product(name, price, categoryId, supplierId);

            _repository.Add(product);
            _repository.Save();

            return product.Id;
        }

        public Product GetProduct(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}
