using TicketsValidator.Shared.Entities;

namespace TicketsValidator.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTicketsAsync();
        }

        private async Task CheckTicketsAsync()
        {
            if (!_context.Tickets.Any())
            {
                var tickets = Enumerable.Range(0, 50_000).Select(ticket => new Ticket
                {
                    Id = Guid.NewGuid(),
                    UseDate = null,
                    IsUsed = false,
                    Entry = 0
                });
                await _context.AddRangeAsync(tickets);
                await _context.SaveChangesAsync();
            }
        }
    }
}
