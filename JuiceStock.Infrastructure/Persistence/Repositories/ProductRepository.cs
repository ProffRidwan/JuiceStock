using JuiceStock.Application.Products;
using JuiceStock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceStock.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly JuiceStockDbContext _context;

        public ProductRepository(JuiceStockDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public Product GetById(Guid id)
        {
            return _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.Supplier)
                .FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<Product> Query()
        {
            return _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.Supplier);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
