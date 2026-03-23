using JuiceStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceStock.Application.Customers
{
    public interface ICustomerRepository
    {
        Customer GetById(Guid id);
        void Add(Customer customer);
        void Save();
    }
}
