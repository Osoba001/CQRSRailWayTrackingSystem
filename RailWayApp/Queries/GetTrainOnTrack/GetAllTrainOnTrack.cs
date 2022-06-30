using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetAllTrainOnTrack(Guid TrackId) : IRequest<List<TrainResponse>>;
}

