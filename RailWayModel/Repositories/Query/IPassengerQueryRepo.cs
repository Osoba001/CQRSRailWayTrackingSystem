using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query.Base;

namespace RailWayModelLibrary.Repositories.Query
{
    public interface IPassengerQueryRepo : IQueryRepo<Passenger>
    {
        string Login(string email, string password);
    }
}
