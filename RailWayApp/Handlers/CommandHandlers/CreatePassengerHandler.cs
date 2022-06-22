using AutoMapper;
using MediatR;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Response;
using RailWayAppLibrary.Utility;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public class CreatePassengerHandler : IRequestHandler<CreatePassenger, PassengerResponse>
    {
        private readonly IPassengerCommandRepo repo;
        private readonly IAuthenticationManager authentication;
        private readonly IEscription escription;
        private readonly IMapper mapper;

        public CreatePassengerHandler(IPassengerCommandRepo repo,IAuthenticationManager authentication, IEscription escription, IMapper mapper)
        {
            this.repo = repo;
            this.authentication = authentication;
            this.escription = escription;
            this.mapper = mapper;
        }
        public async Task<PassengerResponse> Handle(CreatePassenger request, CancellationToken cancellationToken)
        {
            if (!repo.IfExist(x => x.Email.ToLower() == request.Email.ToLower()))
            {
                var s = mapper.Map<Passenger>(request);
                var p = escription.CreateHashPassword(request.Password);
                s.PasswordHash = p.Item1;
                s.PasswordSalt = p.Item2;
                repo.AddEntity(s);
               await repo.SaveChanges();
                var pas=  mapper.Map<PassengerResponse>(s);
                pas.Meassage = authentication.AuthenticatePassenger(s);
                return pas;
            }
            throw new Exception("This email is already in used");
        }
    }
}
