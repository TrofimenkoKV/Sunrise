using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using Microsoft.IdentityModel.Tokens;
using Sunrise.Config;
using Sunrise.Controller.Dto;
using Microsoft.Extensions.Logging;

namespace Sunrise.Service
{
    public class SecurityService
    {

        private ILogger logger;
        public SecurityService(ILogger<SecurityService> logger) 
        {
            this.logger = logger;
        }

        public string generateToken(UserDataDto userData) 
        {
            logger.LogInformation("Starting to create token for User {} ", userData.UserName);
            var token = new JwtSecurityToken(
                claims : new Claim[]
                {
                    new Claim(ClaimTypes.Name, userData.UserName),
                },
                notBefore : new DateTimeOffset(DateTime.Now).DateTime,
                expires : new DateTimeOffset(DateTime.Now.AddMinutes(2)).DateTime,
                signingCredentials : new SigningCredentials(SecurityConfig.SIGNING_KEY, SecurityAlgorithms.HmacSha256)
            );
            
            var createdToken =  new JwtSecurityTokenHandler().WriteToken(token);
            logger.LogInformation("Token created for User {} ", userData.UserName);
            
            return createdToken;
        }
    }
}