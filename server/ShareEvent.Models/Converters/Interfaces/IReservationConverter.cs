using System;
using System.Collections.Generic;
using System.Text;
using ShareEvent.Models.DTOs.AddDTOs;
using ShareEvent.Models.DTOs.GetDTOs;
using ShareEvent.Models.Entities;

namespace ShareEvent.Models.Converters.Interfaces
{
    public interface IReservationConverter
    {
        GetReservationDto ReservationToGetReservationDto(Reservation reservation);
        Reservation AddReservationDtoToReservation(AddReservationDto addReservationDto);
    }
}
