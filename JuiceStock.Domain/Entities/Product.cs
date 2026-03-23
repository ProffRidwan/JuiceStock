using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceStock.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid CategoryId { get; private set; }

        private Product() { }

        public Product(string name, Guid categoryId)
        {
            Id = Guid.NewGuid();
            Name = name;
            CategoryId = categoryId;
        }
    }
}
