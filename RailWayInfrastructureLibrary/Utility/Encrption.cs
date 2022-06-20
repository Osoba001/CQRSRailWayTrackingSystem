using RailWayAppLibrary.Utility;
using System.Security.Cryptography;
using System.Text;

namespace RailWayInfrastructureLibrary.Utility;

public class Encrption:IHashPassword,IVerifyPassword
{
    public  Tuple<byte[], byte[]> CreateHashPassword(string password)
    {
       using (var hmc=new HMACSHA512())
        {
            byte[] PasswordSalt = hmc.Key;
            byte[] PasswordHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(password));
            return new Tuple<byte[], byte[]>(PasswordHash, PasswordSalt);
        }
    }

    public bool VerifyPassword(string password, byte[]PasswordHash, byte[] PasswordSalt)
    {
        using (var hmc=new HMACSHA512(PasswordSalt))
        {
            var computed=hmc.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computed.Equals(PasswordSalt);
        }
    }
}
