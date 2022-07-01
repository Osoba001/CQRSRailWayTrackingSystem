using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query.Base;

namespace RailWayModelLibrary.Repositories.Query
{
    public interface IStaffQueryRepo : IQueryRepo<Staff>
    {
        Tuple<Staff, bool, string> Login(string email, string password);
    }
}
