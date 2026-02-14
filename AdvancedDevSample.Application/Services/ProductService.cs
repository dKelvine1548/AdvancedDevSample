using AdvancedDevSample.Application.DTOs.Orders;
using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Application.Exceptions;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces;

namespace AdvancedDevSample.Application.services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) {
            _repo = repo;
        }

        public Guid Create(CreateProductDto dto)
        {
            var product = new Product {Id = Guid.NewGuid(), Name = dto.Name};
            product.ChangePrice(dto.Price);
            _repo.AddProduct(product);
            return product.Id; 
        }

        public Product ChangePrice(Guid id, decimal newPrice)
        {
            var product = _repo.GetByIdProduct(id);
            product.ChangePrice(newPrice);
            _repo.UpdateProduct(product);
            return product;
        }

        public IEnumerable<Product> GetAll() => _repo.GetAllProduct();

        public ProductDto GetById(Guid id)
        {
            var product = _repo.GetByIdProduct(id);
            if (product == null)
                throw new ApplicationServiceException("Product not found", System.Net.HttpStatusCode.NotFound);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                IsActive = product.IsActive
            };
        }

        public void Delete(Guid id) => _repo.DeleteProduct(id);

    }
}
