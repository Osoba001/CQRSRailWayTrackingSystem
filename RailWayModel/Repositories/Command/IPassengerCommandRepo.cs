using RailWayModelLibrary.Entities;
using RailWayModelLibrary.RailWayEnums;
using RailWayModelLibrary.Repositories.Command.Base;

namespace RailWayModelLibrary.Repositories.Command
{
    public interface IPassengerCommandRepo : ICommandRepo<Passenger>
    {
        Task<Passenger> UpdatePassenger(Guid id, string address, string phoneNo, string name, string nok_phoneno, string nok_name, string nok_address, BloodGroup bloodGroup);

        Task<bool> ChangePassword(string email, string oldPassword, string newPassword);
    }
}
