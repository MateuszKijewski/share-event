using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShareEvent.Models.DTOs.AddDTOs
{
    public class AddReservationDto
    {
        [Required]
        public Guid ReservationId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        
        [Required]
        public Guid TicketTypeId { get; set; }
    }
}
