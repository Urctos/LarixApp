using Application.Dto.OrderDtos;
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
    public class OrderController : ControllerBase
    {
        private readonly IGenericService<Order, OrderDto, CreateOrderDto, UpdateOrderDto> _orderService;
        //private readonly IGenericService<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto> _orderItemService;
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderService _addOrderService;


        public OrderController(IGenericService<Order, OrderDto, CreateOrderDto, UpdateOrderDto> orderService,
                              IOrderItemService orderItemService,
                              IOrderService addOrderService)                      
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _addOrderService = addOrderService;
        }


        [SwaggerOperation(Summary = "Retrieves all orders")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            var orders = await _orderService.GetAllAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize, validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
            var totalRecords = await _orderService.GetAllCountAsync(filterBy);
            return Ok(PaginationHelper.CreatePagedResponse(orders, validPaginationFilter, totalRecords));
        }


        [SwaggerOperation(Summary = "Create a new order")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrderDto newOrder)
        {
            var order = await _orderService.AddAsync(newOrder);
            return Created($"api/order/{order.Id}", new Response<OrderDto>(order));
        }


        [SwaggerOperation(Summary = "Update an existing order")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateOrderDto updateOrder)
        {
            await _orderService.UpdateAsync(updateOrder);
            return NoContent();
        }


        [SwaggerOperation(Summary = "Delete a specific order")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _orderService.DeleteAsync(id);
            return NoContent();
        }


        [SwaggerOperation(Summary = "Update order prices")]
        [HttpPut("update-prices/{orderId}")]
        public async Task<IActionResult> UpdatePricesAsync(int orderId)
        {
            try
            {
                await _addOrderService.UpdateOrderPricesAsync(orderId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<string>(ex.Message));
            }
        }

    }
}
