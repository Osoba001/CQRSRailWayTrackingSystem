using RailWayModelLibrary.Entities.Base;

namespace RailWayModelLibrary.Entities
{
    public class Station : EntityBase, IBaseModel
    {

        public Station(string name, int priousIndex, Track track, string location, decimal amount, string stationPhoneNo)
        {
            StationName = name;
            Index = priousIndex + 1;
            Track = track;
            Location = location;
            Amount = amount;
            StationPhoneNo = stationPhoneNo;
        }
        public Station()
        {

        }
        public string StationName { get; set; }
        public DateTime TrainArriverTime { get; set; }
        public int Index { get; set; }
        public Track Track { get; set; }
        public string Location { get; set; }
        public decimal Amount { get; set; }
        public Staff StationAdmin { get; set; }
        public DateTime DepartingTime { get; set; }
        public string StationPhoneNo { get; set; }

        public static implicit operator Station(Task<Station> v)
        {
            throw new NotImplementedException();
        }
    }
}
