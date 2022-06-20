using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayModelLibrary.Repositories.Command
{
    public interface IBookedTripCommandRepo:ICommandRepo<BookedTrip>
    {
        Task<int> RemovePastUnapproveTrips();
        Task<bool> ReschedulTrip(Guid tripId, DateTime newDate);
        Task SettledTrip(Guid id);
    }
}
