using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Application.DTOs.Orders
{
    public class CreateOrderLineDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; } 
        public decimal UnitPrice { get; set; }
    }
}
