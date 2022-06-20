using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Queries
{
    public record GetTopNStaff( int n) : IRequest<List<StaffResponse>>
    {
    }
}
