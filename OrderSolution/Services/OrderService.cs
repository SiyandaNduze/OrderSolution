using Microsoft.EntityFrameworkCore;
using OrderSolution.Data;
using OrderSolution.Models;
using OrderSolution.Services;

namespace OrderSolution.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _context;

        public OrderService(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAll()
            => await _context.Orders.AsNoTracking().ToListAsync();

        public async Task<Order?> GetById(Guid id)
            => await _context.Orders.FindAsync(id);

        public async Task<Order> Create(Order order)
        {
            order.Id = Guid.NewGuid();
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> UpdateStatus(Guid id, string status)
        {
            var order = await GetById(id);
            if (order == null) return false;

            order.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
