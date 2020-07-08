using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShareEvent.DataAccess;
using ShareEvent.Models.Entities;
using ShareEvent.Repository.Interfaces;

namespace ShareEvent.Repository
{
    public class TicketTypeRepository : ITicketTypeRepository
    {
        private readonly ShareEventDbContext _db;

        public TicketTypeRepository(ShareEventDbContext db)
        {
            _db = db;
        }

        public async Task<TicketType> GetAsync(Guid ticketTypeId)
        {
            var requestedTicketType = await _db.TicketTypes
                .Include(tt => tt.Reservations ?? new List<Reservation>())
                .Include(tt => tt.Event)
                .FirstOrDefaultAsync(tt => tt.TicketTypeId == ticketTypeId);
            if (requestedTicketType != null)
            {
                return requestedTicketType;
            }
            throw new KeyNotFoundException();
        }

        public async Task<bool> AddAsync(TicketType ticketType)
        {
            await _db.TicketTypes.AddAsync(ticketType);
            var created = await _db.SaveChangesAsync();

            return created > 0;
        }

        public async Task<IEnumerable<TicketType>> ListAsync()
        {
            var requestedTicketTypes = await _db.TicketTypes
                .Include(tt => tt.Reservations ?? new List<Reservation>())
                .Include(tt => tt.Event)
                .ToListAsync();

            return requestedTicketTypes ?? new List<TicketType>();
        }
    }
}
