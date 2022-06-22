using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayAppLibrary.Utility;
using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Query.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayInfrastructureLibrary.Repository.Query
{
    public class StaffQueryRepo : QueryRepo<Staff>, IStaffQueryRepo
    {
        private readonly RailWayDbContext context;
        private readonly IAuthenticationManager authentication;
        private readonly IEscription escription;

        public StaffQueryRepo(RailWayDbContext context ,IAuthenticationManager authentication, IEscription escription) : base(context)
        {
            this.context = context;
            this.authentication = authentication;
            this.escription = escription;
        }

        public Tuple<Staff,bool, string> Login(string email, string password)
        {
            string msg= "user email or password is not valid";
            bool IsSucess = false;
            Staff _staff=new();
            var s = context.Set<Staff>().FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            if (s != null)
            {
                IsSucess = escription.VerifyPassword(password, s.PasswordHash, s.PasswordSalt);
                if (IsSucess)
                {
                   msg = authentication.AuthenticateStaff(s);
                    _staff = s;
                }
               
            }
           return new Tuple<Staff,bool, string>(_staff, IsSucess, msg);
        }
    }
}
