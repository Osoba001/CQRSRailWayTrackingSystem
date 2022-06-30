using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetStationInTrackdHandler : IRequestHandler<GetStationInTrack, List<StationResponse>>
    {
        private readonly IStationQueryRepo stationQuery;
        private readonly IMapper mapper;

        public GetStationInTrackdHandler(IStationQueryRepo stationQuery, IMapper mapper)
        {
            this.stationQuery = stationQuery;
            this.mapper = mapper;
        }
        public async Task<List<StationResponse>> Handle(GetStationInTrack request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<StationResponse>>(await stationQuery.FindByPredicate(x=>x.Track.Id==request.trackId));
        }
    }
}
