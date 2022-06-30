using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetAllStaffHandler : IRequestHandler<GetAllStaff, List<StaffResponse>>
    {
        private readonly IStaffQueryRepo staff;
        private readonly IMapper mapper;

        public GetAllStaffHandler(IStaffQueryRepo staff, IMapper mapper)
        {
            this.staff = staff;
            this.mapper = mapper;
        }
        public async Task<List<StaffResponse>> Handle(GetAllStaff request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<StaffResponse>>(await staff.GetAll());
        }
    }
}
