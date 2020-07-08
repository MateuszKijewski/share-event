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

        public GetReservationDto ReservationToGetReservationDto(Reservation reservation)
        {
            return new GetReservationDto()
            {
                ReservationId = reservation.ReservationId,
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                Email = reservation.Email,
                PhoneNumber = reservation.PhoneNumber,
                ReservedQuantity = reservation.ReservedQuantity
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
                TicketTypeId = addReservationDto.TicketTypeId,
                ReservedQuantity = addReservationDto.ReservedQuantity
            };
        }
    }
}
