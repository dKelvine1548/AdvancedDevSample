using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Domain.Entities
{
    public class OrderLine
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = new();
   

        public OrderLine() { }

        public OrderLine(Guid id, int quantity, decimal unitPrice) { 
            Id = id;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public decimal GetLineTotal()
        {
           return  Quantity * UnitPrice;
        }

    }
}
