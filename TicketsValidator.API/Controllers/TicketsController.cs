using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketsValidator.API.Data;
using TicketsValidator.Shared.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketsValidator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id.Equals(id));

            if (ticket == null)
            {
                return NotFound($"Boleta no existente, intento de fraude");
            }

            if (ticket.IsUsed)
            {
                return BadRequest($"La boleta ya fue utilizada a las <strong>{ticket.UseDate!.Value.ToLocalTime():hh:mm:ss tt}</strong> en la entrada: <strong>{ticket.Entry}</strong>");
            }

            return Ok(ticket);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Ticket ticket)
        {
            if (ticket == null) return BadRequest();

            ticket.IsUsed = true;
            ticket.UseDate = DateTime.UtcNow;

            _context.Update(ticket);
            await _context.SaveChangesAsync();
            return Ok(ticket);
        }

    }
}
