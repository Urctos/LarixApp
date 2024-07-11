using Application.Dto.OrderDtos;
using Application.Dto.OrderItemDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaceas
{
    public interface IOrderService 
    {
        Task<OrderDto> AddOrderAsync(CreateOrderDto createOrderDto);
        Task UpdateOrderPricesAsync(int orderId);
    }
}