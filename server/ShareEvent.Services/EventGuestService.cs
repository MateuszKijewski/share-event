using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShareEvent.Models.Converters.Interfaces;
using ShareEvent.Models.DTOs.GetDTOs;
using ShareEvent.Models.DTOs.PayloadDTOs;
using ShareEvent.Repository.Interfaces;
using ShareEvent.Services.Interfaces;

namespace ShareEvent.Services
{
    public class EventGuestService : IEventGuestService
    {
        private readonly IEventConverter _eventConverter;
        private readonly IEventRepository _eventRepository;
        private readonly IReservationConverter _reservationConverter;
        private readonly IReservationRepository _reservationRepository;

        public EventGuestService(IEventConverter eventConverter,
            IEventRepository eventRepository,
            IReservationConverter reservationConverter,
            IReservationRepository reservationRepository)
        {
            _eventConverter = eventConverter;
            _eventRepository = eventRepository;
            _reservationConverter = reservationConverter;
            _reservationRepository = reservationRepository;
        }

        public async Task<RetrieveEventPayloadDto> RetrieveEvent(Guid eventId)
        {
            var requestedEvent = _eventConverter
                .EventToGetEventDto(await _eventRepository.GetAsync(eventId));
            var requestedTicketTypes = requestedEvent.TicketTypes;

            return new RetrieveEventPayloadDto()
            {
                GetEventDto = requestedEvent,
                GetTicketTypeDtos = requestedTicketTypes
            };
        }

        public async Task<IEnumerable<Guid>> ReserveTickets(ConfirmReservationsPayloadDto confirmReservationsPayloadDto)
        {
            var createdReservationsIds = new List<Guid>();
            foreach (var addReservationDto in confirmReservationsPayloadDto.AddReservationDtos)
            {
                var reservationCreated=
                    await _reservationRepository
                        .AddAsync(_reservationConverter
                            .AddReservationDtoToReservation(addReservationDto));
                if (!reservationCreated)
                {
                    throw new Exception("Failed to create reservation");
                }
                createdReservationsIds.Add(addReservationDto.ReservationId);
            }

            return createdReservationsIds;
        }
    }
}
