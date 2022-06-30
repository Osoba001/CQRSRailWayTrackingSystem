using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetBookedTripByPassenger(Guid id) : IRequest<List<BookedTripResponse>>
    {
    }
}
