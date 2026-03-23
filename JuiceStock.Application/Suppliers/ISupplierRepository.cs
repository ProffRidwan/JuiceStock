using JuiceStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceStock.Application.Suppliers
{
    public interface ISupplierRepository
    {

        Supplier GetById(Guid id);
        void Add(Supplier supplier);
        void Save();
    }
}
