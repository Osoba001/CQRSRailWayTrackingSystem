using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Queries;

namespace RailWayWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly IMediator mediator;

        public LogInController(IMediator mediator)
        {
            this.mediator = mediator;
        }
       

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword login)
        {
            return Ok(await mediator.Send(request: login));
        }

        [HttpPut("ForgottenPassword")]
        public async Task<IActionResult> ForgottenPassword(string email)
        {
            throw new NotImplementedException();
        }
    }
}
