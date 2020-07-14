using System;
using System.Collections.Generic;
using System.Text;

namespace ShareEvent.Models.DTOs.GetDTOs
{
    public class GetUserDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
