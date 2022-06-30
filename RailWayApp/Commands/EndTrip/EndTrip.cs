using MediatR;

namespace RailWayAppLibrary.Commands
{
    public record EndTrip(Guid tranId):IRequest<bool>;
    
}
