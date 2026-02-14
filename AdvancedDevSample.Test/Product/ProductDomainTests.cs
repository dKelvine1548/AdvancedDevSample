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
        public void ChangePrice_Should_Update_Product()
        {
            var repo = new FakeProductRepository();
            var service = new ProductService(repo);

            var id = service.Create(new CreateProductDto { Name = "Desk", Price = 100 });

            service.ChangePrice(id, 150);

            var product = repo.GetByIdProduct(id);

            Assert.Equal(150, product.Price);
        }
    }
}
