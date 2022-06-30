using AutoMapper;
using MediatR;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public class EditPassengerHandler : IRequestHandler<EditPassenger, PassengerResponse>
    {
        private readonly IPassengerCommandRepo repo;
        private readonly IMapper mapper;

        public EditPassengerHandler(IPassengerCommandRepo repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<PassengerResponse> Handle(EditPassenger request, CancellationToken cancellationToken)
        {
            return mapper.Map<PassengerResponse>(await repo.UpdatePassenger(request.Id, request.Address, request.PhoneNo, request.Name, request.NOK_PhoneNo, request.NOK_Name, request.NOK_Address, request.BloodGroup));
           
        }
    }
}
