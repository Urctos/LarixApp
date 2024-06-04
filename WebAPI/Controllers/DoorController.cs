using Application.Dto.DoorsDto;
using Application.Interfaceas;
using Asp.Versioning;
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
        private readonly IDoorService _doorService;
        public DoorController(IDoorService windowService)
        { 
            _doorService = windowService;
        }

        [SwaggerOperation(Summary = " Retrieves all doors")]
        [HttpGet]
        public async Task <IActionResult> GetAsync([FromQuery]PaginationFilter paginationFilter)
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);


            var doors = await _doorService.GetAllDoorsAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize);
            var totalRecords = await _doorService.GetAllDoorsCountAsync();

            return Ok(PaginationHelper.CreatePagedResponse(doors, validPaginationFilter, totalRecords));
        }

        [SwaggerOperation(Summary = """ Retrieves a specific door by unique id""")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActionAsync(int id) 
        {
            var door = await _doorService.GetDoorByIdAsync(id);
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
            var door = await _doorService.AddNewDoorAsync(newDoor);
            return Created($"api/doors/{door.Id}", new Response<DoorDto>(door));
        }

        [SwaggerOperation(Summary = " Update a existing door")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync (UpdateDoorDto updateDoor)
        {
            await _doorService.UpdateDoorAsync(updateDoor);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delate a specific door")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) 
        {
            await _doorService.DeleteDoorAsync(id);
            return NoContent();
        }
    }
}
