namespace AdvancedDevSample.Application.DTOs.Orders
{
    public class OrderLineDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OrderLineTotal { get; set; }
    }
}
