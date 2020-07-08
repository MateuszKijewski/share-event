using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShareEvent.Models.Converters.Interfaces;
using ShareEvent.Models.DTOs.AddDTOs;
using ShareEvent.Models.DTOs.GetDTOs;
using ShareEvent.Repository.Interfaces;
using ShareEvent.Services.Interfaces;

namespace ShareEvent.Services
{
    public class EventHostService : IEventHostService
    {
        private readonly IEventConverter _eventConverter;
        private readonly IEventRepository _eventRepository;
        private readonly ITicketTypeConverter _ticketTypeConverter;
        private readonly ITicketTypeRepository _ticketTypeRepository;

        public EventHostService(IEventConverter eventConverter,
                                IEventRepository eventRepository,
                                ITicketTypeConverter ticketTypeConverter,
                                ITicketTypeRepository ticketTypeRepository)
        {
            _eventConverter = eventConverter;
            _eventRepository = eventRepository;
            _ticketTypeConverter = ticketTypeConverter;
            _ticketTypeRepository = ticketTypeRepository;
        }

        public async Task<GetEventDto> ConfirmEvent(ConfirmEventPayloadDto confirmEventPayloadDto)
        {
            var eventPayload = confirmEventPayloadDto.AddEventDto;
            var createdEvent = _eventConverter
                .EventToGetEventDto(_eventConverter.AddEventDtoToEvent(eventPayload));
            var ticketTypesPayload = confirmEventPayloadDto.AddTicketTypeDtos;

            var eventCreated = await _eventRepository
                .AddAsync(_eventConverter.AddEventDtoToEvent(eventPayload));
            if (!eventCreated)
            {
                throw new Exception("Event creation failed");
            }
            foreach (var ticketType in ticketTypesPayload)
            {
                await _ticketTypeRepository
                    .AddAsync(_ticketTypeConverter.AddTicketTypeDtoToTicketType(ticketType));
            }

            return createdEvent;
        }
    }
}
