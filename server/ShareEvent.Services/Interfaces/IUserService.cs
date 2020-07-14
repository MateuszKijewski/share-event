using System;
using System.Collections.Generic;
using System.Text;
using ShareEvent.Models.DTOs;
using ShareEvent.Models.DTOs.Contracts.Requests;
using ShareEvent.Models.DTOs.Contracts.Responses;
using ShareEvent.Models.Entities;

namespace ShareEvent.Services.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest);
        IEnumerable<User> GetAll();
    }
}
