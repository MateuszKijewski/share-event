using System;
using System.Collections.Generic;
using System.Text;

namespace ShareEvent.Models.DTOs.GetDTOs
{
    public class RetrieveEventPayloadDto
    {
        public GetEventDto GetEventDto { get; set; }
        public IEnumerable<GetTicketTypeDto> GetTicketTypeDtos { get; set; }
    }
}
