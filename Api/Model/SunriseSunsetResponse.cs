using Newtonsoft.Json;

namespace Sunrise.Api.Model
{
    public class SunriseSunsetResponse
    {
        [JsonProperty("results")]
        public SunriseSunset SunriseSunset {get; set;}
        
        [JsonProperty("status")]
        public string Status {get;set;} 

        public override string ToString() 
        {
            return "Status: " + Status + " SunriseSunset: " + SunriseSunset ;
        } 
      
    }
}