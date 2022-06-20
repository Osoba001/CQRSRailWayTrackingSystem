using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Queries;

namespace RailWayWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IMediator mediator;
        public StaffController(IMediator mediator)
        {
            this.mediator = mediator;
         }
         [HttpPost]
        public async Task<IActionResult> CreateStaff([FromBody] CreateStaff staff)
        {
            return Ok(await mediator.Send(staff));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStaff([FromBody] EditStaff staff)
        {
            return Ok(await mediator.Send(request: staff));
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteStaff(Guid id)
        {
            return Ok(await mediator.Send(request: new DeleteStaff(id)));
        }
       
        [HttpGet("GetToN")]
        public async Task<IActionResult> GetToN(int n)
        {
            return Ok(await mediator.Send(request: new GetTopNStaff(n)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaff()
        {
            return Ok(await mediator.Send(request:new GetAllStaff()));
        }
       
    }
}
