using MediatR;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.RailWayEnums;

namespace RailWayAppLibrary.Commands
{
    public record EditPassenger(Guid Id, string Name, string Address, string PhoneNo, BloodGroup BloodGroup, string NOK_PhoneNo,
       string NOK_Name, string NOK_Address) : IRequest<PassengerResponse>;
}
