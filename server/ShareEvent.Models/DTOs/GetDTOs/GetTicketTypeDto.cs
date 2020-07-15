using System;
using System.Collections.Generic;
using System.Text;

namespace ShareEvent.Models.DTOs.GetDTOs
{
    public class GetTicketTypeDto
    {
        public Guid TicketTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int NumberAvailable { get; set; }

        public Guid EventId { get; set; }
        public GetEventDto Event { get; set; }

        public IEnumerable<GetReservationDto> Reservations { get; set; }
    }
}