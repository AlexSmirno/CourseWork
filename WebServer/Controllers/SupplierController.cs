using Microsoft.AspNetCore.Mvc;
using WebServer.Data.DTO;
using WebServer.Data.Models;
using WebServer.Data.Services;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController:ControllerBase
    {
        private readonly SupplierService _context;

        public SupplierController(SupplierService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            return await _context.GetSuppliers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var author = await _context.GetSupplier(id);

            if (author == null)
            {
                return NotFound();
            }
                            
            return author;
        }

        [HttpPut]
        public async Task<ActionResult<Supplier>> PutSuppliers([FromBody] SupplierDTO author)
        {
            var result = await _context.UpdateSupplier(author);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> PostSupplier([FromBody] SupplierDTO supplier)
        {
            var result = await _context.AddSupplier(supplier);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var result = await _context.DeleteSupplier(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}