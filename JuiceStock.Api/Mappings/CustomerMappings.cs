
using JuiceStock.Api.Contracts.Customers;
using JuiceStock.Domain.Entities;

namespace JuiceStock.Api.Mappings
{
    public static class CustomerMappings
    {
        public static CustomerResponse ToResponse(this Customer customer)
        {
            return new CustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                Balance = customer.GetBalance()
            };
        }
    }
}
