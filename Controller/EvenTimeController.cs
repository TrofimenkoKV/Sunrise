using Sunrise.Service;
using Microsoft.AspNetCore.Mvc;
using Sunrise.Controller.Enums;
using Sunrise.Controller.Dto;

namespace Sunrise.Controller
{
    [ApiController]
    [Route("api/event-time")]
    public class EventTimeController : ControllerBase
    {

        private EventTimeService eventTimeService;

        public EventTimeController(EventTimeService eventTimeService) 
        {
            this.eventTimeService = eventTimeService;
        }

        [HttpGet("{cityName}")]
        public SunriseSunsetDto GetEventTime(string cityName, [FromQuery(Name = "event_time")] EventTime eventTime = EventTime.All) 
        {
            return eventTimeService.GetSunriseSunsetByCityName(cityName, eventTime);
        }
    }
}