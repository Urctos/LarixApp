using Application.Dto.OrderDtos;
using Application.Dto.OrderItemDtos;
using Application.Interfaceas;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {

        private readonly IRepository<Order> _orderRepository;
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderService(
            IRepository<Order> orderRepository,
            IOrderItemService orderItemService,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderItemService = orderItemService;
            _mapper = mapper;
        }

        public async Task<OrderDto> AddOrderAsync(CreateOrderDto createOrderDto)
        {
            try
            {
                var orderEntity = _mapper.Map<Order>(createOrderDto);
                var addedOrder = await _orderRepository.AddAsync(orderEntity);
                return _mapper.Map<OrderDto>(addedOrder);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateOrderPricesAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }

            var orderItems = await _orderItemService.GetAllByOrderIdAsync(orderId);
            decimal netPrice = orderItems.Sum(item => item.Price);
            decimal vatRate = 0.23m; 
            decimal totalPrice = netPrice + (netPrice * vatRate);

            order.NetPrice = netPrice;
            order.VatRate = vatRate;
            order.TotalPrice = totalPrice;

            await _orderRepository.UpdateAsync(order);
        }


    }
}
