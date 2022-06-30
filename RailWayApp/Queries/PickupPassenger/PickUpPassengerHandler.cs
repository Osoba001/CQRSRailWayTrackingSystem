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
    public record PickUpPassengerHandler : IRequestHandler<PickUpPassenger, List<BookedTripResponse>>
    {
        private readonly IBookedTripQueryRepo bookedTrip;
        private readonly IMapper mapper;

        public PickUpPassengerHandler(IBookedTripQueryRepo bookedTrip, IMapper mapper)
        {
            this.bookedTrip = bookedTrip;
            this.mapper = mapper;
        }
        public async Task<List<BookedTripResponse>> Handle(PickUpPassenger request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<BookedTripResponse>>(await bookedTrip.FindByPredicate(x => x
            .PickupStation.Id == request.StationId && x.SettledTrip && x.TripDate.Date == DateTime.Now.Date));
        }
    }
}
