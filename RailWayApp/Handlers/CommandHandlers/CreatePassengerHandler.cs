using AutoMapper;
using MediatR;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;
using static RailWayAppLibrary.Utility.Encrption;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public class CreatePassengerHandler : IRequestHandler<CreatePassenger, PassengerResponse>
    {
        private readonly IPassengerCommandRepo repo;
        private readonly IStaffCommandRepo staff;
        private readonly IMapper mapper;

        public CreatePassengerHandler(IPassengerCommandRepo repo,IStaffCommandRepo staff, IMapper mapper)
        {
            this.repo = repo;
            this.staff = staff;
            this.mapper = mapper;
        }
        public async Task<PassengerResponse> Handle(CreatePassenger request, CancellationToken cancellationToken)
        {
            if (!repo.IfExist(x => x.Email.ToLower() == request.Email.ToLower()) && !staff.IfExist(x => x.Email.ToLower() == request.Email.ToLower()))
            {
                var s = mapper.Map<Passenger>(request);
                var p = CreateHashPassword(request.Password);
                s.PasswordHash = p.Item1;
                s.PasswordSalt = p.Item2;
                repo.AddEntity(s);
               await repo.SaveChanges();
                return  mapper.Map<PassengerResponse>(s);
            }
            throw new Exception("This email is already in used");
        }
    }
}
