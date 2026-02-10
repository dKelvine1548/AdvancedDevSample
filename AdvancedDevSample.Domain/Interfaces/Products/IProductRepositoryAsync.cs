using AdvancedDevSample.Domain.Entities;

namespace AdvancedDevSample.Domain.Interfaces.Products
{
    public interface IProductRepositoryAsync
    {
        Task<Product> GetByIdAsync(Guid id);

        Task SaveAsync(Product product);
    }
}
