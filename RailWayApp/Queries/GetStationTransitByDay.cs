using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetStationTransitByDay(DateTime day) : IRequest<List<StationTransitResponse>>
    {
    }
}
