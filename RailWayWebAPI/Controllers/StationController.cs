using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Queries;

namespace RailWayWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StationController : ControllerBase
    {
        private readonly IMediator mediator;

        public StationController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStation station)
        {
            return Ok(await mediator.Send(request: station));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditStation station)
        {
            return Ok(await mediator.Send(request: station));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await mediator.Send(request: new GetStationById(id)));
        }

        [HttpGet("GetStationsInTrack")]
        public async Task<IActionResult> GetStationsInTrack(Guid trackId)
        {
            return Ok(await mediator.Send(request: new GetStationInTrack(trackId)));
        }

        [HttpGet("GetStationsTransit")]
        public async Task<IActionResult> GetStationsTransit(Guid trackId, DateTime date)
        {

            throw new NotImplementedException();
            //return Ok(await mediator.Send(request: new GetStationTransitByDay(date, trackId)));
        }
    }
}
