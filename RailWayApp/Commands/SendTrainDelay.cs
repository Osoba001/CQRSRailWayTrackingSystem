using MediatR;

namespace RailWayAppLibrary.Commands
{
    public record SendTrainDelay( Guid Id, TimeSpan Dey ) : IRequest<bool>;
    
}
