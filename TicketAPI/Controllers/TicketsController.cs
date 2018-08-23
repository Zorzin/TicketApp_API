using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketAPI.Models;
using TicketAPI.Services;

namespace TicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private IEmailSender _emailSender;
        private readonly AppDbContext _context;
        private static Random random = new Random();

        public TicketsController(AppDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
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
            await _emailSender.SendAsync(new Email()
            {
                Body = "Your activation code is: " + ticket.Code,
                Recipient = ticket.Email,
                Subject = "Activation code"
            });
            return Ok(ticket.Id);
        }


        // POST: api/Tickets
        [HttpPost("verificationCode")]
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
                return Ok(ticket);
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
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}