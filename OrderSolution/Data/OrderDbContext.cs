using Microsoft.EntityFrameworkCore;
using OrderSolution.Models;

namespace OrderSolution.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
    }
}
