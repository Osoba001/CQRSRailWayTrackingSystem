using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetPaymentByDayHandler : IRequestHandler<GetAllPaymentByDay, List<PaymentResponse>>
    {
        private readonly IPaymentQueryRepo payment;
        private readonly IMapper mapper;

        public GetPaymentByDayHandler(IPaymentQueryRepo payment, IMapper mapper)
        {
            this.payment = payment;
            this.mapper = mapper;
        }
        public async Task<List<PaymentResponse>> Handle(GetAllPaymentByDay request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<PaymentResponse>>(await payment.FindByPredicate(x => x.CreatedDate.Date==request.Date.Date));
        }
    }
}
