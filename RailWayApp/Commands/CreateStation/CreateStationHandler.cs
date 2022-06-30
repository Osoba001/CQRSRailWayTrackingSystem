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
    public record CreateStationHandler : IRequestHandler<CreateStation, StationResponse>
    {
        private readonly IStationCommandRepo stationRepo;
        private readonly IMapper mapper;

        public CreateStationHandler(IStationCommandRepo stationRepo, IMapper mapper)
        {
            this.stationRepo = stationRepo;
            this.mapper = mapper;
        }
        public async Task<StationResponse> Handle(CreateStation request, CancellationToken cancellationToken)
        {
            var s = mapper.Map<Station>(request);
            stationRepo.AddEntity( s);
            await stationRepo.SaveChanges();
            return mapper.Map<StationResponse>(s);
        }
    }
}
