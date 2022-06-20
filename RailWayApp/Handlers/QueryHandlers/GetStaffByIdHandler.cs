using AutoMapper;
using MediatR;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Query;

namespace RailWayAppLibrary.Handlers.QueryHandlers
{
    public record GetStaffByIdHandler : IRequestHandler<GetStaffById, StaffResponse>
    {
        private readonly IStaffQueryRepo staffRepo;
        private readonly IMapper mapper;

        public GetStaffByIdHandler(IStaffQueryRepo staffRepo, IMapper mapper)
        {
            this.staffRepo = staffRepo;
            this.mapper = mapper;
        }
        public async Task<StaffResponse> Handle(GetStaffById request, CancellationToken cancellationToken)
        {
            return mapper.Map<StaffResponse>(await staffRepo.GetById(request.id));
        }
    }
}
