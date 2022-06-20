using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query.Base;

namespace RailWayModelLibrary.Repositories.Query
{
    public interface IStaffQueryRepo : IQueryRepo<Staff>
    {
        Staff GetStaffByLogin(string email, string password);
    }
}
