using AdvancedDevSample.Application.DTOs.Products;
using AdvancedDevSample.Application.Exceptions;
using AdvancedDevSample.Application.services;
using AdvancedDevSample.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedDevSample.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService) { 
            _productService = productService; 
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            var product = _productService.Create(dto); 
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAllProduct() => Ok(_productService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var product = _productService.GetById(id);
                return Ok(product);
            }

            catch (ApplicationServiceException ex)
            {
                return NotFound(ex.Message);
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/price")]
        public IActionResult ChangePriceProduct(Guid id, [FromBody] ChangePriceRequest request)
        {
            var product = _productService.ChangePrice(id, request.NewPrice);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProuct(Guid id)
        {
            _productService.Delete(id); 
            return Ok();
        }
    }
}
