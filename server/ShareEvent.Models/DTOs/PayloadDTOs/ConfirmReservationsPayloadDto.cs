using System;
using System.Collections.Generic;
using System.Text;
using ShareEvent.Models.DTOs.AddDTOs;

namespace ShareEvent.Models.DTOs.PayloadDTOs
{
    public class ConfirmReservationsPayloadDto
    {
        public IEnumerable<AddReservationDto> AddReservationDtos { get; set; }
    }
}
