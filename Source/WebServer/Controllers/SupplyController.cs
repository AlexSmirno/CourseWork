using Microsoft.AspNetCore.Mvc;
using WebServer.Data.Models;
using WebServer.Data.DTO;
using WebServer.Data.Services;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyController : ControllerBase
    {
        private readonly SupplyService _context;

        public SupplyController(SupplyService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supply>>> GetSupplys()
        {
            return await _context.GetSupplies();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supply>> GetSupply(int id)
        {
            var supply = await _context.GetSupply(id);

            if (supply == null)
            {
                return NotFound();
            }

            return supply;
        }
            
        [HttpGet("DTO/{id}")]
        public async Task<ActionResult<List<SupplyDTO>>> GetAllSupplyDTO()
        {
            var supply = await _context.GetSupplyDTO();

            if (supply == null)
            {
                return NotFound();
            }

            return supply;
        }

        [HttpPut]
        public async Task<ActionResult<Supply>> PutSupplys([FromBody] Supply supply)
        {
            var result = await _context.UpdateSupply(supply);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Supply>> PostSupply([FromBody] Supply supply)
        {
            var result = await _context.AddSupply(supply);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("out")]
        public async Task<ActionResult<bool>> PostSupplyOut([FromBody] SupplyOUTDTO supply)
        {
            var result = await _context.AddSupplyOut(supply);

            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupply(int id)
        {
            var result = await _context.DeleteSupply(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
