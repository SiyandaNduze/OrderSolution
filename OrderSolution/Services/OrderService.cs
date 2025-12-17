using OrderSolution.Models;

namespace OrderSolution.Services
{
    public class OrderService : IOrderService
    {
        private static readonly List<Order> _orders = new();


        public IEnumerable<Order> GetAll() => _orders;


        public Order? GetById(Guid id) => _orders.FirstOrDefault(o => o.Id == id);


        public Order Create(Order order)
        {
            order.Id = Guid.NewGuid();
            _orders.Add(order);
            return order;
        }


        public bool UpdateStatus(Guid id, string status)
        {
            var order = GetById(id);
            if (order == null) return false;


            order.Status = status;
            return true;
        }
    }
}
