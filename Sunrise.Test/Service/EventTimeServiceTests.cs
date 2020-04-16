using NUnit.Framework;
using Sunrise.Service;
using Moq;
using Sunrise.Database.Dao;
using Microsoft.Extensions.Logging;
using Sunrise.Database.Model;
using Sunrise.Controller.Dto;
using Sunrise.Controller.Enums;
using Sunrise.Api.Dao;
using Sunrise.Api.Model;

namespace Sunrise.Test.Service
{
    public class EventTimeServiceTests
    {
        
        private EventTimeService eventTimeService;
        private static readonly string CityName = "TestCity";
        private static readonly double Longitude = 12.3;
        private static readonly double Latitude = 3.1;
        
        [SetUp]
        public void Setup()
        {
            Mock<CityDao> mockDao = new Mock<CityDao>();
            mockDao.Setup(md => md.GetCityByName(CityName)).Returns(new City(CityName, Longitude, Latitude));
            Mock<ILogger<EventTimeService>> mockLogger = new Mock<ILogger<EventTimeService>>();
            Mock<SunriseSunsetHttpDao> httpDao = new Mock<SunriseSunsetHttpDao>();
            httpDao.Setup(hd => hd.GetDayDataByLongitudeAndLatitude(Longitude, Latitude)).Returns(new SunriseSunset());

            this.eventTimeService = new EventTimeService(mockDao.Object, httpDao.Object, mockLogger.Object);
        }

        [Test]
        public void CheckRetrievedDataByEventTime()
        {
            Assert.IsNotNull(eventTimeService);
            SunriseSunsetDto result = eventTimeService.GetSunriseSunsetByCityName(CityName, EventTime.All);
            Assert.IsNotNull(result.Sunrise);
            Assert.IsNotNull(result.Sunset);

            result = eventTimeService.GetSunriseSunsetByCityName(CityName, EventTime.Sunrise);
            Assert.IsNotNull(result.Sunrise);
            Assert.IsNull(result.Sunset);

            result = eventTimeService.GetSunriseSunsetByCityName(CityName, EventTime.Sunset);
            Assert.IsNull(result.Sunrise);
            Assert.IsNotNull(result.Sunset);
        }
    }
}