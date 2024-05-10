using Application.Dto;
using Application.Interfaceas;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [SwaggerOperation(Summary = " Retrieves all products")]
        [HttpGet]
        public IActionResult Get()
        {
            var product = _productService.GetAllProducts();
            return Ok(product);
        }

        [SwaggerOperation(Summary = """ Retrieves a specific product by unique id""")]
        [HttpGet("{id}")]
        public IActionResult GetAction(int id) 
        {
            var product = _productService.GetProductById(id);
            if (product == null) 
            {
                return NotFound();
            }
            return Ok(product);
        }

        [SwaggerOperation(Summary = " Create a new product")]
        [HttpPost]
        public IActionResult Create(CreateProductDto newProduct)
        {
            var product = _productService.AddNewProduct(newProduct);
            return Created($"api/products/{product.Id}", product);
        }

        [SwaggerOperation(Summary = " Update a existing product")]
        [HttpPut]
        public IActionResult Update (UpdateProductDto updateProduct)
        {
            _productService.UpdateProduct(updateProduct);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delate a specific post")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
