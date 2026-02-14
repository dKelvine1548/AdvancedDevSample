using AdvancedDevSample.Application.DTOs.Customers;
using AdvancedDevSample.Application.Exceptions;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces;

namespace AdvancedDevSample.Application.services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repo;
        public CustomerService(ICustomerRepository repo) {
            _repo = repo;
        }

        public Guid Create(CreateCustomerDto dto)
        {
            var customer = new Customer (Guid.NewGuid(), dto.Name);
            _repo.AddCustomer(customer);
            return customer.Id; 
        }

        public Customer update(Guid id, string name)
        {
            var customer = _repo.GetByIdCustomer(id);
            if (customer == null)
                throw new ApplicationServiceException("Customer not found", System.Net.HttpStatusCode.NotFound);

            var updated = new Customer(id, name);
            _repo.UpdateCustomer(updated);
            return customer;
        }

        public IEnumerable<Customer> GetAll() => _repo.GetAllCustomer();

        public CustomerDto GetById(Guid id)
        {
            var customer = _repo.GetByIdCustomer(id);
            if (customer == null)
                throw new ApplicationServiceException("Customer not found", System.Net.HttpStatusCode.NotFound);

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name
               
            };
        }

        public void Delete(Guid id) => _repo.DeleteCustomer(id);

    }
}
