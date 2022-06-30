using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetTopNPassenger( int n) : IRequest<List<PassengerResponse>>
    {
    }
}
