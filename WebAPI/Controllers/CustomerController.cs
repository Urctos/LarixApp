using Application.Dto.CustomerDtos;
using Application.Dto.GlassTypesDtos;
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
    public class CustomerController : ControllerBase
    {
        private readonly IGenericService<Customer, CustomerDto, CreateCustomerDto, UpdateCustomerDto> _customerService;

        public CustomerController(IGenericService<Customer, CustomerDto, CreateCustomerDto, UpdateCustomerDto> customerService)
        {
            _customerService = customerService;
        }



        [SwaggerOperation(Summary = "Retrieves all customers")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);


            var customers = await _customerService.GetAllAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
                                                                validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);

            var totalRecords = await _customerService.GetAllCountAsync(filterBy);
            return Ok(PaginationHelper.CreatePagedResponse(customers, validPaginationFilter, totalRecords));
        }


        [SwaggerOperation(Summary = "Create a new customer")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCustomerDto newCustomer) 
        {
            var customer = await _customerService.AddAsync(newCustomer);
            return Created($"api/customers/{customer.Id}", new Response<CustomerDto>(customer));
        }

        [SwaggerOperation(Summary = " Update a existing customer")]
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomer)
        {
            await _customerService.UpdateAsync(updateCustomer);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delate a specific glassType")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
