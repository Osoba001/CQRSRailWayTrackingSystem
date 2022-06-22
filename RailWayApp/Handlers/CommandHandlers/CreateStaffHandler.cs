using AutoMapper;
using MediatR;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Response;
using RailWayAppLibrary.Utility;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public class CreateStaffHandler : IRequestHandler<CreateStaff, StaffResponse>
    {
        private readonly IStaffCommandRepo repo;
        private readonly IPassengerCommandRepo passenger;
        private readonly IEscription escription;
        private readonly IAuthenticationManager authentication;
        private readonly IMapper mapper;

        public CreateStaffHandler(IStaffCommandRepo repo,IEscription escription,IAuthenticationManager authentication,  IMapper mapper)
        {
            this.repo = repo;
            this.escription = escription;
            this.authentication = authentication;
            this.mapper = mapper;
        }
        public async Task<StaffResponse> Handle(CreateStaff request, CancellationToken cancellationToken)
        {
            if (!repo.IfExist(x => x.Email.ToLower() == request.Email.ToLower()))
            {
                var s = mapper.Map<Staff>(request);
                var p = escription.CreateHashPassword(request.Password);
                s.PasswordHash = p.Item1;
                s.PasswordSalt = p.Item2;
                repo.AddEntity(s);
                await repo.SaveChanges();
                var st= mapper.Map<StaffResponse>(s);
                st.Meassage = authentication.AuthenticateStaff(s);
                st.IsSoccess = true;
                return st;
            }
            throw new Exception("This email is already in used");
        }
    }
}
