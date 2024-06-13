using Application.Dto.DoorsDto;
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
    public class DoorController : ControllerBase
    {
        private readonly IGenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto> _doorService;
        public DoorController(IGenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto> doorService)
        { 
            _doorService = doorService;
        }

        [SwaggerOperation(Summary = " Retrieves sort doors")]
        [HttpGet("[action]")]
        public IActionResult GetSortAsync()
        {
            return Ok(SortingHelper.GetSortFields().Select(x => x.Key));
        }

        [SwaggerOperation(Summary = " Retrieves all doors")]
        [HttpGet]
        public async Task <IActionResult> GetAllAsync([FromQuery]PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);


            var doors = await _doorService.GetAllAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
                                                     validSortingFilter.SortField, validSortingFilter.Ascending,
                                                     filterBy);
            var totalRecords = await _doorService.GetAllCountAsync(filterBy);

            return Ok(PaginationHelper.CreatePagedResponse(doors, validPaginationFilter, totalRecords));
        }

        [SwaggerOperation(Summary = """ Retrieves a specific door by unique id""")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id) 
        {
            var door = await _doorService.GetByIdAsync(id);
            if (door == null) 
            {
                return NotFound();
            }
            return Ok( new Response<DoorDto>(door));
        }

        [SwaggerOperation(Summary = " Create a new door")]
        [HttpPost]
        public async  Task<IActionResult> CreateAsync(CreateDoorDto newDoor)
        {
            var door = await _doorService.AddAsync(newDoor);
            return Created($"api/doors/{door.Id}", new Response<DoorDto>(door));
        }

        [SwaggerOperation(Summary = " Update a existing door")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync (UpdateDoorDto updateDoor)
        {
            await _doorService.UpdateAsync(updateDoor);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delate a specific door")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) 
        {
            await _doorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
