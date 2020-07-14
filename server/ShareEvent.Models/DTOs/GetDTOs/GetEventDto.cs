using System;
using System.Collections.Generic;
using System.Text;

namespace ShareEvent.Models.DTOs.GetDTOs
{
    public class GetEventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int NumberOfTickets { get; set; }
        public DateTime Date { get; set; }

        public IEnumerable<GetTicketTypeDto> TicketTypes { get; set; }
    }
}
