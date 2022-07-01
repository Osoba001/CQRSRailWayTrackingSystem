using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query.Base;

namespace RailWayModelLibrary.Repositories.Query
{
    public interface IPassengerQueryRepo : IQueryRepo<Passenger>
    {
        Tuple<Passenger, bool, string> Login(string email, string password);
    }
}
