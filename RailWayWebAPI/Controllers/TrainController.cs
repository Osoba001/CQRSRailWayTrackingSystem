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
    [Authorize]
    public class TrainController : ControllerBase
    {
        private readonly IMediator mediator; 
        public TrainController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Post([FromBody] CreateTrain train)
        {
            return Ok(await mediator.Send(request: train));
        }

        [HttpPut("SendDelay")]
        [Authorize(Roles ="TrainEngineer")]
        public async Task<IActionResult> SendDelay(Guid id,TimeSpan delay)
        {
            return Ok( await mediator.Send(request: new SendTrainDelay(id, delay)));
        }

        [HttpPut("DepartFromStation")]
        [Authorize(Roles = "TrainEngineer")]
        public async Task<IActionResult> DepartFromStation(Guid id)
        {
            return Ok(await mediator.Send(request: new DepartStation(id)));
        }

        [HttpGet("GetTrainsOnTrack")]
        public async Task<IActionResult> GetTrainOnTrack(Guid trackId)
        {
            return Ok(await mediator.Send(request: new GetAllTrainOnTrack(trackId)));
        }
        [HttpGet("GetTrainByDate")]
        public async Task<IActionResult> GetTrainByDate(Guid trackId, DateTime date)
        {
            return Ok(await mediator.Send(request: new GetTrainsByDay(trackId, date)));
        }

        [HttpPut("EndTrip")]
        [Authorize(Roles = "TrainEngineer")]
        public async Task<IActionResult> EndTrip(Guid trainId)
        {
            return Ok(await mediator.Send(request: new EndTrip(trainId)));
        }

    }
}
