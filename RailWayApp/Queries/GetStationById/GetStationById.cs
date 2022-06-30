using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetStationById(Guid Id) : IRequest<StationResponse>;
}
