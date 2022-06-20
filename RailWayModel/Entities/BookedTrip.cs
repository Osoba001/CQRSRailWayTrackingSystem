using RailWayModelLibrary.Entities.Base;

namespace RailWayModelLibrary.Entities
{
    public class BookedTrip: EntityBase, IBaseModel
    {
        public BookedTrip()
        {

        }
        public BookedTrip(Station pickupStation, Station destinationStation, DateTime tripdate, Passenger passenger, int nseat)
        {
            PickupStation = pickupStation;
            DestinationStation = destinationStation;
            TripDate = tripdate;
            Passenger = passenger;
            NumberOfSeat = nseat;
            SettledTrip = false;

        }
        public Station PickupStation { get; set; }
        public Station DestinationStation { get; set; }
        public DateTime TripDate { get; set; }
        public bool SettledTrip { get; set; }
        public Passenger Passenger { get; set; }
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; }
        public Train Train { get; set; }
        public int NumberOfSeat { get; set; }
    }

}
