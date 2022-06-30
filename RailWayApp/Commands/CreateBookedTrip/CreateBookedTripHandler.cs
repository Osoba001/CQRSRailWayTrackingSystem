using AutoMapper;
using MediatR;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public class CreateBookedTripHandler : IRequestHandler<CreateBookedTrip, BookedTripResponse>
    {
        private readonly IBookedTripCommandRepo bookedTripRepo;
        private readonly IMapper mapper;

        public CreateBookedTripHandler(IBookedTripCommandRepo _bookedTripRepo ,IMapper _mapper)
        {
            bookedTripRepo = _bookedTripRepo;
            mapper = _mapper;
        }

        public async Task<BookedTripResponse> Handle(CreateBookedTrip request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<BookedTrip>(request);
            bookedTripRepo.AddEntity(entity);
            await bookedTripRepo.SaveChanges();
            return mapper.Map<BookedTripResponse>(entity);
        }
    }
}
