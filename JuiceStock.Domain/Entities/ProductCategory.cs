using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceStock.Domain.Entities
{
    public class ProductCategory
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        // Required by EF Core later
        private ProductCategory() { }

        public ProductCategory(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
