using Microsoft.IdentityModel.Tokens;
using RailWayAppLibrary.Utility;
using RailWayModelLibrary.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RailWayInfrastructureLibrary.Utility
{
    public class JWTAuthenticationManager : IAuthenticationManager
    {
        private string secritkey;
        private JwtSecurityTokenHandler tokenHandler;

        public JWTAuthenticationManager( string _secritkey)
        {
            secritkey = _secritkey;
        }

        public string AuthenticatePassenger(Passenger passenger)
        {
            List<Claim> claims = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier,passenger.Id.ToString()),
                 new Claim(ClaimTypes.Name, passenger.Name),
                 new Claim(ClaimTypes.Email, passenger.Email),
                 new Claim("CreatedDate", passenger.CreatedDate.ToString()),
                 new Claim(ClaimTypes.Role,"Passenger")
            };
            return Authenticate(claims);
        }

        public string AuthenticateStaff(Staff staff)
        {
            List<Claim> claims = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier,staff.Id.ToString()),
                 new Claim(ClaimTypes.Name, staff.Name),
                 new Claim(ClaimTypes.Email, staff.Email),
                 new Claim(ClaimTypes.Role,staff.Role),
                
            };

            return Authenticate(claims);
        }

        public ClaimsPrincipal VerifyToken(string token)
        {
          var tokenval=  tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secritkey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ClockSkew=TimeSpan.Zero
                }, out SecurityToken securityToken);
            return tokenval;
        }

        private string Authenticate(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secritkey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds);

           var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
