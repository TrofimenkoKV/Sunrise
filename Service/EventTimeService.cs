using System;
using Sunrise.Database.Dao;
using Sunrise.Database.Model;

using Sunrise.Controller.Enums;
using Sunrise.Controller.Dto;

using Sunrise.Api.Model;
using Sunrise.Api.Dao;

namespace Sunrise.Service
{
    public class EventTimeService
    {
        private CityDao cityDao = new CityDao();

        private SunriseSunsetHttpDao sunriseSunsetHttpDao = new SunriseSunsetHttpDao();

        public SunriseSunsetDto GetSunriseSunsetByCityName (String cityName, EventTime eventTime) {
            
            City city = cityDao.GetCityByName(cityName);
            if(city == null)
                throw new Exception(String.Format("Could not find city: {0} in database ", cityName));

            SunriseSunset sunriseSunset = sunriseSunsetHttpDao.GetDayDataByLongitudeAndLatitude(city.Longitude, city.Latitude);
            if (sunriseSunset == null)
                throw new ArgumentNullException(String.Format("Could not find Sunrise and Sunset for city {0} ", city));

            return transformToSunriseSunsetDto(eventTime, city.CityName, sunriseSunset.Sunrise, sunriseSunset.Sunset);
        }

        private SunriseSunsetDto transformToSunriseSunsetDto(EventTime eventTime, String cityName, DateTime sunrise, DateTime sunset) 
        {
            var result = new SunriseSunsetDto(cityName);
            switch(eventTime) {
                case EventTime.All:
                    result.Sunset = sunset;
                    result.Sunrise = sunrise;
                    break;
                case EventTime.Sunrise:
                    result.Sunrise = sunrise;
                    break;
                case EventTime.Sunset:
                    result.Sunset = sunset;
                    break;
                default:
                    throw new NotSupportedException("Operation not supported: " + eventTime);

            }
            return result;
        } 

    }
}