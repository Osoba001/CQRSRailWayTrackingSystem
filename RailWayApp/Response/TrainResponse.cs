using RailWayModelLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Response
{
    public class TrainResponse:EntityBase
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string TrailEngineer { get; set; }
        public string TrackName { get; set; }
        public string DepartedStation { get; set; }
        public int AvalableSeat { get; set; }
        public TimeSpan Delay { get; set; }
        public DateTime TripDate { get; set; }
    }
}
