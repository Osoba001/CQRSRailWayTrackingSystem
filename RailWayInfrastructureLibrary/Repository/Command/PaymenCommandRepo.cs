using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Command.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayInfrastructureLibrary.Repository.Command
{
    public class PaymenCommandRepo : CommandRepo<Payment>, IPaymentCommandRepo
    {
        private readonly RailWayDbContext context;

        public PaymenCommandRepo(RailWayDbContext context) : base(context)
        {
            this.context = context;
        }

        public void ApprovePayment(Guid paymentId)
        {
           var p=context.Set<Payment>().FirstOrDefault(x=>x.Id==paymentId);
            if (p!=null)
            {
                p.IsAprove=true;
                context.Set<Payment>().Update(p);
            }
        }
    }
}
