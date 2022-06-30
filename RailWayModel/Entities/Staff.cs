using RailWayModelLibrary.Entities.Base;
using RailWayModelLibrary.RailWayEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayModelLibrary.Entities
{
    
    public class Staff: Person, IBaseModel
    {
        [Required]
        public string StaffId { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
