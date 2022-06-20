using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Query.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayInfrastructureLibrary.Repository.Query
{
    public class PaymentQueryRepo : QueryRepo<Payment>, IPaymentQueryRepo
    {
        public PaymentQueryRepo(RailWayDbContext context) : base(context)
        {

        }
    }
}
