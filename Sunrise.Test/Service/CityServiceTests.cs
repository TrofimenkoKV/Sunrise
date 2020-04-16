using System.Collections.ObjectModel;
using NUnit.Framework;
using Sunrise.Service;
using Moq;
using Sunrise.Database.Dao;
using Microsoft.Extensions.Logging;
using Sunrise.Database.Model;
using System.Collections.Generic;
using Sunrise.Controller.Dto;

namespace Sunrise.Test
{
    public class CityServiceTests
    {

        private CityService cityService;
        private static readonly string CityName = "TestCity";
        private static readonly double Longitude = 12.3;
        private static readonly double Latitude = 3.1;

        [SetUp]
        public void Setup()
        {
            Mock<CityDao> mockDao = new Mock<CityDao>();
            List<City> testList = new List<City> {
                new City(CityName, Longitude, Latitude)
            };
            mockDao.Setup(md => md.GetAll()).Returns(testList);
            Mock<ILogger<CityService>> mockLogger = new Mock<ILogger<CityService>>();

            cityService = new CityService(mockDao.Object, mockLogger.Object);
        }

        [Test]
        public void GetAllCititesCheck()
        {
            Assert.IsNotNull(cityService);
            List<CityDto> cities = cityService.getAllSupportedCitites();
            Assert.IsNotEmpty(cities);
            Assert.AreEqual(1, cities.Count);
            CityDto result = cities[0];
            Assert.AreEqual(CityName, result.City);
            Assert.AreEqual(Longitude, result.Longitude);
            Assert.AreEqual(Latitude, result.Latitude);
        }
    }
}