﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Commands
{
    public record DepartStation(Guid trainId):IRequest<bool>;
    
}