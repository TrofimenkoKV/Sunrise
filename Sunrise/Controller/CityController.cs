using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Sunrise.Controller.Dto;
using Sunrise.Service;

namespace Sunrise.Controller
{
    [ApiController]
    [Route("api/cities")]
    [Authorize]
    public class CityController : ControllerBase
    {
        private CityService cityService;

        public CityController(CityService cityService) {
            this.cityService = cityService;
        }
        
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