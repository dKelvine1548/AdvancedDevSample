using AdvancedDevSample.Domain.Entities;

namespace AdvancedDevSample.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Order GetById(Guid id);
        void Add(Order order);
        IEnumerable<Order> GetAll();
    }
}