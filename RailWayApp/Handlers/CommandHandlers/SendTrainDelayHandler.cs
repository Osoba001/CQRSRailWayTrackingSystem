using MediatR;
using RailWayAppLibrary.Commands;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public record SendTrainDelayHandler : IRequestHandler<SendTrainDelay, bool>
    {
        private readonly ITrainCommandRepo train;

        public SendTrainDelayHandler(ITrainCommandRepo train )
        {
            this.train = train;
        }
        public async Task<bool> Handle(SendTrainDelay request, CancellationToken cancellationToken)
        {
            train.SendTrainDeley(request.Id, request.Dey);
            await train.SaveChanges();
            return true;
        }
    }

   
}
