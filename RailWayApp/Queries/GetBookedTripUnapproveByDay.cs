using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetBookedTripUnapproveByDay(DateTime day) : IRequest<List<BookedTripResponse>>
    {
    }
}
