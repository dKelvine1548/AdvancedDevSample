using AdvancedDevSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Domain.Interfaces.Products
{
    public interface IProductRepository {
        /*
        Product GetById(Guid id);
        void Save(Product product);
        void Update (Product product);
        void Delete (Guid id);
        */

        Task<Product?> GetByIdAsync(Guid id);
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);

    }

  
}
