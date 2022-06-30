using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetPassengerById(Guid id) : IRequest<PassengerResponse>
    {
    }
}
