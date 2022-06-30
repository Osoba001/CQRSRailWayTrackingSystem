using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Command;
using RailWayModelLibrary.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public class GetBookedTripByDayHandler : IRequestHandler<GetBookedTripByDay, List<BookedTripResponse>>
    {
        private readonly IMapper mapper;
        private readonly IBookedTripQueryRepo bookedRepo;

        public GetBookedTripByDayHandler(IMapper _mapper, IBookedTripQueryRepo _bookedRepo)
        {
            mapper = _mapper;
            bookedRepo = _bookedRepo;
        }

        public async Task<List<BookedTripResponse>> Handle(GetBookedTripByDay request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<BookedTripResponse>>(await bookedRepo.FindByPredicate(x => x.TripDate.Date == request.day.Date));
        }
    }
}
