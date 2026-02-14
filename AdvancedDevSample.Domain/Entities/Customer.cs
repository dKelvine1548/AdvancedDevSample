namespace AdvancedDevSample.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Customer(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
