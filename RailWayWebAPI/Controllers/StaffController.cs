using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Queries;

namespace RailWayWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StaffController : ControllerBase
    {
        private readonly IMediator mediator;
        public StaffController(IMediator mediator)
        {
            this.mediator = mediator;
         }
         [HttpPost]
         [Authorize(Policy="AdminOnly")]
  
        public async Task<IActionResult> CreateStaff([FromBody] CreateStaff staff)
        {
            return Ok(await mediator.Send(staff));
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginStaff staff)
        {
            var _staff= await mediator.Send(staff);
            if (_staff.IsSoccess)
                return Ok(_staff.Meassage);
            return BadRequest(_staff.Meassage);
        }

        [HttpPut]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateStaff([FromBody] EditStaff staff)
        {
            return Ok(await mediator.Send(request: staff));
        }
        
        [HttpDelete]
        [Authorize( Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteStaff(Guid id)
        {
            return Ok(await mediator.Send(request: new DeleteStaff(id)));
        }
       
        [HttpGet("GetToN")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetToN(int n)
        {
            return Ok(await mediator.Send(request: new GetTopNStaff(n)));
        }

        [HttpGet]
        [Authorize(Policy ="AdminOnly")]
        public async Task<IActionResult> GetAllStaff()
        {
            return Ok(await mediator.Send(request:new GetAllStaff()));
        }
       
    }
}
