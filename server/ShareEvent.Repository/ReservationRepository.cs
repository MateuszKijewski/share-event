using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShareEvent.DataAccess;
using ShareEvent.Models.Entities;
using ShareEvent.Repository.Interfaces;

namespace ShareEvent.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ShareEventDbContext _db;

        public ReservationRepository(ShareEventDbContext db)
        {
            _db = db;
        }

        public async Task<Reservation> GetAsync(Guid reservationId)
        {
            var requestedReservation = await _db.Reservations
                .Include(r => r.TicketType)
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

            if (requestedReservation != null)
            {
                return requestedReservation;
            }
            throw new KeyNotFoundException();
        }

        public async Task<bool> AddAsync(Reservation reservation)
        {
            await _db.Reservations.AddAsync(reservation);
            var created = await _db.SaveChangesAsync();
            _db.Entry(reservation).State = EntityState.Detached;

            return created > 0;
        }

        public async Task<IEnumerable<Reservation>> ListAsync()
        {
            var requestedReservations = await _db.Reservations
                .Include(r => r.TicketType)
                .ToListAsync();

            return requestedReservations ?? new List<Reservation>();
        }
    }
}
