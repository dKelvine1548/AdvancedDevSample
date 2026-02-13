
using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Application.services;
using AdvancedDevSample.Infrastructure.Repositories;

namespace AdvancedDevSample.Test.Component
{
    public  class ProductServiceTest
    {
        private readonly ProductService productService;

        public ProductServiceTest()
        {
            var repo = new EfProductRepository();
            productService = new ProductService(repo);
        }

        [Fact]
        public void Should_Create_Product()
        {
            var id = productService.CreateProduct(new CreateProductDto
            {
                Name = "Laptop",
                Price = 1000
            });

            var product = productService.GetByIdProduct(id);

            Assert.Equal("Laptop", product.Name);
        }

        [Fact]
        public void Should_Update_Product()
        {
            var id = productService.CreateProduct(new CreateProductDto { Name = "Mouse", Price = 10 });

            productService.ChangePriceProduct(id, 25);

            var product = productService.GetByIdProduct(id);

            Assert.Equal(25, product.Price);
        }

        [Fact]
        public void Should_Delete_Product()
        {
            var id = productService.CreateProduct(new CreateProductDto { Name = "Keyboard", Price = 50 });

            productService.DeleteProduct(id);

            Assert.Throws<KeyNotFoundException>(() => productService.GetByIdProduct(id));
        }
    }
}
