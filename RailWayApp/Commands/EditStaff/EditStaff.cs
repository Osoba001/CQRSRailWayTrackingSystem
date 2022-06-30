using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Commands
{
    public record EditStaff(Guid Id,string Name, string Address, string PhoneNo, string Role) : IRequest<StaffResponse>;


}
