using System.Collections.Generic;
using ShareEvent.Models.DTOs.AddDTOs;

namespace ShareEvent.Models.DTOs.Contracts.Requests
{
    public class CreateEventRequest
    {
        public AddEventDto AddEventDto { get; set; }
        public IEnumerable<AddTicketTypeDto> AddTicketTypeDtos { get; set; }
    }
}
