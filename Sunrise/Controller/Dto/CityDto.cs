using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Sunrise.Controller.Dto
{
    public class CityDto
    {
        public CityDto() {}
        
        public CityDto (string city, double longitude, double latitude) {
            this.City = city;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        [JsonProperty("city", Required = Required.Always)]
        public string City {get; set;}

        [JsonProperty("longitude", Required = Required.Always)]
        public double? Longitude {get;set;}

        [JsonProperty("latitude", Required = Required.Always)]
        public double? Latitude {get;set;}

        public override string ToString() 
        {
            return "Longitude: " + Longitude + " Latitude: " + Latitude + " City: " + City;          
        }
    }
}