using System;
using System.Collections.Generic;
using System.Text;
using ShareEvent.Models.Converters.Interfaces;
using ShareEvent.Models.DTOs;
using ShareEvent.Models.DTOs.AddDTOs;
using ShareEvent.Models.DTOs.GetDTOs;
using ShareEvent.Models.Entities;

namespace ShareEvent.Models.Converters
{
    public class UserConverter : IUserConverter
    {
        public User AddUserDtoToUser(AddUserDto addUserDto)
        {
            var role = addUserDto.IsHost ? Role.Host : Role.Guest;
            return new User()
            {
                UserId = addUserDto.UserId,
                FirstName = addUserDto.FirstName,
                LastName = addUserDto.LastName,
                Email = addUserDto.Email,
                Role = role,
                HashedPassword = addUserDto.HashedPassword
            };
        }

        public GetUserDto GetUserDtoToUser(User user)
        {
            return new GetUserDto()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
            };
        }
    }
}
