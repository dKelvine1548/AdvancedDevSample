namespace AdvancedDevSample.Application.DTOs.Orders
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderLineDto> Lines { get; set; } = new();
        public decimal OrderTotal { get; set; }
    }
}
