using MediatR;
using RailWayAppLibrary.Commands;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public class DeletePastUnapproveBookedTripHandler : IRequestHandler<DeletePastUnapproveTrip, int>
    {
        private readonly IBookedTripCommandRepo bookedTripRepo;

        public DeletePastUnapproveBookedTripHandler(IBookedTripCommandRepo _bookedTripRepo )
        {
            bookedTripRepo = _bookedTripRepo;
        }

        public Task<int> Handle(DeletePastUnapproveTrip request, CancellationToken cancellationToken)
        {
           return bookedTripRepo.RemovePastUnapproveTrips();
        }
    }
}
