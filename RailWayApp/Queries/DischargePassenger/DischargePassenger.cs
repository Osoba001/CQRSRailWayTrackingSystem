using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record DischargePassenger(Guid StationId
         ) : IRequest<List<BookedTripResponse>>;
}

