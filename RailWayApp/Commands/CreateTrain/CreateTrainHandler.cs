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
    public record CreateTrainHandler : IRequestHandler<CreateTrain, TrainResponse>
    {
        private readonly ITrainCommandRepo trainRepo;
        private readonly IMapper map;

        public CreateTrainHandler(ITrainCommandRepo trainRepo, IMapper map)
        {
            this.trainRepo = trainRepo;
            this.map = map;
        }
        public async Task<TrainResponse> Handle(CreateTrain request, CancellationToken cancellationToken)
        {
           trainRepo.AddEntity(map.Map<Train>(request));
           await trainRepo.SaveChanges();
            return map.Map<TrainResponse>(request);
        }
    }

   
}
