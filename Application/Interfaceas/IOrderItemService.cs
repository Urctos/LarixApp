using Application.Dto.OrderItemDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaceas
{
    public interface IOrderItemService : IGenericService<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto>
    {
        Task<OrderItemDto> AddOrderItemAsync(CreateOrderItemDto newDto);
        Task<IEnumerable<OrderItemDto>> GetAllByOrderIdAsync(int orderId);
    }
}
