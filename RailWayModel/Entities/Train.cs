using RailWayModelLibrary.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace RailWayModelLibrary.Entities
{
    public class Train : EntityBase, IBaseModel
    {
        public Train()
        {
            IsOnTrack = true;
            delay = TimeSpan.Zero;
            TripDate = DateTime.Now;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        [Required]
        public Staff TrailEngineer { get; set; }
        [Required]
        public Track Track { get; set; }
        [Required]
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
