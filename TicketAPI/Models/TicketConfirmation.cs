using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAPI.Models
{
    public class TicketConfirmation
    {
        public int TicketId { get; set; }
        public string TicketCode { get; set; }
    }
}
