using Application.Dto.OrderDtos;

namespace Application.Interfaceas
{
    public interface IOrderService 
    {
        Task<OrderDto> AddOrderAsync(CreateOrderDto createOrderDto);
        Task UpdateOrderPricesAsync(int orderId);
    }
}