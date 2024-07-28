using Application.Dto.HingesDtos;
using Application.Dto.ImpregantionTypeDtos;
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
    public class ImpregnationTypeController : Controller
    {
        private readonly IGenericService<ImpregnationType, ImpregnationTypeDto, CreateImpregnationTypeDto, UpdateImpregnationTypeDto> _impregnationTypeService;
        public ImpregnationTypeController(IGenericService<ImpregnationType, ImpregnationTypeDto, CreateImpregnationTypeDto, UpdateImpregnationTypeDto> impregnationTypeService)
        {
            _impregnationTypeService = impregnationTypeService;
        }


        [SwaggerOperation(Summary = "Retrieves all impregnation types")]
        [HttpGet]
        public async Task<IActionResult> GetAllImpregnationTypesAsync([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            var ipregnationTypes = await _impregnationTypeService.GetAllAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
                                                                              validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);

            var totalRecords = await _impregnationTypeService.GetAllCountAsync(filterBy);
            return Ok(PaginationHelper.CreatePagedResponse(ipregnationTypes, validPaginationFilter, totalRecords));
        }


        [SwaggerOperation(Summary = "Create a new impregnation type")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateImpregnationTypeDto newIpregantionType)
        {
            var impregnationType = await _impregnationTypeService.AddAsync(newIpregantionType);
            return Created($"api/impregnationTypes/{impregnationType.Id}", new Response<ImpregnationTypeDto>(impregnationType));

        }


        [SwaggerOperation(Summary = " Update a existing impregnation type")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateImpregnationTypeDto updateImpregnationTypes)
        {
             await _impregnationTypeService.UpdateAsync(updateImpregnationTypes);
            return NoContent();
        }


        [SwaggerOperation(Summary = "Delate a specific impregnation types")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             await _impregnationTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
