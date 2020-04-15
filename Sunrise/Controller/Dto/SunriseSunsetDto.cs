using System;
using Newtonsoft.Json;

namespace Sunrise.Controller.Dto
{

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SunriseSunsetDto
    {

        public SunriseSunsetDto(string cityName) 
        {
            this.CityName = cityName;
        }

        [JsonProperty("city_name")]
        public string CityName {get;set;}
        
        [JsonProperty("sunrise")]
        public DateTime? Sunrise {get;set;}

        [JsonProperty("sunset")]
        public DateTime? Sunset {get; set;}       

        public override string ToString() 
        {
            return "CityName: " + CityName + " Sunrise: " + Sunrise + " Sunset: " + Sunset;
        } 
    }
    
}