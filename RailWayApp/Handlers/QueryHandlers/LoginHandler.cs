using MediatR;
using RailWayAppLibrary.Queries;
using RailWayModelLibrary.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record LoginHandler : IRequestHandler<Login, string>
    {
        private readonly IPassengerQueryRepo passengerRepo;

        public LoginHandler(IPassengerQueryRepo passengerRepo)
        {
            this.passengerRepo = passengerRepo;
        }
        public Task<string> Handle(Login request, CancellationToken cancellationToken)
        {
            return Task.Run(()=>passengerRepo.Login(request.email, request.password));
        }
    }
}
