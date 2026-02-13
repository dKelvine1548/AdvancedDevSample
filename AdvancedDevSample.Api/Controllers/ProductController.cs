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
        public IActionResult Create(CreateProductDto dto)
        {
            var id = _productService.CreateProduct(dto);
            return Ok(id);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_productService.GetAllProduct());


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var product = _productService.GetByIdProduct(id);
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

        [HttpPatch("{id}/price")]
        public IActionResult ChangePrice(Guid id,  [FromBody] ChangePriceRequest request)
        {
            _productService.ChangePriceProduct(id, request.NewPrice);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }

    }
}
