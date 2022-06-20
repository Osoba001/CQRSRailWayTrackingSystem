using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Commands
{
    public record RescheduleTrip(Guid Id, DateTime NewDate):IRequest<bool>;
   
}
