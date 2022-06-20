using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetStaffByEmail(string email) : IRequest<StaffResponse>
    {
    }
}
