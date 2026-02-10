using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Application.Exceptions;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;

namespace AdvancedDevSample.Application.services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) {
            _repo = repo;
        }

        /*public void ChangeProductPrice (Guid productId, decimal newPrice) {
            var product = GetProduct(productId);
            product.ChangePrice(newPrice);
            _repo.AddAsync(product);

        }*/

        /*private Product GetProduct(Guid id)
        {
            return _repo.GetByIdAsync(id)
           ?? throw new ApplicationServiceException("Produit introuvable", System.Net.HttpStatusCode.NotFound);
        }*/

        public async Task<ProductDto?> GetProductAsync(Guid id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return null;

            return MapToDto(product);
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return products.ConvertAll(MapToDto);
        }

        public async Task<Guid> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name
            };

            product.ChangePrice(dto.Price);
            await _repo.AddAsync(product);

            return product.Id;
        }

        public async Task ChangeProductPrice(Guid productId, decimal newPrice)
        {
            var product = await _repo.GetByIdAsync(productId)
                ?? throw new InvalidOperationException("Product not found");

            product.ChangePrice(newPrice);
            await _repo.UpdateAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
        }

        private static ProductDto MapToDto(Product p)
        {
            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                IsActive = p.IsActive
            };
        }

    }
}
