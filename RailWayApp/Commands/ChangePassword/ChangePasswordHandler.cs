using MediatR;
using RailWayAppLibrary.Commands;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public record ChangePasswordHandler : IRequestHandler<ChangePassword, bool>
    {
        private readonly IPassengerCommandRepo passenger;

        public ChangePasswordHandler(IPassengerCommandRepo passenger)
        {
            this.passenger = passenger;
        }
        public async Task<bool> Handle(ChangePassword request, CancellationToken cancellationToken)
        {
            return await passenger.ChangePassword(request.email, request.oldPassword, request.newpassword);
        }
    }
}
