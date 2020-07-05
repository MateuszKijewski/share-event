using System;
using System.Collections.Generic;
using System.Text;

namespace ShareEvent.Models.Entities
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public Guid TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }
    }
}
