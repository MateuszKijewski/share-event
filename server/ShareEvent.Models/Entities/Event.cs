using System;
using System.Collections.Generic;
using System.Text;

namespace ShareEvent.Models.Entities
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int NumberOfTickets { get; set; }
        public DateTime Date { get; set; }

        public IEnumerable<TicketType>? TicketTypes { get; set; }
    }
}
