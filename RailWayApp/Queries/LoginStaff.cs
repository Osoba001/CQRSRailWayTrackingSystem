using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record LoginStaff(string email, string password) : IRequest<StaffResponse>;
}
