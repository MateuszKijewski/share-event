using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShareEvent.Models.DTOs;
using ShareEvent.Models.DTOs.Contracts.Requests;
using ShareEvent.Services.Interfaces;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ShareEvent.App.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Users.Authenticate)]
        public IActionResult Authenticate([FromBody]AuthenticateRequest authenticateRequest)
        {
            var response = _userService.Authenticate(authenticateRequest);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is  incorrect"});
            }
            return Ok(response);
        }

        [Authorize(Roles = Role.Host)]
        [HttpGet(ApiRoutes.Users.Secret)]
        public IActionResult Secret()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize(Roles = Role.Guest)]
        public IActionResult Test()
        {
            var respone = new {test = "test"};

            return Ok(respone);
        }
    }
}