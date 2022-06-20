using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Query.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayInfrastructureLibrary.Repository.Query
{
    public class StationQueryRepo : QueryRepo<Station>, IStationQueryRepo
    {
        public StationQueryRepo(RailWayDbContext context) : base(context)
        {

        }
    }
}
