using MediatR;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.RailWayEnums;

namespace RailWayAppLibrary.Commands
{
    public record CreateStaff(string Name, Gender Gender, string Address, string PhoneNo, string Email,
        string Password, string Role, string StaffId) : IRequest<StaffResponse>;


}
