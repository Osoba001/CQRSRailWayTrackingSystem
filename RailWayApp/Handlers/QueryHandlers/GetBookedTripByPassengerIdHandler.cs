using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public class GetBookedTripByPassengerIdHandler : IRequestHandler<GetBookedTripByPassenger, List<BookedTripResponse>>
    {
        private readonly IMapper mapper;
        private readonly IBookedTripQueryRepo bookedRepo;

        public GetBookedTripByPassengerIdHandler(IMapper _mapper, IBookedTripQueryRepo _bookedRepo)
        {
            mapper = _mapper;
            bookedRepo = _bookedRepo;
        }

        public async Task<List<BookedTripResponse>> Handle(GetBookedTripByPassenger request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<BookedTripResponse>>(await bookedRepo.FindByPredicate(x => x.Passenger.Id==request.id));
        }
    }
}
