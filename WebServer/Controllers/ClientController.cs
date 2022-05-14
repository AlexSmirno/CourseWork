using Microsoft.AspNetCore.Mvc;
using WebServer.Data.DTO;
using WebServer.Data.Models;
using WebServer.Data.Services;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly ClientService _context;

        public ClientController(ClientService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.GetClients();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var author = await _context.GetClient(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        [HttpPut]
        public async Task<ActionResult<Client>> PutClients([FromBody] ClientDTO author)
        {
            var result = await _context.UpdateClient(author);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> PostClient([FromBody] ClientDTO supplier)
        {
            var result = await _context.AddClient(supplier);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var result = await _context.DeleteClient(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
