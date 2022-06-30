using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record DischargePassengerHandler : IRequestHandler<DischargePassenger, List<BookedTripResponse>>
    {
        private readonly IBookedTripQueryRepo bookedTrip;
        private readonly IMapper mapper;

        public DischargePassengerHandler(IBookedTripQueryRepo bookedTrip, IMapper mapper)
        {
            this.bookedTrip = bookedTrip;
            this.mapper = mapper;
        }
        public async Task<List<BookedTripResponse>> Handle(DischargePassenger request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<BookedTripResponse>>(await bookedTrip.FindByPredicate(x => x
            .DestinationStation.Id == request.StationId && x.SettledTrip && x.TripDate.Date == DateTime.Now.Date));
        }
    }
}
