using RailWayAppLibrary.Response.Base;
using RailWayModelLibrary.RailWayEnums;

namespace RailWayAppLibrary.Response
{
    public class PassengerResponse : PersonResponse
    { 
        public BloodGroup? BloodGroup { get; set; }
        public string NOK_PhoneNo { get; set; }
        public string? NOK_Name { get; set; }
        public string? NOK_Address { get; set; }
        public DateTime LastLogin { get; set; }

    }
}
