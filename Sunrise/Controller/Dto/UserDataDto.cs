using Newtonsoft.Json;

namespace Sunrise.Controller.Dto
{
    public class UserDataDto
    {
        
        [JsonProperty("user_name", Required = Required.Always)]
        public string UserName {get; set;}

        [JsonProperty("password", Required = Required.Always)]
        public string Password {get; set;}
    }
}