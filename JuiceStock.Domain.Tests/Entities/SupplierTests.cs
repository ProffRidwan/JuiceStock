using JuiceStock.Domain.Entities;
using Xunit;

namespace JuiceStock.Domain.Tests.Entities
{
    public class SupplierTests
    {
        [Fact]
        public void Credit_ShouldIncreaseSupplierLiability()
        {
            // Arrange
            var supplier = new Supplier("Juice Supplier");
            supplier.Credit(30000m, "Juice supplied");

            // Act
            var balance = supplier.GetBalance();

            // Assert
            Assert.Equal(30000m, balance);
        }

        [Fact]
        public void Debit_ShouldReduceSupplierLiability()
        {
            // Arrange
            var supplier = new Supplier("Juice Supplier");
            supplier.Credit(30000m, "Juice supplied");
            supplier.Debit(10000m, "Partial payment");

            // Act
            var balance = supplier.GetBalance();

            // Assert
            Assert.Equal(20000m, balance);
        }

        [Fact]
        public void Debit_FullPayment_ShouldZeroBalance()
        {
            // Arrange
            var supplier = new Supplier("Juice Supplier");
            supplier.Credit(15000m, "Juice supplied");
            supplier.Debit(15000m, "Full payment");

            // Act
            var balance = supplier.GetBalance();

            // Assert
            Assert.Equal(0m, balance);
        }
    }
}