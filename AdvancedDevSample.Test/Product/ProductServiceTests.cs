using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Application.services;

public class ProductServiceTests
{
    private readonly ProductService _service;
    private readonly FakeProductRepository _repo;

    public ProductServiceTests()
    {
        _repo = new FakeProductRepository();
        _service = new ProductService(_repo);
    }

    [Fact]
    public void Create_Should_Add_Product()
    {
        var id = _service.Create(new CreateProductDto {Name = "Keyboard", Price = 50});

        var product = _repo.GetByIdProduct(id);

        Assert.NotNull(product);
        Assert.Equal("Keyboard", product.Name);
        Assert.Equal(50, product.Price);
    }

    [Fact]
    public void ChangePrice_Should_Update_Price()
    {
        var id = _service.Create((new CreateProductDto { Name = "Mouse", Price = 20 }));

        _service.ChangePrice(id, 30);

        var product = _repo.GetByIdProduct(id);

        Assert.Equal(30, product.Price);
    }
}