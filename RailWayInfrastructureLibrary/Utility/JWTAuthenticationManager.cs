using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RailWayAppLibrary.Utility
{
    public class JWTAuthenticationManager : IAuthenticationManager
    {
        private readonly string secritkey;

        public JWTAuthenticationManager(string Secritkey)
        {
            secritkey = Secritkey;
        }
        public string Authenticate(string name, string email, string role)
        {
            List<Claim> claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, name),
                 new Claim(ClaimTypes.Email, email),
                 new Claim(ClaimTypes.Role, role),

            };
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
