using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShareEvent.Models.DTOs.GetDTOs;
using ShareEvent.Models.DTOs.PayloadDTOs;

namespace ShareEvent.Services.Interfaces
{
    public interface IEventGuestService
    {
        Task<RetrieveEventPayloadDto> RetrieveEvent(Guid eventId);
        Task<IEnumerable<Guid>> ReserveTickets(ConfirmReservationsPayloadDto confirmReservationsPayloadDto);
    }
}
