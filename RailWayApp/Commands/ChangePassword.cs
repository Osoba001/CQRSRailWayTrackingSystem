using MediatR;

namespace RailWayAppLibrary.Commands
{
    public record ChangePassword(string email, string oldPassword, string newpassword) : IRequest<bool>;
}
