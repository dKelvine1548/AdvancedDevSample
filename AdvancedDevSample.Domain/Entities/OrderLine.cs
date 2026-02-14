namespace AdvancedDevSample.Domain.Entities
{
    public class OrderLine
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public OrderLine(Guid id, Guid productId, int quantity, decimal unitPrice)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public decimal GetTotalOrderLine() => Quantity * UnitPrice;
    }
}