using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayInfrastructureLibrary.Authenticate
{
    public record AdultRequirement(int MinAge):IAuthorizationRequirement;
    
    public class AdultRequirementHandler:AuthorizationHandler<AdultRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdultRequirement requirement)
        {
            if(!context.User.HasClaim(x=>x.Type == "DOB"))
           return Task.CompletedTask;

           var period = DateTime.Now- DateTime.Parse(context.User.FindFirst(x => x.Type == "DOB").Value);
           
            if (period.Days > 365 * requirement.MinAge)
                context.Succeed(requirement);
            return Task.CompletedTask;

        }
    }
}
