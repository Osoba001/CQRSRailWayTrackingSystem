using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetAllPaymentByPassenger(Guid PassengerId): IRequest<List<PaymentResponse>>;

}
