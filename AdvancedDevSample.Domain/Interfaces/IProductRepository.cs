using AdvancedDevSample.Domain.Entities;

namespace AdvancedDevSample.Domain.Interfaces
{
    public interface IProductRepository {
        Product GetByIdProduct(Guid id);
        IEnumerable<Product> GetAllProduct();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid id);

    }
}
