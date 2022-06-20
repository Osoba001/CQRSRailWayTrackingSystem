using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Command.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayInfrastructureLibrary.Repository.Command
{
    public class StaffCommandRepo : CommandRepo<Staff>, IStaffCommandRepo
    {
        private readonly RailWayDbContext context;

        public StaffCommandRepo(RailWayDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Staff> UpdateStaff(Guid id, string address,string phoneNo, string name,string role)
        {
            var p = context.Set<Staff>().FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                p.Address = address;
                p.PhoneNo = phoneNo;
                p.Name = name;
                p.Role = role;
                p.LastModifiedDate = DateTime.Now;
                context.Update(p);
               await  context.SaveChangesAsync();
                return p;
            }
            throw new Exception("Staff does not exist.");
        }
    }
}
