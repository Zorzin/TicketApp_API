using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAPI.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }

        public virtual City City { get; set; }
    }
}
