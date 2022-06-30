using RailWayModelLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Response
{
    public class BookedTripResponse:EntityBase
    {
        public string? Track { get; set; }
        public string? PickupStation { get; set; }
        public string? pickupStationLocation { get; set; }
        public string? DestinationStation { get; set; }
        public Guid PassengerId { get; set; }
        public DateTime TripDate { get; set; }
        public DateTime DestinationTripArriverTime { get; set; }
        public DateTime PickUpTime { get; set; }
        public bool IsActive { get; set; }
        public bool SettledTrip { get; set; }
        public bool IstrainOnTrack { get; set; }
        public decimal Cost { get; set; }
        public int NumberOfSeat { get; set; }
    }
}
