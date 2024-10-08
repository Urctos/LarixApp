﻿using Application.Dto.HingesDtos;
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
    public class HingesController : Controller
    {
        private readonly IGenericService<Hinges, HingesDto, CreateHingeDto, UpdateHingesDto> _hingesService;

        public HingesController(IGenericService<Hinges, HingesDto, CreateHingeDto, UpdateHingesDto> hingesService)
        {
            _hingesService = hingesService;
        }

        [SwaggerOperation(Summary = "Retrieves all hinges")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationFilter paginationFilter, [FromQuery] SortingFilter sortingFilter, [FromQuery] string filterBy = "")
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            var hinges = await _hingesService.GetAllAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
                                                          validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);

            var totalRecords = await _hingesService.GetAllCountAsync(filterBy);
            return Ok(PaginationHelper.CreatePagedResponse(hinges, validPaginationFilter, totalRecords));
        }

        [SwaggerOperation(Summary = "Create a new hinges")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateHingeDto newHinges)
        {
            var hinges = await _hingesService.AddAsync(newHinges);
            return Created($"api/hinges/{hinges.Id}", new Response<HingesDto>(hinges));
        }

        [SwaggerOperation(Summary = " Update a existing hinges")]
        [HttpPut]
        public  async Task <IActionResult> Update(UpdateHingesDto updateHinges)
        {
            await _hingesService.UpdateAsync(updateHinges);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delate a specific hinges")]
        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
            await _hingesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
