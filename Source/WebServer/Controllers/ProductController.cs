using Microsoft.AspNetCore.Mvc;
using WebServer.Data.DTO;
using WebServer.Data.Models;
using WebServer.Data.Services;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductService _context;

        public ProductController(ProductService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.GetProduct(id);

            if (product == null)
            {
                return new Product();
            }

            return product;
        }

        [HttpGet("DTO/{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductDTO(int id)
        {
            var product = await _context.GetProductDTO(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpGet("DTO")]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProductDTO()
        {
            var product = await _context.GetAllProductDTO();

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPut]
        public async Task<ActionResult<Product>> PutProducts([FromBody] ProductDTO product)
        {
            var result = await _context.UpdateProduct(product);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] ProductDTO product)
        {
            var result = await _context.AddProduct(product);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _context.DeleteProduct(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}