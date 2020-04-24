using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Sunrise.Config
{
    public class SecurityConfig
    {
        private const string SECKRET_KEY = "thisIsS1234567890555ecret123";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECKRET_KEY));

    }
}