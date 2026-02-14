using AdvancedDevSample.Application.DTOs.Customers;
using AdvancedDevSample.Application.Exceptions;
using AdvancedDevSample.Application.services;
using AdvancedDevSample.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedDevSample.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService CustomerService;

        public CustomerController(CustomerService _CustomerService) { 

            CustomerService = _CustomerService;  

        }

        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerDto dto)
        {
            var customerId = CustomerService.Create(dto);

            return Ok(customerId);
        }

        [HttpGet]
        public IActionResult GetAllCustomer() => Ok(CustomerService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var Customer = CustomerService.GetById(id);
                return Ok(Customer);
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

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(Guid id, CreateCustomerDto dto)
        {
            var Customer = CustomerService.update(id, dto.Name);

            return Ok(Customer);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            CustomerService.Delete(id); 
            return Ok();
        }
    }
}
