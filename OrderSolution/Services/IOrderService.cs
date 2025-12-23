using OrderSolution.Models;

namespace OrderSolution.Services
{
    public interface IOrderService
    {
        Task <IEnumerable<Order>> GetAll();
        Task <Order?> GetById(Guid id);
        Task <Order> Create(Order order);
        Task<bool> UpdateStatus(Guid id, string status);
    }
}
