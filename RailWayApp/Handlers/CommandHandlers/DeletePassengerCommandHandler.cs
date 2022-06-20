using MediatR;
using RailWayAppLibrary.Commands;
using RailWayModelLibrary.Repositories.Command;


namespace RailWayAppLibrary.Handlers.CommandHandlers
{
    public class DeletePassengerCommandHandler : IRequestHandler<DeletePassenger, int>
    {
        private readonly IPassengerCommandRepo repo;

        public DeletePassengerCommandHandler(IPassengerCommandRepo repo)
        {
            this.repo = repo;
        }
        public async Task<int> Handle(DeletePassenger request, CancellationToken cancellationToken)
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
