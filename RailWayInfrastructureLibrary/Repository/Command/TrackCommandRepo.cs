using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Command.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayInfrastructureLibrary.Repository.Command
{
    public class TrackCommandRepo : CommandRepo<Track>, ITrackCommandRepo
    {
        public TrackCommandRepo(RailWayDbContext context) : base(context)
        {

        }
    }
}
