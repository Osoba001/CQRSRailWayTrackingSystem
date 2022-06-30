using MediatR;
using RailWayAppLibrary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Queries
{
    public record GetAllUnapprovePayment:IRequest<List<PaymentResponse>>;

}
