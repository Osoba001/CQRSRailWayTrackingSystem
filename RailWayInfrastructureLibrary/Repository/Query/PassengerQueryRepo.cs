using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Query.Base;
using RailWayModelLibrary.Entities;
using static RailWayAppLibrary.Utility.Encrption;
using RailWayModelLibrary.Repositories.Query;
using RailWayAppLibrary.Utility;

namespace RailWayInfrastructureLibrary.Repository.Query
{
    public class PassengerQueryRepo : QueryRepo<Passenger>, IPassengerQueryRepo
    {
        private readonly RailWayDbContext context;
        private readonly IAuthenticationManager authentication;

        public PassengerQueryRepo(RailWayDbContext context, IAuthenticationManager authentication) : base(context)
        {
            this.context = context;
            this.authentication = authentication;
        }
        public string Login(string email, string password)
        {
            var p =  context.Set<Passenger>().FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            if (p != null)
            {
                if (VerifyPassword(password,p.PasswordHash,p.PasswordSalt))
                {
                    return authentication.Authenticate(p.Name, p.Email, "Passenger");
                }
                else
                {
                    throw new Exception("user email or password is not valid");
                }
                
            } 
            else
            {
                var s = context.Set<Staff>().FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
                if (s!=null)
                {
                    return authentication.Authenticate(s.Name, s.Email, s.Role);
                }
                else
                {
                    throw new Exception("user email or password is not valid");
                }
            }
        }
      
    }
}
