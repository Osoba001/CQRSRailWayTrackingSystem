using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RailWayAppLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayInfrastructureLibrary.Authenticate
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenMager = (IAuthenticationManager)context.HttpContext.RequestServices.GetService(typeof(IAuthenticationManager));
            var result = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                result = false;

            string token = string.Empty;
            if (result)
            {
                token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
                try
                {
                    var clamprinciple = tokenMager.VerifyToken(token);
                }
                catch (Exception ex)
                {
                    result = false;
                    context.ModelState.AddModelError("Unauthorize", ex.Message);
                }
            }
            if (!result)
            {
                context.Result=new UnauthorizedObjectResult(context.ModelState);
            }
        }
    }
}
