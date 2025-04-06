using Microsoft.EntityFrameworkCore;
using Eventease.Models;

namespace Eventease.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Venue> Venues { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}
