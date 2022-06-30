using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public class GetBookedTripUnapproveByDayHandler : IRequestHandler<GetBookedTripUnapproveByDay, List<BookedTripResponse>>
    {
        private readonly IMapper mapper;
        private readonly IBookedTripQueryRepo bookedRepo;

        public GetBookedTripUnapproveByDayHandler(IMapper _mapper, IBookedTripQueryRepo _bookedRepo)
        {
            mapper = _mapper;
            bookedRepo = _bookedRepo;
        }

        public async Task<List<BookedTripResponse>> Handle(GetBookedTripUnapproveByDay request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<BookedTripResponse>>(await bookedRepo.FindByPredicate(x => x.TripDate.Date == request.day.Date && !x.Payment.IsAprove));
        }
    }
}
