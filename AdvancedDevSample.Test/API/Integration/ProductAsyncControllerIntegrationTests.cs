using AdvancedDevSample.Application.DTOs;
using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http.Json;

namespace AdvancedDevSample.Test.API.Integration
{
    public class ProductAsyncControllerIntegrationTests : IClassFixture<CustomerApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly InMemoryProductRepositoryAsync _repo;

        public ProductAsyncControllerIntegrationTests(CustomerApplicationFactory factory)
        {
            _client = new HttpClient();
            _repo = (InMemoryProductRepositoryAsync) factory.Services.GetRequiredService<IProductRepositoryAsync>();
        }

        
        /*[Fact]
        public async Task ChangePrice_Should_Return_NoContent_And_Save_Product() {

            //Arrange
            var product = new Product();
            _repo.Seed(product);

            var request = new ChangePriceRequest { NewPrice = 20 };

            //Act
            var response = await _client.PutAsJsonAsync(
                $"/api/products/{product.Id}/price",
                request
            );

            //Assert - HTTP
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            //Assert - Persistance réelle
            var updated = await _repo.GetByIdAsync(product.Id);
            Assert.Equal(20, updated!.Price);
        } */
        
    }
}
