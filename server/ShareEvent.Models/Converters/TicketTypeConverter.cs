using System.Linq;
using ShareEvent.Models.Converters.Interfaces;
using ShareEvent.Models.DTOs.AddDTOs;
using ShareEvent.Models.DTOs.GetDTOs;
using ShareEvent.Models.Entities;

namespace ShareEvent.Models.Converters
{
    public class TicketTypeConverter : ITicketTypeConverter
    {
        private readonly IReservationConverter _reservationConverter;

        public TicketTypeConverter(IReservationConverter reservationConverter)
        {
            _reservationConverter = reservationConverter;
        }

        public GetTicketTypeDto TicketTypeToGetTicketTypeDto(TicketType ticketType)
        {
            return new GetTicketTypeDto()
            {
                TicketTypeId = ticketType.TicketTypeId,
                Name = ticketType.Name,
                Price = ticketType.Price,
                NumberAvailable = ticketType.NumberAvailable,
                EventId = ticketType.EventId,
                Reservations = ticketType.Reservations
                    .Select(r => _reservationConverter.ReservationToGetReservationDto(r))
            };
        }

        public TicketType AddTicketTypeDtoToTicketType(AddTicketTypeDto addTicketTypeDto)
        {
            return new TicketType()
            {
                TicketTypeId = addTicketTypeDto.TicketTypeId,
                Name = addTicketTypeDto.Name,
                Price = addTicketTypeDto.Price,
                NumberAvailable = addTicketTypeDto.NumberAvailable,
                EventId = addTicketTypeDto.EventId
            };
        }
    }
}
