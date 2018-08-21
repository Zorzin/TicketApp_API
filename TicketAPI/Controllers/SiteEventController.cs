using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketAPI.Models;

namespace TicketAPI.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class SiteEventController : Controller
    {
        private readonly AppDbContext _context;

        public SiteEventController(AppDbContext context)
        {
            _context = context;
        }
        // GET api/events
        [HttpGet]
        public ActionResult<IEnumerable<SiteEventPreview>> Get()
        {
            var siteEvents = _context.SiteEvents
                .Include(x=>x.Place)
                .ThenInclude(p=>p.City);

            return siteEvents.Select(siteEvent => new SiteEventPreview()
                {
                    SiteEventId = siteEvent.Id,
                    Place = siteEvent.Place.Name,
                    Description = siteEvent.ShortDetails,
                    City = siteEvent.Place.City.Name,
                    Time = siteEvent.Time,
                    Title = siteEvent.Title
                })
                .ToList();
        }

        [HttpGet("{eventId}")]
        public async Task<SiteEvent> GetEvent([FromRoute] int eventId)
        {
            return await _context.SiteEvents
                .Include(x=>x.Place)
                .ThenInclude(x=>x.City)
                .FirstOrDefaultAsync(x => x.Id == eventId);
        }
    }
}