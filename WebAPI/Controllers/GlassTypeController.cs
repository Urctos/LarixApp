using Application.Dto.GlassTypesDto;
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

    public class GlassTypeController : ControllerBase
    {
        private readonly IGenericService<GlassType, GlassTypeDto, CreateGlassTypeDto, UpdateGlassTypeDto> _glassTypeService;

        public GlassTypeController(IGenericService<GlassType, GlassTypeDto, CreateGlassTypeDto, UpdateGlassTypeDto> glassTypeService)
        {
            _glassTypeService = glassTypeService;
        }


        [SwaggerOperation(Summary = "Retrieves all glassType")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);


            var glassTypes = await _glassTypeService.GetAllAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
                                                                validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);

            var totalRecords = await _glassTypeService.GetAllCountAsync(filterBy);
            return Ok(PaginationHelper.CreatePagedResponse(glassTypes, validPaginationFilter, totalRecords));
        }


        [SwaggerOperation(Summary = "Create a new glassType")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateGlassTypeDto newGlassType)
        {
            var glassType = await _glassTypeService.AddAsync(newGlassType);
            return Created($"api/glassTypes/{glassType.GlassTypeId}", new Response<GlassTypeDto>(glassType));
        }

        [SwaggerOperation(Summary = " Update a existing glassType")]
        [HttpPut]
        public IActionResult UpdateGlassType(UpdateGlassTypeDto updateGlassType)
        {
            _glassTypeService.UpdateAsync(updateGlassType);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delate a specific glassType")]
        [HttpDelete("{id}")]
        public IActionResult DeleteGlassType(int id)
        {
            _glassTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
