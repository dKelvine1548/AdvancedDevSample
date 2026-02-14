

namespace AdvancedDevSample.Application.DTOs.Orders
{
    public class CreateOrderDto
    {
        public Guid CustomerId { get; set; }
        public List<OrderLineDto> OrderLines { get; set; } = new();

        
    }
}
