using AutoMapper;
using MediatR;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public record CreatePaymentHandler : IRequestHandler<CreatePayment, PaymentResponse>
    {
        private readonly IPaymentCommandRepo payment;
        private readonly IMapper mapper;

        public CreatePaymentHandler(IPaymentCommandRepo payment, IMapper mapper)
        {
            this.payment = payment;
            this.mapper = mapper;
        }
        public async Task<PaymentResponse> Handle(CreatePayment request, CancellationToken cancellationToken)
        {
            var p = mapper.Map<Payment>(request);
            payment.AddEntity(p);
            await payment.SaveChanges();
            return mapper.Map<PaymentResponse>(p);
        }
    }
}
