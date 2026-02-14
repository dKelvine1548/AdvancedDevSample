using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Application.services;
using AdvancedDevSample.Infrastructure.Repositories;

namespace AdvancedDevSample.Test.Component
{
    public class ProductServiceTest
    {
        private readonly ProductService _service;

        public ProductServiceTest()
        {
            var repo = new EfProductRepository();
            _service = new ProductService(repo);
        }

        [Fact]
        public void Should_Create_Product()
        {
            var id = _service.Create(new CreateProductDto
            {
                Name = "Laptop",
                Price = 1000
            });

            var product = _service.GetById(id);

            Assert.Equal("Laptop", product.Name);
        }

        [Fact]
        public void Should_Update_Product()
        {
            var id = _service.Create(new CreateProductDto { Name = "Mouse", Price = 10 });

            _service.ChangePrice(id, 25);

            var product = _service.GetById(id);

            Assert.Equal(25, product.Price);
        }

        [Fact]
        public void Should_Delete_Product()
        {
            var id = _service.Create(new CreateProductDto { Name = "Keyboard", Price = 50 });

            _service.Delete(id);

            Assert.Throws<KeyNotFoundException>(() => _service.GetById(id));
        }
    }
}
