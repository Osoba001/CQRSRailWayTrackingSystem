using RailWayModelLibrary.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace RailWayModelLibrary.Entities
{
    public class Payment:EntityBase,IBaseModel
    {
        public Payment()
        {
            
        }

        [Required]
        public Passenger Passenger { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime TimeOfPayment { get; set; }
        public bool IsAprove { get; set; }
        public BookedTrip BookedTrip { get; set; }
    }
}
