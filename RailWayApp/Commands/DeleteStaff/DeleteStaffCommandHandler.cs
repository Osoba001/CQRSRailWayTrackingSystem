using MediatR;
using RailWayAppLibrary.Commands;
using RailWayModelLibrary.Repositories.Command;


namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public class DeleteStaffCommandHandler : IRequestHandler<DeleteStaff, int>
    {
        private readonly IStaffCommandRepo repo;

        public DeleteStaffCommandHandler(IStaffCommandRepo repo)
        {
            this.repo = repo;
        }
        public async Task<int> Handle(DeleteStaff request, CancellationToken cancellationToken)
        {
            try
            {
                repo.RemoveById(request.Id);
                await repo.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}
