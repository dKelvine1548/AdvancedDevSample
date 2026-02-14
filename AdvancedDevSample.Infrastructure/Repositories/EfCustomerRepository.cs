using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces;

namespace AdvancedDevSample.Infrastructure.Repositories
{
    public class EfCustomerRepository : ICustomerRepository
    {
        private static readonly Dictionary<Guid, Customer> _store = new();

        public void AddCustomer(Customer Customer) => _store[Customer.Id] = Customer;

        public void UpdateCustomer(Customer Customer) => _store[Customer.Id] = Customer;

        public Customer GetByIdCustomer(Guid id) => _store[id];

        public IEnumerable<Customer> GetAllCustomer() => _store.Values;

        public void DeleteCustomer(Guid id) => _store.Remove(id);

    }
}
