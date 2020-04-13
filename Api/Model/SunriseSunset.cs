using System;
using Newtonsoft.Json;

namespace Sunrise.Api.Model
{
    [JsonObject]
    public class SunriseSunset
    {

        [JsonProperty("sunrise")]
        public DateTime Sunrise {get; set;}
        
        [JsonProperty("sunset")]
        public DateTime Sunset {get; set;}

        public override string ToString() 
        {
          return "Sunrise: " + Sunrise + " Sunset: " + Sunset;
        }
    }
}