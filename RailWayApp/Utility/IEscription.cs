using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Utility
{
    public interface IEscription
    {
        bool VerifyPassword(string password, byte[] PasswordHash, byte[] PasswordSalt);
        Tuple<byte[], byte[]> CreateHashPassword(string password);
    }
}
