using Application.Dto.WindowsDto;
using Application.Interfaceas;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    public class WindowController : ControllerBase
    {
        private readonly IWindowService _windowService;
        public WindowController(IWindowService windowService)
        { 
            _windowService = windowService;
        }

        [SwaggerOperation(Summary = " Retrieves all windows")]
        [HttpGet]
        public IActionResult Get()
        {
            var window = _windowService.GetAllWindows();
            return Ok(window);
        }

        [SwaggerOperation(Summary = """ Retrieves a specific window by unique id""")]
        [HttpGet("{id}")]
        public IActionResult GetAction(int id) 
        {
            var window = _windowService.GetWindowById(id);
            if (window == null) 
            {
                return NotFound();
            }
            return Ok(window);
        }

        [SwaggerOperation(Summary = " Create a new window")]
        [HttpPost]
        public IActionResult Create(CreateWindowDto newWindow)
        {
            var window = _windowService.AddNewWindow(newWindow);
            return Created($"api/windows/{window.Id}", window);
        }

        [SwaggerOperation(Summary = " Update a existing window")]
        [HttpPut]
        public IActionResult Update (UpdateWindowDto updateWindow)
        {
            _windowService.UpdateWindow(updateWindow);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delate a specific window")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _windowService.DeleteWindow(id);
            return NoContent();
        }
    }
}
