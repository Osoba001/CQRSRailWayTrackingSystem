using RailWayModelLibrary.Entities.Base;

namespace RailWayModelLibrary.Entities
{
    public class Train : EntityBase, IBaseModel
    {
        public Train()
        {

        }
        public Train(string name, int capacitiy, Staff engineer, Track track)
        {
            Name = name;
            Capacity = capacitiy;
            TrailEngineer = engineer;
            Track = track;
            IsOnTrack = true;
            delay = TimeSpan.Zero;
            TripDate = DateTime.Now;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Staff TrailEngineer { get; set; }
        public Track Track { get; set; }
        public Station DepartedStation { get; set; }
        private TimeSpan delay;
        public TimeSpan Delay
        {
            get { return delay; }
            set { delay = value + delay; }
        }
        public bool IsOnTrack { get; set; }
        public DateTime TripDate { get; set; }

        private int nPassengerInTrain;
        public int NTransitPassenge
        {
            get { return nPassengerInTrain; }
            set { nPassengerInTrain = value+nPassengerInTrain; }
        }


    }

}
