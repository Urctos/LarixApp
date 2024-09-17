using Application.Dto.OrderItemDtos;
using Application.Interfaceas;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class OrderItemService : GenericService<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto>, IOrderItemService
    {
        private readonly IRepository<Door> _doorRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _orderRepository;
        private readonly ILogger _logger;

        public OrderItemService(IOrderItemRepository orderItemrepository, IRepository<Door> doorRepository, IMapper mapper,IRepository<Order> orderRepository, ILogger<OrderItemService> logger)
            : base(orderItemrepository, mapper, logger)
        {
            _doorRepository = doorRepository;
            _orderItemRepository = orderItemrepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public  async Task<OrderItemDto> AddOrderItemAsync(CreateOrderItemDto newDto)
        {
            var door = await _doorRepository.GetByIdAsync(newDto.DoorId);
            if (door == null)
            {
                throw new Exception("Drzwi nie znalezione");
            }

            var order = await _orderRepository.GetByIdAsync(newDto.OrderId);
            if (order == null)
            {
                throw new Exception("Nie znaleziono zamówienia");
            }

            var orderItem = _mapper.Map<OrderItem>(newDto);

            orderItem.Price = door.Price * newDto.Quantity;

            //newDto.Price = door.Price * newDto.Quantity;
            //var entity = _mapper.Map<OrderItem>(newDto);
            //var result = await _repository.AddAsync(entity);

            var result = await _orderItemRepository.AddAsync(orderItem);
            return _mapper.Map<OrderItemDto>(result);
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllByOrderIdAsync(int orderId)
        {
            var orderItems = await _orderItemRepository.GetAllByOrderIdAsync(orderId); // Use specific repository method
            return _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
        }
    }
}
