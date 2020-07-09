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
        Task<IEnumerable<GetReservationDto>> ReserveTickets(ConfirmReservationsPayloadDto confirmReservationsPayloadDto);
    }
}
//3fa85f64-5717-4562-b3fc-2c963f66afa6