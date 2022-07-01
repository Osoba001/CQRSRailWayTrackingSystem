using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Command.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Exception;
using RailWayModelLibrary.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayInfrastructureLibrary.Repository.Command
{
    public class BookedTripCommandRepo:CommandRepo<BookedTrip>, IBookedTripCommandRepo
    {
        private readonly RailWayDbContext context;

        public BookedTripCommandRepo(RailWayDbContext context):base(context)
        {
            this.context = context;
        }
        public async Task<int> RemovePastUnapproveTrips()
        {
            var p = context.Set<BookedTrip>().Where(x => x.TripDate < DateTime.Now && !x.Payment.IsAprove);
            context.RemoveRange(p);
           return await context.SaveChangesAsync();
        }
        public async Task<bool>ReschedulTrip(Guid tripId, DateTime newDate)
        {
            var p = context.Set<BookedTrip>().FirstOrDefault(x => x.Id==tripId);
            if (p!=null)
            {
                p.TripDate = newDate;
                context.Update(p);
                return await context.SaveChangesAsync() > 0;
            }
            throw new DomainNotFoundException("Trip not found");
        }

        public async Task SettledTrip(Guid id)
        {
            var p = context.Set<BookedTrip>().FirstOrDefault(x => x.Id == id);
            if (p!=null)
            {
                p.SettledTrip = true;
                context.Update(p);
                await context.SaveChangesAsync();
            }
        }
    }
}
