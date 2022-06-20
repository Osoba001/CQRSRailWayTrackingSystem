using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Queries;

namespace RailWayWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly IMediator mediator;

        public TrackController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost, Authorize(Roles ="Admin")]
        public async Task<IActionResult> Post(string trackName)
        {
            return Ok(await mediator.Send(new CreateTrack(trackName)));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await mediator.Send(request: new GetTrack()));
        }
    }
}
