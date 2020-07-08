using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareEvent.Models.DTOs.AddDTOs;
using ShareEvent.Services.Interfaces;

namespace ShareEvent.App.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventHostService _eventHostService;

        public EventController(IEventHostService eventHostService)
        {
            _eventHostService = eventHostService;
        }

        [HttpPost(ApiRoutes.Events.Confirm)]
        public async Task<IActionResult> Confirm([FromBody] ConfirmEventPayloadDto confirmEventPayloadDto)
        {
            try
            {
                var createdEvent = await _eventHostService.ConfirmEvent(confirmEventPayloadDto);

                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var createdObjectLocation = baseUrl + "/" + ApiRoutes.Events.Retrieve
                    .Replace("{id}", createdEvent.EventId.ToString());

                return Created(createdObjectLocation, createdEvent);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}