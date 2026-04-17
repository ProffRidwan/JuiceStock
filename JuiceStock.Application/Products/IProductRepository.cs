using JuiceStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceStock.Application.Products
{
  
       public interface IProductRepository
        {
            void Add(Product product);
            Product GetById(Guid id);
            IQueryable<Product> Query();
            void Save();
        }
    
}
