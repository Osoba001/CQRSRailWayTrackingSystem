using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public class GetStationTransitByDayHandler : IRequestHandler<GetStationTransitByDay, List<StationTransitResponse>>
    {
        private readonly IMapper mapper;
        private readonly IBookedTripQueryRepo bookedRepo;

        public GetStationTransitByDayHandler(IMapper _mapper, IBookedTripQueryRepo _bookedRepo)
        {
            mapper = _mapper;
            bookedRepo = _bookedRepo;
        }

        public async Task<List<StationTransitResponse>> Handle(GetStationTransitByDay request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
