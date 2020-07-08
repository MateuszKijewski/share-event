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
        private readonly IEventGuestService _eventGuestService;

        public EventController(IEventHostService eventHostService,
                            IEventGuestService eventGuestService)
        {
            _eventHostService = eventHostService;
            _eventGuestService = eventGuestService;
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

        [HttpGet(ApiRoutes.Events.Retrieve)]
        public async Task<IActionResult> Retrieve([FromRoute]Guid eventId)
        {
            try
            {
                var requestedEventWithTicketTypes = await _eventGuestService.RetrieveEvent(eventId);
                return Ok(requestedEventWithTicketTypes);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
    }
}