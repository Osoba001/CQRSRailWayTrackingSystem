using AutoMapper;
using MediatR;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Repositories.Command;

namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public class EditStaffHandler : IRequestHandler<EditStaff, StaffResponse>
    {
        private readonly IStaffCommandRepo repo;
        private readonly IMapper mapper;

        public EditStaffHandler(IStaffCommandRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<StaffResponse> Handle(EditStaff request, CancellationToken cancellationToken)
        {
           return mapper.Map<StaffResponse>(await repo.UpdateStaff(request.Id,request.Address,request.PhoneNo,request.Name, request.Role));
           
        }
    }
}
