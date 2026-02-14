using AdvancedDevSample.Application.DTOs.Orders;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces;

public class OrderService
{
    private readonly IOrderRepository _orders;

    private readonly IProductRepository _products;

    public OrderService(IOrderRepository orders, IProductRepository products)
    {
        _orders = orders;
        _products = products;
    }

    public OrderDto Create(CreateOrderDto dto)
    {
        var order = new Order(Guid.NewGuid(), dto.CustomerId, DateTime.Now);

        foreach (var line in dto.OrderLines)
        {
            var orderLine = new OrderLine(
                Guid.NewGuid(),
                line.ProductId,
                line.Quantity,
                line.UnitPrice);

            order.AddLine(orderLine);
        }

        _orders.Add(order);

        return MapToDto(order);
    }

    public OrderDto? GetById(Guid id)
    {
        var order = _orders.GetById(id);
        return order == null ? null : MapToDto(order);
    }

    public IReadOnlyCollection<OrderDto> GetAll()
    {
        return _orders
            .GetAll()
            .Select(MapToDto)
            .ToList();
    }

    private OrderDto MapToDto(Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            OrderTotal = order.GetTotalOrder(),
            Lines = order.OrderLines.Select(l => new OrderLineDto
            {
                ProductId = l.ProductId,
                Quantity = l.Quantity,
                UnitPrice = l.UnitPrice,
                OrderLineTotal = l.GetTotalOrderLine()
            }).ToList()
        };
    }


}