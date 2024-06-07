using Application.Dto.HingesDto;
using Application.Dto.ImpregantionTypeDto;
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
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationFilter paginationFilter)
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var ipregnationTypes = await _impregnationTypeService.GetAllAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize);
            var totalRecords = await _impregnationTypeService.GetAllCountAsync();
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
        public IActionResult Update(UpdateImpregnationTypeDto updateImpregnationTypes)
        {
            _impregnationTypeService.UpdateAsync(updateImpregnationTypes);
            {
                return NoContent();
            }
        }

        [SwaggerOperation(Summary = "Delate a specific impregnation types")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _impregnationTypeService.DeleteAsync(id);
            {
                return NoContent();
            }

        }
    }
}
