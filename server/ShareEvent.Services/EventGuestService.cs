using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShareEvent.Models.Converters.Interfaces;
using ShareEvent.Models.DTOs.Contracts.Requests;
using ShareEvent.Models.DTOs.Contracts.Responses;
using ShareEvent.Models.DTOs.GetDTOs;
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

        public async Task<RetrieveEventResponse> RetrieveEvent(Guid eventId)
        {
            var requestedEvent = _eventConverter
                .EventToGetEventDto(await _eventRepository.GetAsync(eventId));

            return new RetrieveEventResponse()
            {
                GetEventDto = requestedEvent
            };
        }

        public async Task<IEnumerable<GetReservationDto>> ReserveTickets(CreateReservationsRequest confirmReservationsPayloadDto)
        {
            var createdReservations = new List<GetReservationDto>();
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
                createdReservations.Add(_reservationConverter
                    .ReservationToGetReservationDto(_reservationConverter
                    .AddReservationDtoToReservation(addReservationDto)));
            }

            return createdReservations;
        }
    }
}
