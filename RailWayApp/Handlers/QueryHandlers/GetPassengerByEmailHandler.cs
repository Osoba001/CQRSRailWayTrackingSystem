using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetPassengerByEmailHandler : IRequestHandler<GetPassengerByEmail, PassengerResponse>
    {
        private readonly IPassengerQueryRepo passengerRepo;
        private readonly IMapper mapper;

        public GetPassengerByEmailHandler(IPassengerQueryRepo passengerRepo, IMapper mapper)
        {
            this.passengerRepo = passengerRepo;
            this.mapper = mapper;
        }
        public async Task<PassengerResponse> Handle(GetPassengerByEmail request, CancellationToken cancellationToken)
        {
            return mapper.Map<PassengerResponse>(await passengerRepo.FindByPredicate(x=>x.Email==request.email));
        }
    }
}
