using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Commands
{
    public record DeleteStaff(Guid Id) : IRequest<int>;


}
