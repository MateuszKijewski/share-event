using System;
using System.Collections.Generic;
using System.Text;

namespace ShareEvent.Models.DTOs.GetDTOs
{
    public class GetReservationDto
    {
        public Guid ReservationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Guid TicketTypeId { get; set; }
        public GetTicketTypeDto TicketType { get; set; }
    }
}
