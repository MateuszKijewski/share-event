using System;

namespace ShareEvent.Models.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public byte[] Salt { get; set; }

        public string Password { get; set; }
        public string HashedPassword { get; set; }
    }
}
