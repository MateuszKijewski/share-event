using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShareEvent.Models.DTOs.AddDTOs
{
    public class AddTicketTypeDto
    {
        [Required]
        public Guid TicketTypeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int NumberAvailable { get; set; }

        [Required]
        public Guid EventId { get; set; }
    }
}
