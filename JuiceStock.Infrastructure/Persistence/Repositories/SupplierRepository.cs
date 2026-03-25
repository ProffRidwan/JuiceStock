using JuiceStock.Application.Customers;
using JuiceStock.Application.Suppliers;
using JuiceStock.Domain.Entities;
using JuiceStock.Infrastructure.Persistence;

namespace JuiceStock.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly JuiceStockDbContext _context;

        public SupplierRepository(JuiceStockDbContext context)
        {
            _context = context;
        }

        public Supplier GetById(Guid id)
        {
            return _context.Suppliers.Find(id);
        }

        public void Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<Supplier> Query()
        {
            return _context.Suppliers;
        }
    }
}