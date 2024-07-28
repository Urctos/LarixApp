using Application.Dto.OrderItemDtos;
using Domain.Entities;


namespace Application.Interfaceas
{
    public interface IOrderItemService : IGenericService<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto>
    {
        Task<OrderItemDto> AddOrderItemAsync(CreateOrderItemDto newDto);
        Task<IEnumerable<OrderItemDto>> GetAllByOrderIdAsync(int orderId);
    }
}
