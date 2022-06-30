using MediatR;
using RailWayAppLibrary.Commands;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public record DepartStationHandler : IRequestHandler<DepartStation, bool>
    {
        private readonly ITrainCommandRepo train;

        public DepartStationHandler(ITrainCommandRepo train)
        {
            this.train = train;
        }
        public Task<bool> Handle(DepartStation request, CancellationToken cancellationToken)
        {
            train.DepartStation(request.trainId);
            return Task.FromResult(true);
        }
    }
}
