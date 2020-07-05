using System;
using System.Collections.Generic;
using System.Text;
using ShareEvent.Models.Converters.Interfaces;
using ShareEvent.Models.DTOs.AddDTOs;
using ShareEvent.Models.DTOs.GetDTOs;
using ShareEvent.Models.Entities;

namespace ShareEvent.Models.Converters
{
    public class ReservationConverter : IReservationConverter
    {
        private readonly ITicketTypeConverter _ticketTypeConverter;

        public ReservationConverter(ITicketTypeConverter ticketTypeConverter)
        {
            _ticketTypeConverter = ticketTypeConverter;
        }

        public GetReservationDto ReservationToGetReservationDto(Reservation reservation)
        {
            return new GetReservationDto()
            {
                ReservationId = reservation.ReservationId,
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                Email = reservation.Email,
                PhoneNumber = reservation.PhoneNumber,
                TicketTypeId = reservation.TicketTypeId,
                TicketType = _ticketTypeConverter.TicketTypeToGetTicketTypeDto(reservation.TicketType)
            };
        }

        public Reservation AddReservationDtoToReservation(AddReservationDto addReservationDto)
        {
            return new Reservation()
            {
                ReservationId = addReservationDto.ReservationId,
                FirstName = addReservationDto.FirstName,
                LastName = addReservationDto.LastName,
                Email = addReservationDto.Email,
                PhoneNumber = addReservationDto.PhoneNumber,
                TicketTypeId = addReservationDto.TicketTypeId
            };
        }
    }
}
