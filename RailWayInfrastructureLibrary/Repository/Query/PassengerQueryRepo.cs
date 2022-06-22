using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Query.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query;
using RailWayAppLibrary.Utility;

namespace RailWayInfrastructureLibrary.Repository.Query
{
    public class PassengerQueryRepo : QueryRepo<Passenger>, IPassengerQueryRepo
    {
        private readonly RailWayDbContext context;
        private readonly IAuthenticationManager authentication;
        private readonly IEscription escription;

        public PassengerQueryRepo(RailWayDbContext context, IAuthenticationManager authentication, IEscription escription) : base(context)
        {
            this.context = context;
            this.authentication = authentication;
            this.escription = escription;
        }
        public Tuple<Passenger, bool, string> Login(string email, string password)
        {
            string msg = "user email or password is not valid";
            bool IsSucess = false;
            Passenger _passenger = new();
            var s = context.Set<Passenger>().FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            if (s != null)
            {
                IsSucess = escription.VerifyPassword(password, s.PasswordHash, s.PasswordSalt);
                if (IsSucess)
                {
                    msg = authentication.AuthenticatePassenger(s);
                    _passenger = s;
                }

            }
            return new Tuple<Passenger, bool, string>(_passenger, IsSucess, msg);
        }
      
    }
}
