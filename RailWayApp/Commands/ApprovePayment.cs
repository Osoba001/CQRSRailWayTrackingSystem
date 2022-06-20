using MediatR;

namespace RailWayAppLibrary.Commands
{
    public record ApprovePayment(Guid PaymentId):IRequest<bool>;
}
