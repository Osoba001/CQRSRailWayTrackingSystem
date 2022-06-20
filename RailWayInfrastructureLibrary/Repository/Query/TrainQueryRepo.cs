using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Query.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayInfrastructureLibrary.Repository.Query
{
    public class TrainQueryRepo : QueryRepo<Train>, ITrainQueryRepo
    {
        public TrainQueryRepo(RailWayDbContext context) : base(context)
        {

        }
    }
}
