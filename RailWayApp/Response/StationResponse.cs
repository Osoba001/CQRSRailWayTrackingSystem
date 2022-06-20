using RailWayModelLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Response
{
    public class StationResponse:EntityBase
    {
        public string StationName { get; set; }
        public DateTime TrainArriverTime { get; set; }
        public int Index { get; set; }
        public string TrackName { get; set; }
        public string Location { get; set; }
        public decimal Amount { get; set; }
        public string NextStation { get; set; }
        public string StationAdmin { get; set; }
        public string StationPhoneNo { get; set; }
        public DateTime DepartingTime { get; set; }
    }
}
