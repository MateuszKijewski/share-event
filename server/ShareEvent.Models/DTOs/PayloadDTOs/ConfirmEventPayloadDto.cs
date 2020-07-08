using System;
using System.Collections.Generic;
using System.Text;

namespace ShareEvent.Models.DTOs.AddDTOs
{
    public class ConfirmEventPayloadDto
    {
        public AddEventDto AddEventDto { get; set; }
        public IEnumerable<AddTicketTypeDto> AddTicketTypeDtos { get; set; }
    }
}
