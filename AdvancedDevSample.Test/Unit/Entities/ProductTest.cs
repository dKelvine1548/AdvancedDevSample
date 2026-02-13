using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Exceptions;

namespace AdvancedDevSample.Test.Domain.Entities
{
    public class ProductTest
    {
        [Fact]
        public void Create_Product_Should_Be_Active()
        {
            var product = new Product(Guid.NewGuid(), "PC", 10, true);

            Assert.True(product.IsActive);
        }

        [Fact]
        public void ChangePrice_Should_Update_Price()
        {
            var product = new Product(Guid.NewGuid(), "PC", 10, true);

            product.ChangePrice(20);

            Assert.Equal(20, product.Price);
        }

        [Fact]
        public void ChangePrice_Should_Throw_When_Negative()
        {
            var product = new Product(Guid.NewGuid(), "PC", 10, true);

            Assert.Throws<DomainException>(() => product.ChangePrice(-5));
        }

        [Fact]
        public void Cannot_ChangePrice_When_Inactive()
        {
            var product = new Product(Guid.NewGuid(), "PC", 10, false);

            Assert.Throws<DomainException>(() => product.ChangePrice(20));
        }

    }
}
