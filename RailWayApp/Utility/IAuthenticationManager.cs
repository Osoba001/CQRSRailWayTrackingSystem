using RailWayModelLibrary.Entities;

namespace RailWayAppLibrary.Utility
{
    public interface IAuthenticationManager
    {
        string AuthenticateStaff(Staff staff);
        string AuthenticatePassenger(Passenger passenger);
    }
}