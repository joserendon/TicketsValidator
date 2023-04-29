using Microsoft.EntityFrameworkCore;
using TicketsValidator.Shared.Entities;

namespace TicketsValidator.API.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
