using AdvancedDevSample.Domain.Entities;

namespace AdvancedDevSample.Domain.Interfaces
{
    public interface ICustomerRepository {
        Customer GetByIdCustomer(Guid id);
        IEnumerable<Customer> GetAllCustomer();
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Guid id);

    }
}
