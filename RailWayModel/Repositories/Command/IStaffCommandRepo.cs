using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command.Base;

namespace RailWayModelLibrary.Repositories.Command
{
    public interface IStaffCommandRepo : ICommandRepo<Staff>
    {
        Task<Staff> UpdateStaff(Guid id, string address, string phoneNo, string name, string role);
        Task<bool> ChangePassword(Guid Id, string oldPassword, string newPassword);
    }
}
