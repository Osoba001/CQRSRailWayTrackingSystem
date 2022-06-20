using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetTrainsByDay(Guid TrackId, DateTime Date) : IRequest<List<TrainResponse>>;
}

