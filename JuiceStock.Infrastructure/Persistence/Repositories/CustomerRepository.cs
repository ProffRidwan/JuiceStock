using JuiceStock.Application.Customers;
using JuiceStock.Domain.Entities;
using JuiceStock.Infrastructure.Persistence;

namespace JuiceStock.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly JuiceStockDbContext _context;

        public CustomerRepository(JuiceStockDbContext context)
        {
            _context = context;
        }

        public Customer GetById(Guid id)
        {
            return _context.Customers.Find(id);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}