using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceStock.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public Guid ProductCategoryId { get; private set; }
        public ProductCategory ProductCategory { get; private set; }

        public Guid SupplierId { get; private set; }
        public Supplier Supplier { get; private set; }

        private Product() { }

        public Product(
            string name,
            decimal price,
            Guid productCategoryId,
            Guid supplierId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            ProductCategoryId = productCategoryId;
            SupplierId = supplierId;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new InvalidOperationException("Price must be greater than zero");

            Price = newPrice;
        }
    }
}
