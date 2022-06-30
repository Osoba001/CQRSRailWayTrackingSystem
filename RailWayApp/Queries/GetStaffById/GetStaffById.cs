using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetStaffById(Guid id) : IRequest<StaffResponse>
    {
    }
}
