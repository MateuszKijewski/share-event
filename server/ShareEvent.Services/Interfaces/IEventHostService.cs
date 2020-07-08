using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShareEvent.Models.DTOs.AddDTOs;
using ShareEvent.Models.DTOs.GetDTOs;

namespace ShareEvent.Services.Interfaces
{
    public interface IEventHostService
    {
        Task<GetEventDto> ConfirmEvent(ConfirmEventPayloadDto eventPayloadDto);
    }
}
