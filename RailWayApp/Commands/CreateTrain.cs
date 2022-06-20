using MediatR;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Entities;

namespace RailWayAppLibrary.Commands
{
    public record CreateTrain(
         string Name , int Capacity ,Staff TrailEngineer, Track Track
         ):IRequest<TrainResponse>;
    
}
