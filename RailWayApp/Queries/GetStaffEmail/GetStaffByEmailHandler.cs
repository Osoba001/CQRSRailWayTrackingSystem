using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetStaffByEmailHandler : IRequestHandler<GetStaffByEmail, StaffResponse>
    {
        private readonly IStaffQueryRepo staffRepo;
        private readonly IMapper mapper;

        public GetStaffByEmailHandler(IStaffQueryRepo staffRepo, IMapper mapper)
        {
            this.staffRepo = staffRepo;
            this.mapper = mapper;
        }
        public async Task<StaffResponse> Handle(GetStaffByEmail request, CancellationToken cancellationToken)
        {
            return mapper.Map<StaffResponse>(await staffRepo.FindByPredicate(x=>x.Email==request.email));
        }
    }
}
