using MediatR;
using RailWayAppLibrary.Commands;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public record EditStationHandler : IRequestHandler<EditStation, int>
    {
        private readonly IStationCommandRepo stationRepo;

        public EditStationHandler(IStationCommandRepo stationRepo)
        {
            this.stationRepo = stationRepo;
        }
        public async Task<int> Handle(EditStation request, CancellationToken cancellationToken)
        {
            return await stationRepo.UpdateStation(request.Id, request.StationPhoneNo, request.StationAdmin,
                request.Amount, request.StationName, request.TrainArriverTime, request.TrainArriverTime);
        }
    }
}
