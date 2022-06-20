using MediatR;
using RailWayAppLibrary.Commands;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public record EndTripHandler : IRequestHandler<EndTrip, bool>
    {
        private readonly ITrainCommandRepo train;

        public EndTripHandler(ITrainCommandRepo train)
        {
            this.train = train;
        }
        public Task<bool> Handle(EndTrip request, CancellationToken cancellationToken)
        {
           return train.EndTrip(request.tranId);
        }
    }
}
