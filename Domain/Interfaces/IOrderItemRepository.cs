using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetAllByOrderIdAsync(int orderId);
    }
}
