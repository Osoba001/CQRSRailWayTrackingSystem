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
        public Passenger()
        {

        }
        public Passenger(string nokName, string nokPhoneNo, string name, Gender gender, string address, string phoneNo, string email) : base(name, gender, address, phoneNo, email)
        {
            NOK_Name = nokName;
            NOK_PhoneNo = nokPhoneNo;
        }
        public BloodGroup? BloodGroup { get; set; }
        public string NOK_PhoneNo { get; set; }
        public string NOK_Name { get; set; }
        public string NOK_Address { get; set; }
    }
}
