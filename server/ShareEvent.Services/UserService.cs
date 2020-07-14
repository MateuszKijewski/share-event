using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShareEvent.Models.DTOs;
using ShareEvent.Models.DTOs.Contracts.Requests;
using ShareEvent.Models.DTOs.Contracts.Responses;
using ShareEvent.Models.Entities;
using ShareEvent.Services.Interfaces;

namespace ShareEvent.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IConfiguration configuration,
                        IPasswordHasher passwordHasher)
        {
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        private List<User> GetListOfUsers()
        {
            var password1 = "test1";
            var hashedPassword1 = _passwordHasher.HashPassword(password1);

            var password2 = "test2";
            var hashedPassword2 = _passwordHasher.HashPassword(password1);

            var user1 = new User
            {
                UserId = new Guid(),
                FirstName = "Test", LastName = "User", Email = "test@test.pl",
                Password = password1, HashedPassword = hashedPassword1,
                Role = Role.Host
            };
            var user2 = new User
            {
                UserId = new Guid(), FirstName = "Test2", LastName = "User2",
                Email = "test2@test2.pl", Password = password2, HashedPassword = hashedPassword2,
                Role = Role.Guest
            };
            var users = new List<User>()
            {
                user1,
                user2
            };


            return users;
        }

        

        public AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest)
        {
            var user = GetListOfUsers().SingleOrDefault(u => u.Email == authenticateRequest.Email);
                                                   
            if (user == null)
            {
                return null;
            }

            var testHashed = _passwordHasher.HashPassword("test1");
            if (_passwordHasher.VerifyHashedPassword(testHashed, "test1") == PasswordVerificationResult.Success)
            {
                return null;
            }
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return GetListOfUsers();
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
