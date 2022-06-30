using MediatR;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.RailWayEnums;

namespace RailWayAppLibrary.Commands
{
    public record CreatePassenger (string Name , Gender Gender ,string Address , string PhoneNo , string Email,
        string Password, BloodGroup BloodGroup ,string NOK_PhoneNo , 
        string NOK_Name ,string NOK_Address):IRequest<PassengerResponse>;


}
