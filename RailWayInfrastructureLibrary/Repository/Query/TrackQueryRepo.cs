using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Query.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayInfrastructureLibrary.Repository.Query
{
    public class TrackQueryRepo : QueryRepo<Track>, ITrackQueryRepo
    {
        public TrackQueryRepo(RailWayDbContext context) : base(context)
        {

        }
    }
}
