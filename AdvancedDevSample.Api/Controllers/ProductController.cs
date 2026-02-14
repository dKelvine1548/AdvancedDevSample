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
        private readonly ProductService productService;

        public ProductController(ProductService _productService) { 

            productService = _productService;  

        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            var productId = productService.Create(dto);

            return CreatedAtAction(
                nameof(GetById),          // 1) le nom de l'action cible
                new { id = productId },   // 2) routeValues -> pour construire l'URL (header Location)
                new { id = productId }    // 3) value       -> le corps (body) de la réponse HTTP 201
            );

        }

        [HttpGet]
        public IActionResult GetAllProduct() => Ok(productService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var product = productService.GetById(id);
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
            var product = productService.ChangePrice(id, request.NewPrice);

            return Ok(product);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            productService.Delete(id); 
            return Ok();
        }
    }
}
