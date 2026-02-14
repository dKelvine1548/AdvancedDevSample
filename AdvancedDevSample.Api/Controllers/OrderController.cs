
using AdvancedDevSample.Application.DTOs.Orders;
using AdvancedDevSample.Domain.Entities;
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

        return CreatedAtAction(
            nameof(GetById),          // 1) le nom de l'action cible
            new { id = orderCreated.Id },   // 2) routeValues -> pour construire l'URL (header Location)
            new { id = orderCreated.Id }    // 3) value       -> le corps (body) de la réponse HTTP 201
        );

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