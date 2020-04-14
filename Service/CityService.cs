using System.Data;
using System.Collections;
using System.Collections.Generic;
using Sunrise.Database.Dao;
using Sunrise.Database.Model;
using Sunrise.Controller.Dto;

namespace Sunrise.Service
{
    public class CityService
    {
        private CityDao cityDao;

        public CityService(CityDao cityDao) 
        {
            this.cityDao = cityDao;
        }

        public List<CityDto> getAllSupportedCitites() 
        {
            List<City> cities = cityDao.GetAll();
            var result = new List<CityDto>();
            cities.ForEach(city => {
                var cityDto = new CityDto(city.CityName, city.Longitude, city.Latitude);
                result.Add(cityDto);
            });
            return result;
        }

        public void saveCity (CityDto cityDto)
        {
            var persistedCity = cityDao.GetCityByName(cityDto.City);
            if(persistedCity != null) 
                throw new DuplicateNameException("Duplication exception for name " + cityDto.City);

            var longitude = cityDto.Longitude.GetValueOrDefault();
            var latitude = cityDto.Latitude.GetValueOrDefault();
            var city = new City(cityDto.City, longitude, latitude);
            
            cityDao.SaveCity(city);
        }
    }
}