using Microsoft.AspNetCore.Mvc;
using Sunrise.Controller.Dto;
using Sunrise.Service;

namespace Sunrise.Controller
{
    [ApiController]
    [Route("/api/token")]
    public class JWTController : ControllerBase
    {

        private SecurityService securityService;

        public JWTController (SecurityService securityService)
        {
            this.securityService = securityService;
        }

        [HttpPost]
        public string getToken([FromBody]UserDataDto userData)
        {
            return securityService.generateToken(userData);
        }

       
    }
}