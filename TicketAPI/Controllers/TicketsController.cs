using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketAPI.Models;

namespace TicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<IActionResult> PostTicket([FromBody] Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ticket.IsConfirmed = false;
            ticket.Code = GetRandomCode();
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }


        // POST: api/Tickets
        [HttpPost]
        public async Task<IActionResult> PostTicket([FromBody] TicketConfirmation verifyCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == verifyCode.TicketId);

            if (ticket.Code == verifyCode.TicketCode)
            {
                ticket.IsConfirmed = true;
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return Ok(ticket);
        }

        private string GetRandomCode()
        {
            return "1234"; //TODO
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}