using System.Data;
using System.Collections;
using System.Collections.Generic;
using Sunrise.Database.Dao;
using Sunrise.Database.Model;
using Sunrise.Controller.Dto;
using Microsoft.Extensions.Logging;

namespace Sunrise.Service
{
    public class CityService
    {
        private CityDao cityDao;
        private ILogger logger;

        public CityService(CityDao cityDao, ILogger<CityService> logger) 
        {
            this.cityDao = cityDao;
            this.logger = logger;
        }

        public List<CityDto> getAllSupportedCitites() 
        {
            logger.LogDebug("Starting to retreive all supported cities");
            List<City> cities = cityDao.GetAll();
            var result = new List<CityDto>();
            cities.ForEach(city => {
                var cityDto = new CityDto(city.CityName, city.Longitude, city.Latitude);
                result.Add(cityDto);
            });
            logger.LogDebug("Cities retreived: [{}]", cities);
            return result;
        }

        public void saveCity (CityDto cityDto)
        {
            logger.LogDebug("Saving new city: {}", cityDto);
            var persistedCity = cityDao.GetCityByName(cityDto.City);
            if(persistedCity != null) 
                throw new DuplicateNameException("Duplication exception for name " + cityDto.City);

            var longitude = cityDto.Longitude.GetValueOrDefault();
            var latitude = cityDto.Latitude.GetValueOrDefault();
            var city = new City(cityDto.City, longitude, latitude);
            logger.LogDebug("City saved successfully {} ", city);
            cityDao.SaveCity(city);
        }
    }
}