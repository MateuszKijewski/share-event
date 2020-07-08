using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShareEvent.Models.Entities;

namespace ShareEvent.Repository.Interfaces
{
    public interface ITicketTypeRepository
    {
        Task<TicketType> GetAsync(Guid ticketTypeId);
        Task<bool> AddAsync(TicketType ticketType);
        Task<IEnumerable<TicketType>> ListAsync();
    }
}
