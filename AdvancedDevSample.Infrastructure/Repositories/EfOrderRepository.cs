using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces;

namespace AdvancedDevSample.Infrastructure.Repositories
{
    public class EfOrderRepository : IOrderRepository
    {
        private static readonly Dictionary<Guid, Order> _orders = new();

        public void Add(Order order) => _orders[order.Id] = order;

        public Order GetById(Guid id) => _orders[id];

        public IEnumerable<Order> GetAll() => _orders.Values;
    }
}