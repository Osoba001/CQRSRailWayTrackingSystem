using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetTrackHandler : IRequestHandler<GetTrack, List<TrackResponse>>
    {
        private readonly ITrackQueryRepo trackQueryRepo;
        private readonly IMapper mapper;

        public GetTrackHandler(ITrackQueryRepo trackQueryRepo, IMapper mapper)
        {
            this.trackQueryRepo = trackQueryRepo;
            this.mapper = mapper;
        }

        public async Task<List<TrackResponse>> Handle(GetTrack request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<TrackResponse>>(await trackQueryRepo.GetAll());
        }
    }
}
