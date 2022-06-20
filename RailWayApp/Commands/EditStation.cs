using MediatR;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Entities;

namespace RailWayAppLibrary.Commands
{
    public record EditStation(Guid Id, string StationName, DateTime TrainArriverTime,
       string Location, decimal Amount, Staff StationAdmin, DateTime DepartingTime, string StationPhoneNo) :
       IRequest<int>;
}
