using Microsoft.EntityFrameworkCore;
using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Command.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayInfrastructureLibrary.Repository.Command
{
    public class TrainCommandRepo : CommandRepo<Train>, ITrainCommandRepo
    {
        private readonly RailWayDbContext context;

        public TrainCommandRepo(RailWayDbContext context) : base(context)
        {
            this.context = context;
        }

        public void DepartStation(Guid traidId)
        {
            try
            {
                var t = context.Set<Train>().FirstOrDefault(x => x.Id == traidId);
                t.DepartedStation = context.Set<Station>().FirstOrDefault(x => x.Index == t.DepartedStation.Index + 1);
                context.Update(t);
                context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }

        public async Task<bool> EndTrip(Guid trainId)
        {
            var p = await context.Set<Train>().FirstOrDefaultAsync(x=>x.Id==trainId);
            p.IsOnTrack = false;
            context.Update(p);
            return await context.SaveChangesAsync() > 0;
        }

        public void SendTrainDeley(Guid traidId, TimeSpan delay)
        {
            var p=context.Set<Train>().FirstOrDefault(x=>x.Id==traidId);
            if(p!=null)
            {
                p.Delay = delay;
                context.Update(p);
            }
            else { throw new NullReferenceException("Train Not Found."); }
            
        }
    }
}
