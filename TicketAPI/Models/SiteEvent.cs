using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAPI.Models
{
    public class SiteEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PlaceId { get; set; }
        public DateTime Time { get; set; }
        public string ShortDetails { get; set; }
        public double TicketPrice { get; set; }
        public int TicketsAmount { get; set; }
        public string LongDetails { get; set; }
    }
}
