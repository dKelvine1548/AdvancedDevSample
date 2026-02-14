
using AdvancedDevSample.Application.DTOs.Orders;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedDevSample.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly OrderService _service;

    public OrderController(OrderService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(CreateOrderDto dto)
    {
        var orderCreated = _service.Create(dto);

        return Ok(orderCreated.Id);
    }

    [HttpGet("{id}")]
    public ActionResult GetById(Guid id)
    {
        var order = _service.GetById(id);
        if(order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        var orders = _service.GetAll();
        return Ok(orders);
    }
    
}