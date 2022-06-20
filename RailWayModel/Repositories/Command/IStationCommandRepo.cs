using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command.Base;

namespace RailWayModelLibrary.Repositories.Command
{
    public interface IStationCommandRepo : ICommandRepo<Station>
    {
        Task<int> UpdateStation(Guid id, string phoneNo, Staff StationAdmin, decimal amount,
           string stationName, DateTime tripArriverTime, DateTime tripDepartingTime);
    }
}
