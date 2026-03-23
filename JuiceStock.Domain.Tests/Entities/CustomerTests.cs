using JuiceStock.Domain.Entities;
using Xunit;

namespace JuiceStock.Domain.Tests.Entities
{
    public class CustomerTests
    {
        [Fact]
        public void Debit_ShouldIncreaseCustomerBalance()
        {
            // Arrange
            var customer = new Customer("Ridwan");
            customer.Debit(20000m, "Juice purchase");

            // Act
            var balance = customer.GetBalance();

            // Assert
            Assert.Equal(20000m, balance);
        }

        [Fact]
        public void Credit_ShouldReduceCustomerBalance()
        {
            // Arrange
            var customer = new Customer("Ridwan");
            customer.Debit(20000m, "Juice purchase");
            customer.Credit(5000m, "Partial payment");

            // Act
            var balance = customer.GetBalance();

            // Assert
            Assert.Equal(15000m, balance);
        }

        [Fact]
        public void Credit_FullPayment_ShouldZeroBalance()
        {
            // Arrange
            var customer = new Customer("Ridwan");
            customer.Debit(10000m, "Juice purchase");
            customer.Credit(10000m, "Full payment");

            // Act
            var balance = customer.GetBalance();

            // Assert
            Assert.Equal(0m, balance);
        }
    }
}