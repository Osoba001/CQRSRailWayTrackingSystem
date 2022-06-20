using MediatR;
using RailWayAppLibrary.Commands;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public record SettleTripHandler : IRequestHandler<SettleTrip, bool>
    {
        private readonly IBookedTripCommandRepo bookedTrip;

        public SettleTripHandler(IBookedTripCommandRepo bookedTrip)
        {
            this.bookedTrip = bookedTrip;
        }
        public Task<bool> Handle(SettleTrip request, CancellationToken cancellationToken)
        {
            bookedTrip.SettledTrip(request.tripId);
            return Task.FromResult(true);
        }
    }
}
