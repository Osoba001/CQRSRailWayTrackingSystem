using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Command.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayInfrastructureLibrary.Repository.Command
{
    public class StationCommandRepo : CommandRepo<Station>, IStationCommandRepo
    {
        private readonly RailWayDbContext context;

        public StationCommandRepo(RailWayDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> UpdateStation(Guid id,string phoneNo, Staff StationAdmin, decimal amount, 
           string stationName, DateTime tripArriverTime, DateTime tripDepartingTime)
        {
            var p = context.Set<Station>().FirstOrDefault(x=>x.Id==id);
            if (p != null)
            {
                p.StationPhoneNo = phoneNo;
                p.LastModifiedDate = DateTime.Now;
                p.StationAdmin = StationAdmin;
                p.Amount = amount;
                p.StationName = stationName;
                p.TrainArriverTime = tripArriverTime;
                p.DepartingTime = tripDepartingTime;
                context.Update(p);
               return  await context.SaveChangesAsync();
            }
            else
                throw new NullReferenceException();
        }
    }
}
