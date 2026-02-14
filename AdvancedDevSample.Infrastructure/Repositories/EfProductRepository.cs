using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces;

namespace AdvancedDevSample.Infrastructure.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        private static readonly Dictionary<Guid, Product> _store = new();

        public void AddProduct(Product product) => _store[product.Id] = product;

        public void UpdateProduct(Product product) => _store[product.Id] = product;

        public Product GetByIdProduct(Guid id) => _store[id];

        public IEnumerable<Product> GetAllProduct() => _store.Values;

        public void DeleteProduct(Guid id) => _store.Remove(id);
    }
}
