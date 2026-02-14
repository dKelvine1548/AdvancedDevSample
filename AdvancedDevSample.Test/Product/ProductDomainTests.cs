using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Application.services;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Exceptions;
using AdvancedDevSample.Infrastructure.Repositories;

namespace AdvancedDevSample.Test.Component
{
    public class ProductServiceTest
    {
        [Fact]
        public void ChangePrice_Should_Throw_When_Negative()
        {
            var product = new Product(Guid.NewGuid(), 10, true, "Test");

            Assert.Throws<DomainException>(() => product.ChangePrice(-5));
        }

        [Fact]
        public void ChangePrice_Should_Work_When_Valid()
        {
            var product = new Product(Guid.NewGuid(), 10, true, "Test");

            product.ChangePrice(25);

            Assert.Equal(25, product.Price);
        }
    }
}
