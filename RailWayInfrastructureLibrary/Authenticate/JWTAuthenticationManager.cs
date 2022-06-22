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
        private readonly string secritkey;

        public JWTAuthenticationManager(string Secritkey)
        {
            secritkey = Secritkey;
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
                 new Claim("StaffId",staff.StaffId)
            };

            return Authenticate(claims);
        }
        private string Authenticate(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secritkey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
