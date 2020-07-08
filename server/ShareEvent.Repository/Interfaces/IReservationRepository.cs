using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShareEvent.Models.Entities;

namespace ShareEvent.Repository.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> GetAsync(Guid reservationId);
        Task<bool> AddAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> ListAsync();
    }
}
