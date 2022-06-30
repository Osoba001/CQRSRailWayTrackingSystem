using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Response
{
    public class StationTransitResponse
    {
        public int StationIndex { get; set; }
        public string? StationName { get; set; }
        public string? Location { get; set; }
        public int NPickUp { get; set; }
        public int NDischarge { get; set; }

    }
}
