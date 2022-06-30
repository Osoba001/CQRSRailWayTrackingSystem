using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetTrainsById(Guid Id) : IRequest<TrainResponse>;
}

