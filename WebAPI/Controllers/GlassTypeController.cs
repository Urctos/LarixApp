using Application.Dto.GlassTypesDto;
using Application.Dto.WindowsDto;
using Application.Interfaceas;
using Application.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]

    public class GlassTypeController : ControllerBase
    {
        private readonly IGlassTypeService _glassTypeService;

        public GlassTypeController(IGlassTypeService glassTypeService)
        {
            _glassTypeService = glassTypeService;
        }


        [SwaggerOperation(Summary = "Retrieves all glassType")]
        [HttpGet]
        public IActionResult GetGlassType()
        {
            var glassType = _glassTypeService.GetAllGlassTypes();
            return Ok(glassType);
        }

        
        [SwaggerOperation(Summary ="Create a new glassType")]
        [HttpPost]
        public IActionResult CreateNewGlassType(CreateGlassTypeDto newGlassType) 
        {
            var glassType = _glassTypeService.AddNewGlassType(newGlassType);
            return Created($"api/glassTypes/{glassType.GlassTypeId}", glassType);
        }

        [SwaggerOperation(Summary = " Update a existing glassType")]
        [HttpPut]
        public IActionResult UpdateGlassType(UpdateGlassTypeDto updateGlassType)
        {
            _glassTypeService.UpdateGlassType(updateGlassType);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delate a specific glassType")]
        [HttpDelete("{id}")]
        public IActionResult DeleteGlassType(int id)
        {
            _glassTypeService.DeleteWGlassType(id);
            return NoContent();
        }


    }
}
