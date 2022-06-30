using RailWayAppLibrary.Response.Base;
using RailWayModelLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Response
{
    public class StaffResponse:PersonResponse
    {
        public string StaffId { get; set; }
        public string? Role { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
