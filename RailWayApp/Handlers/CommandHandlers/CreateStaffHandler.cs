using AutoMapper;
using MediatR;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;
using static RailWayAppLibrary.Utility.Encrption;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public class CreateStaffHandler : IRequestHandler<CreateStaff, StaffResponse>
    {
        private readonly IStaffCommandRepo repo;
        private readonly IPassengerCommandRepo passenger;
        private readonly IMapper mapper;

        public CreateStaffHandler(IStaffCommandRepo repo,IPassengerCommandRepo passenger,  IMapper mapper)
        {
            this.repo = repo;
            this.passenger = passenger;
            this.mapper = mapper;
        }
        public async Task<StaffResponse> Handle(CreateStaff request, CancellationToken cancellationToken)
        {
            if (!repo.IfExist(x => x.Email.ToLower() == request.Email.ToLower()) && !passenger.IfExist(x => x.Email.ToLower() == request.Email.ToLower()))
            {
                var s = mapper.Map<Staff>(request);
                var p = CreateHashPassword(request.Password);
                s.PasswordHash = p.Item1;
                s.PasswordSalt = p.Item2;
                repo.AddEntity(s);
                await repo.SaveChanges();
                return mapper.Map<StaffResponse>(s);
            }
            throw new Exception("This email is already in used");
        }
    }
}
