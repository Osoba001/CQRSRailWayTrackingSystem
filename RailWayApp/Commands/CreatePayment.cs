using MediatR;
using RailWayAppLibrary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Commands
{
    public record CreatePayment(Guid PassengerId ,decimal Amount , Guid BookedTripId
        ):IRequest<PaymentResponse>;
}
