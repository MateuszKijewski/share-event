using System;
using System.Collections.Generic;
using System.Text;
using ShareEvent.Models.Entities;

namespace ShareEvent.Models.DTOs.Contracts.Responses
{
    public class AuthenticateResponse
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Role = user.Role;
            Token = token;
        }
    }
}
