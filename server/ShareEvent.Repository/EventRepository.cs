using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShareEvent.DataAccess;
using ShareEvent.Models.Entities;
using ShareEvent.Repository.Interfaces;

namespace ShareEvent.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ShareEventDbContext _db;

        public EventRepository(ShareEventDbContext db)
        {
            _db = db;
        }

        public async Task<Event> GetAsync(Guid eventId)
        {
            var requestedEvent = await _db.Events
                .Include(e => e.TicketTypes ?? new List<TicketType>())
                .ThenInclude(tt => tt.Reservations ?? new List<Reservation>())
                .FirstOrDefaultAsync(e => e.EventId == eventId);
            if (requestedEvent != null)
            {
                return requestedEvent;
            }
            throw new KeyNotFoundException();
        }

        public async Task<bool> AddAsync(Event eventEntity)
        {
            await _db.Events.AddAsync(eventEntity);
            var created = await _db.SaveChangesAsync();

            return created > 0;
        }

        public async Task<IEnumerable<Event>> ListAsync()
        {
            var requestedEvents = await _db.Events
                .Include(e => e.TicketTypes ?? new List<TicketType>())
                .ThenInclude(tt => tt.Reservations ?? new List<Reservation>()).ToListAsync();

            return requestedEvents ?? new List<Event>();
        }
    }
}
