using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShareEvent.Models.DTOs.Contracts.Requests;
using ShareEvent.Models.DTOs.Contracts.Responses;
using ShareEvent.Models.DTOs.GetDTOs;

namespace ShareEvent.Services.Interfaces
{
    public interface IEventGuestService
    {
        Task<RetrieveEventResponse> RetrieveEvent(Guid eventId);
        Task<IEnumerable<GetReservationDto>> ReserveTickets(CreateReservationsRequest confirmReservationsPayloadDto);
    }
}