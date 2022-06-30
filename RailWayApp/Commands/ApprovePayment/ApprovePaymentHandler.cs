using MediatR;
using RailWayAppLibrary.Commands;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public record ApprovePaymentHandler : IRequestHandler<ApprovePayment, bool>
    {
        private readonly IPaymentCommandRepo payment;

        public ApprovePaymentHandler(IPaymentCommandRepo payment)
        {
            this.payment = payment;
        }
        
        public async Task<bool> Handle(ApprovePayment request, CancellationToken cancellationToken)
        {
            payment.ApprovePayment(request.PaymentId);
            await payment.SaveChanges();
            return true;
        }
    }
}
