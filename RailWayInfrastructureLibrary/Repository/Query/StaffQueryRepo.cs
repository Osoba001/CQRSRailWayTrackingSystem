using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Query.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query;
using static RailWayAppLibrary.Utility.Encrption;

namespace RailWayInfrastructureLibrary.Repository.Query
{
    public class StaffQueryRepo : QueryRepo<Staff>, IStaffQueryRepo
    {
        private readonly RailWayDbContext context;

        public StaffQueryRepo(RailWayDbContext context) : base(context)
        {
            this.context = context;
        }

        public Staff GetStaffByLogin(string email, string password)
        {
            var p = context.Set<Staff>().FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            if (p != null)
            {
                if (VerifyPassword(password, p.PasswordHash, p.PasswordSalt))
                {
                    return p;
                }
                else
                {
                    throw new Exception("user email or password is not valid");
                }

            }
            else
            {
                throw new Exception("user email or password is not valid");
            }
        }
    }
}
