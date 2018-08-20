using System;

namespace TicketAPI.Models
{
    public class SiteEventPreview
    {
        public int SiteEventId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Place { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
    }
}