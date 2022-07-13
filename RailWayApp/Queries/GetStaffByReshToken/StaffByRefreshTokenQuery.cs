using AutoMapper;
using MediatR;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Entities;
using RailWayModelLibrary.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayApp.Queries.GetStaffByReshToken
{
    public record StaffByRefreshTokenQuery(string Token):IRequest<Staff>;

    public record StaffByRefreshTokenQueryHandler : IRequestHandler<StaffByRefreshTokenQuery, Staff>
    {
        private readonly IStaffQueryRepo repo;

        public StaffByRefreshTokenQueryHandler(IStaffQueryRepo repo)
        {
            this.repo = repo;
        }
        public async Task<Staff> Handle(StaffByRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            return await repo.GetByRefreshToken(request.Token);
        }
    }
   
}
