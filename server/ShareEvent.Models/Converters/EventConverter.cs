using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShareEvent.Models.Converters.Interfaces;
using ShareEvent.Models.DTOs.AddDTOs;
using ShareEvent.Models.DTOs.GetDTOs;
using ShareEvent.Models.Entities;

namespace ShareEvent.Models.Converters
{
    public class EventConverter : IEventConverter
    {
        private readonly ITicketTypeConverter _ticketTypeConverter;
        public EventConverter(ITicketTypeConverter ticketTypeConverter)
        {
            _ticketTypeConverter = ticketTypeConverter;
        }

        public GetEventDto EventToGetEventDto(Event eventEntity)
        {
            var ticketTypes = eventEntity.TicketTypes != null
                ? eventEntity.TicketTypes.Select(tt => _ticketTypeConverter.TicketTypeToGetTicketTypeDto(tt))
                : new List<GetTicketTypeDto>(); 

            return new GetEventDto()
            {
                EventId = eventEntity.EventId,
                Name = eventEntity.Name,
                Description = eventEntity.Description,
                Location = eventEntity.Location,
                NumberOfTickets = eventEntity.NumberOfTickets,
                Date = eventEntity.Date.ToString("d"),
                TicketTypes = ticketTypes
            };
        }

        public Event AddEventDtoToEvent(AddEventDto addEventDto)
        {
            return new Event()
            {
                EventId = addEventDto.EventId,
                Name = addEventDto.Name,
                Description = addEventDto.Description,
                Location = addEventDto.Location,
                NumberOfTickets = addEventDto.NumberOfTickets,
                Date = addEventDto.Date
            };
        }
    }
}
