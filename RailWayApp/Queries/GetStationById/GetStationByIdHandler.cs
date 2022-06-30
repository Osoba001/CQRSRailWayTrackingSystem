using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetStationByIdHandler : IRequestHandler<GetStationById, StationResponse>
    {
        private readonly IStationQueryRepo stationQuery;
        private readonly IMapper mapper;

        public GetStationByIdHandler(IStationQueryRepo stationQuery, IMapper mapper)
        {
            this.stationQuery = stationQuery;
            this.mapper = mapper;
        }
        public async Task<StationResponse> Handle(GetStationById request, CancellationToken cancellationToken)
        {
            return mapper.Map<StationResponse>(await stationQuery.GetById(request.Id));
        }
    }
}
