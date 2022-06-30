using MediatR;
using RailWayAppLibrary.Response;

namespace RailWayAppLibrary.Commands
{
    public record CreateStation(string StationName , DateTime TrainArriverTime , int PrevousStationIndex, 
        Guid TrackId,  string Location , decimal Amount , Guid StationAdminId, DateTime DepartingTime, string StationPhoneNo) :
        IRequest<StationResponse>;
}
