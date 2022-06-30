using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetTrainByDayHandler : IRequestHandler<GetTrainsByDay, List<TrainResponse>>
    {
        private readonly ITrainQueryRepo trainQuery;
        private readonly IMapper mapper;

        public GetTrainByDayHandler(ITrainQueryRepo trainQuery, IMapper mapper)
        {
            this.trainQuery = trainQuery;
            this.mapper = mapper;
        }

        public async Task<List<TrainResponse>> Handle(GetTrainsByDay request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<TrainResponse>>(await trainQuery.FindByPredicate(x=>x
            .TripDate.Date==request.Date.Date && x.Track.Id==request.TrackId));
        }
    }
}
