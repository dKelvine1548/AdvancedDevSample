using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces;

namespace AdvancedDevSample.Application.services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public Guid CreateProduct(CreateProductDto dtoProduct)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dtoProduct.Name,
            };

            product.ChangePrice(dtoProduct.Price); 
            _repo.AddProduct(product);
            return product.Id;
        }

        public void ChangePriceProduct(Guid id, decimal newPrice)
        {
            var product = _repo.GetByIdProduct(id);
            product.ChangePrice(newPrice);
            _repo.UpdateProduct(product);
        }

        public IEnumerable<Product> GetAllProduct() => _repo.GetAllProduct();

        public ProductDto GetByIdProduct(Guid id)
        {
            var product = _repo.GetByIdProduct(id);
            if (product == null)
                throw new Exception("Product not found");

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                IsActive = product.IsActive
            };
        }



        public void DeleteProduct(Guid id) => _repo.DeleteProduct(id);
    }
}
