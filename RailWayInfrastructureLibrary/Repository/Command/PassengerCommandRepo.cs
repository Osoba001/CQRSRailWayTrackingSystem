using RailWayAppLibrary.Utility;
using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Repository.Command.Base;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.RailWayEnums;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayInfrastructureLibrary.Repository.Command
{
    public class PassengerCommandRepo : CommandRepo<Passenger>, IPassengerCommandRepo
    {
        private readonly RailWayDbContext context;
        private readonly IEscription escription;

        public PassengerCommandRepo(RailWayDbContext context, IEscription escription) : base(context)
        {
            this.context = context;
            this.escription = escription;
        }

        public async Task<bool> ChangePassword(string emal, string oldPassword, string newPassword)
        {
            var p = context.Set<Passenger>().FirstOrDefault(x => x.Email.ToLower() == emal.ToLower());
            if (p!=null)
            {
                if (escription.VerifyPassword(oldPassword, p.PasswordHash, p.PasswordSalt))
                {
                    var newlogin = escription.CreateHashPassword(newPassword);
                    p.PasswordHash = newlogin.Item1;
                    p.PasswordSalt = newlogin.Item2;
                    context.Update(p);
                    return await context.SaveChangesAsync() > 0;

                }
                else { throw new Exception("Old password is not correct"); }
            }
            else
            {
                var s = context.Set<Staff>().FirstOrDefault(x => x.Email.ToLower() == emal.ToLower());
                if (s!=null)
                {
                    if (escription.VerifyPassword(oldPassword, s.PasswordHash, s.PasswordSalt))
                    {
                        var newlogin = escription.CreateHashPassword(newPassword);
                        s.PasswordHash = newlogin.Item1;
                        s.PasswordSalt = newlogin.Item2;
                        context.Update(s);
                        return await context.SaveChangesAsync() > 0;

                    }
                    else { throw new Exception("Old password is not correct"); }
                }
                else
                {
                    throw new Exception("user not found");
                }
            }
            
           
        }

        public async Task<Passenger> UpdatePassenger(Guid id, string address, string phoneNo, string name, string nok_phoneno, string nok_name, string nok_address, BloodGroup bloodGroup)
        {
            var p = context.Set<Passenger>().FirstOrDefault(x => x.Id == id);
            if (p!= null)
            {
                p.Address=address;
                p.NOK_PhoneNo=nok_phoneno;
                p.PhoneNo = phoneNo;
                p.BloodGroup = bloodGroup;
                p.Name = name;
                p.NOK_Name = nok_name;
                p.NOK_Address = nok_address;
                p.LastModifiedDate = DateTime.Now;
                context.Update(p);
                await context.SaveChangesAsync();
                return p;
            }
            throw new Exception("Passenger does not exist.");
        }
    }
}
