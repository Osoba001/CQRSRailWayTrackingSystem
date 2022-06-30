using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetAllTrainOnTrackHandler : IRequestHandler<GetAllTrainOnTrack, List<TrainResponse>>
    {
        private readonly ITrainQueryRepo trainQuery;
        private readonly IMapper mapper;

        public GetAllTrainOnTrackHandler(ITrainQueryRepo trainQuery, IMapper mapper)
        {
            this.trainQuery = trainQuery;
            this.mapper = mapper;
        }

        public async Task<List<TrainResponse>> Handle(GetAllTrainOnTrack request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<TrainResponse>>(await trainQuery.FindByPredicate(x => x
            .TripDate.Date == DateTime.Now.Date && x.Track.Id == request.TrackId && x.IsOnTrack));
        }
    }
}
