using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Domain.Entities
{
    public class Customer
    {
        public Guid Id;
        public string Name = string.Empty;
        public string Phone = string.Empty;
        public List<Order> orders = new();
       public Customer() { }

        public Customer(Guid id, string name, string phone) {
            Id = id;
            Name = name;
            Phone = phone;
        }

        
    }
}
