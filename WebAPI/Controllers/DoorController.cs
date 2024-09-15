using Application.Dto.DoorsDtos;
using Application.Interfaceas;
using Asp.Versioning;
using AutoMapper;
using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using WebAPI.Attributes;
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
        private readonly IPriceCalculator _priceCalculator;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache; 

        public DoorController(IGenericService<Door, DoorDto, CreateDoorDto, UpdateDoorDto> doorService, IPriceCalculator priceCalculator
                              , IMapper mapper, IMemoryCache memoryCache)
        {
            _doorService = doorService;
            _priceCalculator = priceCalculator;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }


        [SwaggerOperation(Summary = " Retrieves sort doors")]
        [HttpGet("[action]")]
        public IActionResult GetSortAsync()
        {
            return Ok(SortingHelper.GetSortFields().Select(x => x.Key));
        }


        [SwaggerOperation(Summary = " Retrieves all doors")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
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
            return Ok(new Response<DoorDto>(door));
        }


        [ValidateFilter]
        [SwaggerOperation(Summary = " Create a new door")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateDoorDto newDoor)
        {
            var door = await _doorService.AddAsync(newDoor);
            return Created($"api/doors/{door.Id}", new Response<DoorDto>(door));
        }

        [SwaggerOperation(Summary = " Update a existing door")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateDoorDto updateDoor)
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


        [SwaggerOperation(Summary = "Calculate and update price of a specific door by id")]
        [HttpPut("{id}/CalculatePrice")]
        public async Task<IActionResult> CalculateDoorPriceAsync(int id)
        {
            var doorDto = await _doorService.GetByIdAsync(id);
            if (doorDto == null)
            {
                return NotFound();
            }

            var door = _mapper.Map<Door>(doorDto); // Mapowanie DoorDto na Door
            var price = await _priceCalculator.CalculatePriceAsync(door); // Obliczanie ceny drzwi

            Debug.WriteLine($"Calculated price for door {door.Id}: {price}");

            doorDto.Price = price;
            var updateDoorDto = _mapper.Map<UpdateDoorDto>(doorDto); // Mapowanie DoorDto na UpdateDoorDto

            await _doorService.UpdateAsync(updateDoorDto);

            return Ok(new Response<decimal>(price));
        }
    }
}
