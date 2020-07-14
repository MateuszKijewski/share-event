using System;
using System.Collections.Generic;
using System.Text;
using ShareEvent.Models.DTOs.AddDTOs;
using ShareEvent.Models.DTOs.GetDTOs;
using ShareEvent.Models.Entities;

namespace ShareEvent.Models.Converters.Interfaces
{
    public interface IUserConverter
    {
        User AddUserDtoToUser(AddUserDto addUserDto);
        GetUserDto GetUserDtoToUser(User user);
    }
}
