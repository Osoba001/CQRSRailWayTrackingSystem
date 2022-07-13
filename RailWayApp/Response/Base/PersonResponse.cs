using RailWayModelLibrary.Entities.Base;
using RailWayModelLibrary.RailWayEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Response.Base
{
     public class PersonResponse:EntityBase
    {
        public string? Name { get; set; }
        public Gender? Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
