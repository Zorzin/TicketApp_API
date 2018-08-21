using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<SiteEvent> SiteEvents { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
