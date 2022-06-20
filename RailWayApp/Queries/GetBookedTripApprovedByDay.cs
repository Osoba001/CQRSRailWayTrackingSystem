using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetBookedTripApprovedByDay(DateTime day) : IRequest<List<BookedTripResponse>>
    {
    }
}
