using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record LoginStaffHandler : IRequestHandler<LoginStaff, StaffResponse>
    {
        private readonly IStaffQueryRepo staff;
        private readonly IMapper mapper;

        public LoginStaffHandler(IStaffQueryRepo staff, IMapper mapper)
        {
            this.staff = staff;
            this.mapper = mapper;
        }

        public Task<StaffResponse> Handle(LoginStaff request, CancellationToken cancellationToken)
        {
            var _staff = staff.Login(request.email, request.password);
            var logStaff = mapper.Map<StaffResponse>(_staff.Item1);
            logStaff.IsSoccess = _staff.Item2;
            logStaff.Meassage=_staff.Item3;
            return Task.Run(()=> logStaff);
        }
    }
}
