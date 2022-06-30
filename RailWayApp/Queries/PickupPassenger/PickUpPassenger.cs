using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record PickUpPassenger( Guid StationId
         ) : IRequest<List<BookedTripResponse>>;
    
}
