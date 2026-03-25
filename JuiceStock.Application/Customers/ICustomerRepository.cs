using JuiceStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JuiceStock.Application.Customers
{
    public interface ICustomerRepository
    {
        Customer GetById(Guid id);
        void Add(Customer customer);
        void Save();
        IQueryable<Customer> Query();
    }

}
