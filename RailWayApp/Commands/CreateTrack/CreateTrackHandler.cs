using AutoMapper;
using MediatR;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public record CreateTrackHandler : IRequestHandler<CreateTrack, TrackResponse>
    {
        private readonly ITrackCommandRepo trackRepo;
        private readonly IMapper mapper;

        public CreateTrackHandler(ITrackCommandRepo trackRepo, IMapper mapper)
        {
            this.trackRepo = trackRepo;
            this.mapper = mapper;
        }
        public async Task<TrackResponse> Handle(CreateTrack request, CancellationToken cancellationToken)
        {
            var t = mapper.Map<Track>(request);
            trackRepo.AddEntity(t);
            await trackRepo.SaveChanges();
            return mapper.Map<TrackResponse>(t);
        }
    }
}
