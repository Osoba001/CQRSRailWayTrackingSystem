using Microsoft.AspNetCore.Http;
using RailWayApp.Response;
using RailWayApp.Utility;
using RailWayModelLibrary.Repositories.Command;
using RailWayModelLibrary.Repositories.Query;
using System.Security.Cryptography;

namespace RailWayInfrastructure.Authenticate
{
    public class RefreshTokenGenerator : IRefreshTokenGeneraror
    {
       
        
        public ReFreshTokenResponse GenerateRefreshToken()
        {
            return new ReFreshTokenResponse
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };
        }

       
    }
    
}
