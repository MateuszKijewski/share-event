using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using iReception.Test;
using Moq;
using ShareEvent.Models.Converters.Interfaces;
using ShareEvent.Models.DTOs.AddDTOs;
using ShareEvent.Models.DTOs.GetDTOs;
using ShareEvent.Models.Entities;
using ShareEvent.Repository.Interfaces;
using ShareEvent.Services;
using Xunit;

namespace ShareEvent.Tests.EventTests
{
    public class EventServicesTests : InMemoryDatabaseFixture
    {
        [Fact]
        public async Task ShouldCreateEventWithTicketTypes()
        {
            //Arrange
            var testEvent = new AddEventDto()
            {
                EventId = new Guid(),
                Name = "testName",
                Location = "testLocation",
                NumberOfTickets = 250,
                Date = DateTime.Now
            };
            var testTicketType1 = new AddTicketTypeDto()
            {
                TicketTypeId = new Guid(),
                Name = "testTicketName1",
                Price = 100,
                NumberAvailable = 1000,
                EventId = testEvent.EventId

            };
            var testTicketType2 = new AddTicketTypeDto()
            {
                TicketTypeId = new Guid(),
                Name = "testTicketName1",
                Price = 100,
                NumberAvailable = 1000,
                EventId = testEvent.EventId

            };

            var eventRepositoryMock = new Mock<IEventRepository>();
            eventRepositoryMock
                .Setup(er => er.AddAsync(It.IsAny<Event>()))
                .ReturnsAsync(true);
            var ticketTypeRepositoryMock = new Mock<ITicketTypeRepository>();
            ticketTypeRepositoryMock
                .Setup(tt => tt.AddAsync(It.IsAny<TicketType>()))
                .ReturnsAsync(true);

            var eventConverterMock = new Mock<IEventConverter>();
            eventConverterMock
                .Setup(ec => ec.AddEventDtoToEvent(It.IsAny<AddEventDto>()))
                .Returns(new Event()
                {
                    EventId = testEvent.EventId
                });
            eventConverterMock
                .Setup(ec => ec.EventToGetEventDto(It.IsAny<Event>()))
                .Returns(new GetEventDto()
                {
                    EventId = testEvent.EventId
                });
            var ticketTypeConverterMock = new Mock<ITicketTypeConverter>();
            ticketTypeConverterMock
                .Setup(ttc => ttc.AddTicketTypeDtoToTicketType(It.IsAny<AddTicketTypeDto>()))
                .Returns(new TicketType());

            var service = new EventHostService(
                eventConverterMock.Object,
                eventRepositoryMock.Object,
                ticketTypeConverterMock.Object,
                ticketTypeRepositoryMock.Object);

            
            var request = new ConfirmEventPayloadDto()
            {
                AddEventDto = testEvent,
                AddTicketTypeDtos = new List<AddTicketTypeDto>()
                {
                    testTicketType1,
                    testTicketType2
                }
            };

            //Act
            var createdEvent = await service.ConfirmEvent(request);
            var actualResponse = createdEvent.EventId;
            var expectedResponse = testEvent.EventId;

            //Assert
            actualResponse.Should().Be(expectedResponse);

        }
    }
}
