using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShareEvent.Models.Entities;

namespace ShareEvent.Repository.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> GetAsync(Guid eventId);
        Task<bool> AddAsync(Event eventEntity);
        Task<IEnumerable<Event>> ListAsync();
    }
}
