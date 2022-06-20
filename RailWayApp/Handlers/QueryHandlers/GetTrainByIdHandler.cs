using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetTrainByIdHandler : IRequestHandler<GetTainsById, TrainResponse>
    {
        private readonly ITrainQueryRepo trainQuery;
        private readonly IMapper mapper;

        public GetTrainByIdHandler(ITrainQueryRepo trainQuery, IMapper mapper)
        {
            this.trainQuery = trainQuery;
            this.mapper = mapper;
        }

        public async Task<TrainResponse> Handle(GetTainsById request, CancellationToken cancellationToken)
        {
            return mapper.Map<TrainResponse>(await trainQuery.GetById(request.Id));
        }
    }
}
