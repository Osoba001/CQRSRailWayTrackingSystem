using RailWayModelLibrary.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayModelLibrary.Entities
{
    public class Track : EntityBase, IBaseModel
    {
        public Track()
        {
            Stations = new();
        }
        [Required]
        public string TrackName { get; set; }
        public List<Station> Stations { get; set; }
    }
}