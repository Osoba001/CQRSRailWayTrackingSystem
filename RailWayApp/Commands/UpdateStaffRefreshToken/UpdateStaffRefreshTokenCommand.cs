using MediatR;
using RailWayModelLibrary.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayApp.Commands.UpdateStaffRefreshToken
{
    public record UpdateStaffRefreshTokenCommand(Guid id, string Token, DateTime expire):IRequest;

    public record UpdateStaffRefreshTokenCommandHandler : IRequestHandler<UpdateStaffRefreshTokenCommand>
    {
        private readonly IStaffCommandRepo repo;

        public UpdateStaffRefreshTokenCommandHandler(IStaffCommandRepo repo)
        {
            this.repo = repo;
        }
        public async Task<Unit> Handle(UpdateStaffRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            await repo.UpdateRefreshToken(request.id,request.Token,request.expire);
            return Unit.Value;
        }
    }
}
