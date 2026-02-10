using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using AdvancedDevSample.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace AdvancedDevSample.Infrastructure.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        /**
        public Product GetById(Guid id)
        {
            ProductEntity product = new () { Id = id , Price = 10, IsActive = true };
            var domainProduct = new Product(id: product.Id,product.Name, product.Price, isActive: product.IsActive);
            return domainProduct;
        }

        public void Save(Product product)
        {
            //accès base de données

        }

        public void update(Product product)
        {
            throw new NotImplementedException();
        }

        public void delete(Guid id)
        {
            throw new NotImplementedException();
        } **/

        private readonly AdvancedDevSampleDbContext _context;
        public EfProductRepository(AdvancedDevSampleDbContext context) {
            _context = context;
        } 

        public async Task<Product?> GetByIdAsync(Guid id)
            => await _context.Products.FindAsync(id);

        public async Task<List<Product>> GetAllAsync()
            => await _context.Products.ToListAsync();

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
