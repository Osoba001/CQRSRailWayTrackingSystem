using Microsoft.AspNetCore.Http;
using RailWayApp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayApp.Utility
{
    public interface IRefreshTokenGeneraror
    {
        ReFreshTokenResponse GenerateRefreshToken();
    }
    
}
