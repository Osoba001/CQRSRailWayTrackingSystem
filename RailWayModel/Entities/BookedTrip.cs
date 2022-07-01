using RailWayModelLibrary.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace RailWayModelLibrary.Entities
{
    
    public class BookedTrip: EntityBase, IBaseModel
    {
        [Required]
        public Station PickupStation { get; set; }
        [Required]
        public Station DestinationStation { get; set; }
        public DateTime TripDate { get; set; }
        public bool SettledTrip { get; set; }
        [Required]
        public Passenger Passenger { get; set; }
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }
        public Train Train { get; set; }
        [Required]
        public int NumberOfSeat { get; set; }
    }

}
