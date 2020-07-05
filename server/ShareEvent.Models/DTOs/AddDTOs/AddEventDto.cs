using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShareEvent.Models.DTOs.AddDTOs
{
    public class AddEventDto
    {
        [Required]
        public Guid EventId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Location { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int NumberOfTickets { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
