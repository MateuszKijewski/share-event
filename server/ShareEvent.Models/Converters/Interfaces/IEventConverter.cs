﻿using System;
using System.Collections.Generic;
using System.Text;
using ShareEvent.Models.DTOs.AddDTOs;
using ShareEvent.Models.DTOs.GetDTOs;
using ShareEvent.Models.Entities;
using xd = ShareEvent;

namespace ShareEvent.Models.Converters.Interfaces
{
    public interface IEventConverter
    {
        GetEventDto EventToGetEventDto(Event eventEntity);
        Event AddEventDtoToEvent(AddEventDto addEventDto);
    }
}
