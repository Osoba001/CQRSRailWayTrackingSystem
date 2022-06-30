using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetTopNPassengerHandler : IRequestHandler<GetTopNPassenger, List<PassengerResponse>>
    {
        private readonly IPassengerQueryRepo passengerRepo;
        private readonly IMapper mapper;

        public GetTopNPassengerHandler(IPassengerQueryRepo passengerRepo, IMapper mapper)
        {
            this.passengerRepo = passengerRepo;
            this.mapper = mapper;
        }
        public async Task<List<PassengerResponse>> Handle(GetTopNPassenger request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<PassengerResponse>>(await passengerRepo.GetTopN(request.n));
        }
    }
}
