using MediatR;
using RailWayAppLibrary.Commands;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public class RescheduleBookedTripHandler : IRequestHandler<RescheduleTrip, bool>
    {
        private readonly IBookedTripCommandRepo bookedTripRepo;

        public RescheduleBookedTripHandler(IBookedTripCommandRepo _bookedTripRepo)
        {
            bookedTripRepo = _bookedTripRepo;
        }

        public Task<bool> Handle(RescheduleTrip request, CancellationToken cancellationToken)
        {
          return  bookedTripRepo.ReschedulTrip(request.Id, request.NewDate);
        }
    }
}
