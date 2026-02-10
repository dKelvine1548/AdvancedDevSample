using AdvancedDevSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvancedDevSample.Infrastructure.DBContext
{
    public class AdvancedDevSampleDbContext : DbContext
    {
        public AdvancedDevSampleDbContext(DbContextOptions<AdvancedDevSampleDbContext> options) : base(options) { }


        public DbSet<Product> Products => Set<Product>();
        //public DbSet<Customer> Customers => Set<Customer>();
        //public DbSet<Order> Orders => Set<Order>();
        //public DbSet<OrderLine> OrderLines => Set<OrderLine>();
    }
}
