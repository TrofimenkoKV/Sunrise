using System;
using System.Net.Http;
using Sunrise.Api.Model;
using Newtonsoft.Json;

namespace Sunrise.Api.Dao
{
    public class SunriseSunsetHttpDao
    {

        private static readonly string API_ADDRESS = "https://api.sunrise-sunset.org/json";
        private static readonly HttpClient httpClient = new HttpClient(); 
        public virtual SunriseSunset GetDayDataByLongitudeAndLatitude (double longitude, double latitude) {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "I'm awesome agent");
    
            var query = String.Format("?lat={0}&lng={1}", latitude, longitude);
            var json = httpClient.GetStringAsync(API_ADDRESS + query).Result;
            
            var result = JsonConvert.DeserializeObject<SunriseSunsetResponse>(json);
    
            return result.SunriseSunset;
        }
    }
}