using OrderSolution.Models;

namespace OrderSolution.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order? GetById(Guid id);
        Order Create(Order order);
        bool UpdateStatus(Guid id, string status);
    }
}
