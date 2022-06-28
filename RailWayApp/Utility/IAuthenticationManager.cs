using RailWayModelLibrary.Entities;
using System.Security.Claims;

namespace RailWayAppLibrary.Utility
{
    public interface IAuthenticationManager
    {
        string AuthenticateStaff(Staff staff);
        string AuthenticatePassenger(Passenger passenger);
        ClaimsPrincipal VerifyToken(string token);
    }
}