using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record LoginPassengerHandler : IRequestHandler<LoginPassenger, PassengerResponse>
    {
        private readonly IPassengerQueryRepo passenger;
        private readonly IMapper mapper;

        public LoginPassengerHandler(IPassengerQueryRepo passenger, IMapper mapper)
        {
            this.passenger = passenger;
            this.mapper = mapper;
        }
        public Task<PassengerResponse> Handle(LoginPassenger request, CancellationToken cancellationToken)
        {
            var _psg = passenger.Login(request.email, request.password);
            var psg = mapper.Map<PassengerResponse>(_psg.Item1);
            psg.IsSuccess = _psg.Item2;
            psg.Message=_psg.Item3;
            return Task.Run(() => psg);
        }
    }
}
