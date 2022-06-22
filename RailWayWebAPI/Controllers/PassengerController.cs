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
    public class PassengerController : ControllerBase
    {
        private readonly IMediator mediator;

        public PassengerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePassenger([FromBody] CreatePassenger passenger)
        {
            return Ok(await mediator.Send(request: passenger));
        }
        [HttpGet("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginPassenger passenger)
        {
            var _passenger = await mediator.Send(passenger);
            if (_passenger.IsSoccess)
                return Ok(_passenger);
            return BadRequest(_passenger.Meassage);
        }
        [HttpPut]
        [Authorize(Roles ="Passenger")]
        public async Task<IActionResult> UpdatePassenger([FromBody] EditPassenger passenger)
        {
            return Ok(await mediator.Send(request: passenger));
        }

        [HttpDelete]
        [Authorize(Policy = "AdminAndPassenger")]
        public async Task<IActionResult> DeletePassenger(Guid passengerId)
        {
            return Ok(await mediator.Send(request: new DeletePassenger(passengerId)));
        }
      
        [HttpGet("GetDischargePassengers")]
        [Authorize("TrainEngineerAndStationAdminOnly")]
        public async Task<IActionResult> GetDischargePassenger(Guid stationId)
        {
            return Ok(await mediator.Send(request: new DischargePassenger(stationId)));
        }

        [HttpGet("GetPickUpPassengers")]
        [Authorize("TrainEngineerAndStationAdminOnly")]
        public async Task<IActionResult> GetPickUpPassengers(Guid stationId)
        {
            return Ok(await mediator.Send(request: new PickUpPassenger(stationId)));
        }
        [HttpGet("GetById")]
        [Authorize(Policy ="AdminAndPassengerOnly")]
        public async Task<IActionResult> GetById(Guid PassengerId)
        {
            return Ok(await mediator.Send(request: new GetPassengerById(PassengerId)));
        }
        [HttpGet("GetTopN")]
        [Authorize("AdminOnly")]
        public async Task<IActionResult> GetToN(int n)
        {
            return Ok(await mediator.Send(request: new GetTopNPassenger(n)));
        }

        [HttpGet("GetByEmail")]
        [Authorize("AdminOnly")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return Ok(await mediator.Send(request: new GetPassengerByEmail(email)));
        }

        [HttpPut("ForgottenPassword")]
        [Authorize(Roles  ="Passenger")]
        public async Task<IActionResult> ForgottenPassword(string email)
        {
            throw new NotImplementedException();
        }
    }
}
