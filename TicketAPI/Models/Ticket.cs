using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SiteEventId { get; set; }
        public double Price { get; set; }
        public string Owner { get; set; }
        public string Code { get; set; }
        public bool IsConfirmed { get; set; }

        public virtual SiteEvent SiteEvent { get; set; }

    }
}
