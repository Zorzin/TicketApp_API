using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketAPI.Models;

namespace TicketAPI.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class SiteEventController : Controller
    {
        // GET api/events
        [HttpGet]
        public ActionResult<IEnumerable<SiteEventPreview>> Get()
        {
            return null; //TODO
        }
    }
}