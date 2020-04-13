using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sunrise.Controller.Dto;
using Sunrise.Service;

namespace Sunrise.Controller
{
    [ApiController]
    [Route("api/cities")]
    public class CityController : ControllerBase
    {
        private CityService cityService = new CityService();
        
        [HttpGet]
        public List<CityDto> GetSupportedCities() 
        {
            return cityService.getAllSupportedCitites();
        }

        [HttpPost]
        public void SaveCity([FromBody]CityDto dto) 
        {
            cityService.saveCity(dto);
        }
    
    }
}