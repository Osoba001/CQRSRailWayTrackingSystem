using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command.Base;

namespace RailWayModelLibrary.Repositories.Command
{
    public interface ITrainCommandRepo : ICommandRepo<Train>
    {
        void SendTrainDeley(Guid traidId, TimeSpan delay);
        void DepartStation(Guid traidId);
        Task<bool> EndTrip(Guid trainId);
    }
}
