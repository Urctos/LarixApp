using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly LarixContext _context;
        public OrderItemRepository(LarixContext context) : base(context) 
        {
           _context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetAllByOrderIdAsync(int orderId)
        {
            return await _context.OrderItems
                                 .Where(oi => oi.OrderId == orderId)
                                 .ToListAsync();
        }
    }
}
