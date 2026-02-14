namespace AdvancedDevSample.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        private readonly List<OrderLine> _lines = new();
        public IReadOnlyCollection<OrderLine> OrderLines => _lines;

        public Order(Guid id, Guid customerId, DateTime orderDate)
        {
            Id = id;
            CustomerId = customerId;
            OrderDate = orderDate;
        }

        public void AddLine(OrderLine line)
        {
            _lines.Add(line);
        }

        public decimal GetTotalOrder()
        {
            return _lines.Sum(l => l.GetTotalOrderLine());
        }
    }
}