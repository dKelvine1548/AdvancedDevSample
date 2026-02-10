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
        
        [HttpPut("{id}/price")]
        public async Task<IActionResult> ChangePrice(Guid id, ChangePriceRequest request)
        {
            try
            {
                await _productService.ChangeProductPrice(id, request.NewPrice);    
                return NoContent(); //204
            }

            catch (ApplicationServiceException ex)
            {
                return NotFound(ex.Message);
            }

            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var product = await _productService.GetProductAsync(id);
                return product == null ? NotFound() : Ok(product);
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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _productService.GetAllAsync());
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            try
            {
                var id = await _productService.CreateAsync(dto);
                return CreatedAtAction(nameof(Get), new { id }, null);
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

        [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(Guid id)
            {
                try
                {
                    await _productService.DeleteAsync(id);
                    return NoContent();
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

        }
}
