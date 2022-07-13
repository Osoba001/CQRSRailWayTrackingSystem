using RailWayModelLibrary.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace RailWayModelLibrary.Entities
{
    public class Station : EntityBase, IBaseModel
    {
        public Station()
        {

        }
        [Required]
        public string StationName { get; set; }
        public DateTime TrainArriverTime { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
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
