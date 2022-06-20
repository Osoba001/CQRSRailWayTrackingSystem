using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayModelLibrary.Entities.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
