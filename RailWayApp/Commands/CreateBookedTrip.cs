using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Commands
{
    public record CreateBookedTrip(Guid PickupStationID, Guid DestinationStationID,
        DateTime TripDate, Guid PassengerId, int NumberOfSeat): IRequest<BookedTripResponse>;
    
}
