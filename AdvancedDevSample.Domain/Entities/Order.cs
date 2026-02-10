using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Order_Date { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer_ { get; set; } = new Customer();
        public List<OrderLine> Lines { get; set; } = new();

        public Order() { }

        public Order(Guid id, DateTime order_Date)
        {
            Id = id;
            Order_Date = order_Date;
        }

        public void AddProduct(Product product, int quantity)
        {
            var line = Lines.FirstOrDefault( l=> l.ProductId == product.Id);
            if(line != null) {
                line.Product = product;
                if (line != null) line.Quantity += quantity;
                else Lines.Add(new OrderLine
                {
                    Id = Guid.NewGuid(),
                    Product = product,
                    ProductId = product.Id,
                    Quantity = quantity,
                    UnitPrice = product.Price
                });
            }
        }

        public decimal GetTotal()
        {
            return Lines.Sum(l => l.GetLineTotal());
        } 
    }
}
