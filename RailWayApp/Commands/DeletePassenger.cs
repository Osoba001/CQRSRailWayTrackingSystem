using MediatR;

namespace RailWayAppLibrary.Commands
{
    public record DeletePassenger(Guid Id) : IRequest<int>;

}
