using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetPassengerByIdHandler : IRequestHandler<GetPassengerById, PassengerResponse>
    {
        private readonly IPassengerQueryRepo passengerRepo;
        private readonly IMapper mapper;

        public GetPassengerByIdHandler(IPassengerQueryRepo passengerRepo,IMapper mapper )
        {
            this.passengerRepo = passengerRepo;
            this.mapper = mapper;
        }
        public async Task<PassengerResponse> Handle(GetPassengerById request, CancellationToken cancellationToken)
        {
            return mapper.Map<PassengerResponse>( await passengerRepo.GetById(request.id));
        }
    }
}
