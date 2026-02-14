using AdvancedDevSample.Domain.Exceptions;

namespace AdvancedDevSample.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }
        public Product()
        {
            IsActive = true;

        }
    
        public Product(Guid id, decimal price, bool isActive, string name )
        {
            Id = id;
            Price = price;
            IsActive = isActive;
            Name = name;
        
        }
        public void ChangePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new DomainException("le prix doit etre positif");
            if (!IsActive)
                throw new DomainException("produit inactif");
            Price = newPrice;
        }
        public void ApplyDiscount(decimal discount) {
            ChangePrice(Price - discount);
        }
    }
}