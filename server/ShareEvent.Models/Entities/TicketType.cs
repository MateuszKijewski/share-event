using System;
using System.Collections.Generic;
using System.Text;

namespace ShareEvent.Models.Entities
{
    public class TicketType
    {
        public Guid TicketTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int NumberAvailable { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
