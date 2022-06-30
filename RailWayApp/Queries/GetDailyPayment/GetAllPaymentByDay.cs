using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetAllPaymentByDay(DateTime Date) : IRequest<List<PaymentResponse>>;

}
