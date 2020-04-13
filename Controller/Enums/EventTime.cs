using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sunrise.Controller.Enums
{
 //   [JsonConverter(typeof(StringEnumConverter))]
    public enum EventTime
    {
        Sunrise = 0, 
        Sunset = 1, 
        All = 2
    }
}