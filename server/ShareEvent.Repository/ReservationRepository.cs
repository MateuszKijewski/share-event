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

        public async Task<Guid> AddAsync(Reservation reservation)
        {
            await _db.AddAsync(reservation);
            await _db.SaveChangesAsync();

            throw new KeyNotFoundException();
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
