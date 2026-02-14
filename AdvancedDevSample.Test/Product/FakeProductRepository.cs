using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces;

public class FakeProductRepository : IProductRepository
{
    private readonly Dictionary<Guid, Product> _data = new();

    public Product GetByIdProduct(Guid id) => _data[id];

    public IEnumerable<Product> GetAllProduct() => _data.Values;

    public void AddProduct(Product product) => _data[product.Id] = product;

    public void UpdateProduct(Product product) => _data[product.Id] = product;

    public void DeleteProduct(Guid id) => _data.Remove(id);

    
}
