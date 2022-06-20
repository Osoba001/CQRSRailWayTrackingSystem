using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetTainsById(Guid Id) : IRequest<TrainResponse>;
}

