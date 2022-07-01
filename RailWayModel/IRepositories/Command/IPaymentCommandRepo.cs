using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command.Base;

namespace RailWayModelLibrary.Repositories.Command
{
    public interface IPaymentCommandRepo : ICommandRepo<Payment>
    {
        void ApprovePayment(Guid paymentId);
    }
}
