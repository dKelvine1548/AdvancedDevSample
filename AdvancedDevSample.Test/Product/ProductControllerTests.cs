using AdvancedDevSample.Api.Controllers;
using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Application.services;
using Microsoft.AspNetCore.Mvc;

public class ProductControllerTests
{
    [Fact]
    public void Post_Should_Return_Created()
    {
        var repo = new FakeProductRepository();

        var service = new ProductService(repo);

        var controller = new ProductController(service);

        var dto = new CreateProductDto { Name = "Laptop", Price = 900};

        var result = controller.CreateProduct(dto);

        Assert.IsType<CreatedAtActionResult>(result);
    }
}