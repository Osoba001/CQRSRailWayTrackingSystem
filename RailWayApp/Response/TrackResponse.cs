using RailWayModelLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Response
{
    public class TrackResponse:EntityBase
    {
        public string TrackName { get; set; }
        public int NStation { get; set; }
    }
}
