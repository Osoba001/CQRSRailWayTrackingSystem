using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayModelLibrary.Entities.Base
{
    public interface IBaseModel
    {
        Guid Id { get; set; }
    }
}
