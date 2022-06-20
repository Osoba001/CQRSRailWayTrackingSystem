using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Utility
{
    public interface IHashPassword
    {
        Tuple<byte[], byte[]> CreateHashPassword(string password);
    }
}
