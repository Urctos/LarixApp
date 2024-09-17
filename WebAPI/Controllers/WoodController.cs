using Application.Dto.WoodDtos;
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
    public class WoodController : Controller
    {
        private readonly IGenericService<Wood, WoodDto, CreateWoodDto, UpdateWoodDto> _woodService;
        public WoodController(IGenericService<Wood, WoodDto, CreateWoodDto, UpdateWoodDto> woodService)
        {
            _woodService = woodService;
        }

        [SwaggerOperation(Summary = "Retrieves all woods")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            var woods = await _woodService.GetAllAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
                                                       validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);

            var totalRecords = await  _woodService.GetAllCountAsync(filterBy);
            return Ok(PaginationHelper.CreatePagedResponse(woods, validPaginationFilter, totalRecords));
        }

        [SwaggerOperation(Summary = "Create a new wood type")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateWoodDto newWood)
        {
            var wood = await _woodService.AddAsync(newWood);
            return Created($"api/woods/{wood.Id}", new Response<WoodDto>(wood));
        }

        [SwaggerOperation(Summary = " Update a existing wood types")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateWoodDto updateWoods) 
        {
            await _woodService.UpdateAsync(updateWoods);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delate a specific wood type")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _woodService.DeleteAsync(id);
            return NoContent();
        }
    }
}
