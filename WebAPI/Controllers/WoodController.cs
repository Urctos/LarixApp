﻿using Application.Dto.ImpregantionTypeDto;
using Application.Dto.WoodDto;
using Application.Interfaceas;
using Application.Services;
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
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationFilter paginationFilter)
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var woods = await _woodService.GetAllAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize);
            var totalRecords = await  _woodService.GetAllCountAsync();
            return Ok(PaginationHelper.CreatePagedResponse(woods, validPaginationFilter, totalRecords));
        }


        [SwaggerOperation(Summary = "Create a new wood type")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateWoodDto newWood)
        {
            var wood = await _woodService.AddAsync(newWood);
            return Created($"api/woods/{wood.WoodId}", new Response<WoodDto>(wood));

        }

        [SwaggerOperation(Summary = " Update a existing wood types")]
        [HttpPut]
        public IActionResult Update(UpdateWoodDto updateWoods)
        {
            _woodService.UpdateAsync(updateWoods);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delate a specific wood type")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           _woodService.DeleteAsync(id);
            return NoContent();
        }
    }
}
