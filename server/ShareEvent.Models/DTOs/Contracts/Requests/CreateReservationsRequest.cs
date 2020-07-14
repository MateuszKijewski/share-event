using System.Collections.Generic;
using ShareEvent.Models.DTOs.AddDTOs;

namespace ShareEvent.Models.DTOs.Contracts.Requests
{
    public class CreateReservationsRequest
    {
        public IEnumerable<AddReservationDto> AddReservationDtos { get; set; }
    }
}
