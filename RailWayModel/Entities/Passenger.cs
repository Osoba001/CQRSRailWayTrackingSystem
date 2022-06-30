using RailWayModelLibrary.Entities.Base;
using RailWayModelLibrary.RailWayEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayModelLibrary.Entities
{
    public class Passenger:Person,IBaseModel
    {
        public BloodGroup? BloodGroup { get; set; }
        public string NOK_PhoneNo { get; set; }
        public string NOK_Name { get; set; }
        public string NOK_Address { get; set; }
    }
}
