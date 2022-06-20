using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Query.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayInfrastructureLibrary.Repository.Query
{
    public class BookedTripQueryRepo:QueryRepo<BookedTrip>, IBookedTripQueryRepo
    {
        public BookedTripQueryRepo(RailWayDbContext context):base(context)
        {

        }
    }
}
