using RailWayModelLibrary.Entities.Base;
using RailWayModelLibrary.RailWayEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayModelLibrary.Entities
{
    
    public class Staff: Person, IBaseModel
    {
        public Staff()
        {

        }
        public Staff(string staffId, string role, string name, Gender gender, string address, string phoneNo, string email) : base(name, gender, address, phoneNo, email)
        {
            Role = role;
           StaffId=staffId;
        }
        public string StaffId { get; set; }
        public string Role { get; set; }
    }
}
