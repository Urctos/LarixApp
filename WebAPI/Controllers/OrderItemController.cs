using Application.Dto.OrderDtos;
using Application.Dto.OrderItemDtos;
using Application.Interfaceas;
using Asp.Versioning;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Filters;
using WebAPI.Helpers;
using WebAPI.Wrappers;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]

    public class OrderItemController : ControllerBase
    {
        private readonly IGenericService<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto> _orderItemService;
        private readonly IGenericService<Order, OrderDto, CreateOrderDto, UpdateOrderDto> _orderService;
        private readonly IOrderItemService _addingOrderItemService;

        public OrderItemController(IGenericService<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto> orderItemService,
                                   IGenericService<Order, OrderDto, CreateOrderDto, UpdateOrderDto> orderService,IOrderItemService addingOrderItemService)
        {
            _orderItemService = orderItemService;
            _orderService = orderService;
            _addingOrderItemService = addingOrderItemService;           
        }

        [SwaggerOperation(Summary = "Retrieves all order items")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            var orderItems = await _orderItemService.GetAllAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize, validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
            var totalRecords = await _orderItemService.GetAllCountAsync(filterBy);
            return Ok(PaginationHelper.CreatePagedResponse(orderItems, validPaginationFilter, totalRecords));
        }

        [SwaggerOperation(Summary = "Create a new order item")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrderItemDto newOrderItem)
        {
            var existingOrder = await _orderService.GetByIdAsync(newOrderItem.OrderId);
            if (existingOrder == null)
            {
                // Jeśli zamówienie nie istnieje, utwórz nowe zamówienie
                var createOrderDto = new CreateOrderDto
                {
                    OrderDate = DateTime.UtcNow,  // Przykładowa data zamówienia
                                                  // Ustaw inne właściwości zamówienia, takie jak customerId, netPrice, vatRate, totalPrice, etc.
                };
                existingOrder = await _orderService.AddAsync(createOrderDto);
            }

            newOrderItem.OrderId = existingOrder.Id;


            var orderItem = await _addingOrderItemService.AddOrderItemAsync(newOrderItem);
            return Created($"api/orderitem/{orderItem.Id}", new Response<OrderItemDto>(orderItem));
        }

        [SwaggerOperation(Summary = "Update an existing order item")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateOrderItemDto updateOrderItem)
        {
            await _orderItemService.UpdateAsync(updateOrderItem);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific order item")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _orderItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
