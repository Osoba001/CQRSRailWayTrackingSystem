using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetTopNStaffHandler : IRequestHandler<GetTopNStaff, List<StaffResponse>>
    {
        private readonly IStaffQueryRepo staffRepo;
        private readonly IMapper mapper;

        public GetTopNStaffHandler(IStaffQueryRepo staffRepo, IMapper mapper)
        {
            this.staffRepo = staffRepo;
            this.mapper = mapper;
        }
        public async Task<List<StaffResponse>> Handle(GetTopNStaff request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<StaffResponse>>(await staffRepo.GetTopN(request.n));
        }
    }
}
