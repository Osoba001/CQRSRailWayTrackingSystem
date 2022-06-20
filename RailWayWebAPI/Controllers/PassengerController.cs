using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Queries;

namespace RailWayWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IMediator mediator;

        public PassengerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePassenger([FromBody] CreatePassenger passenger)
        {
            return Ok(await mediator.Send(request: passenger));
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePassenger([FromBody] EditPassenger passenger)
        {
            return Ok(await mediator.Send(request: passenger));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePassenger(Guid passengerId)
        {
            return Ok(await mediator.Send(request: new DeletePassenger(passengerId)));
        }
      
        [HttpGet("GetDischargePassengers")]
        public async Task<IActionResult> GetDischargePassenger(Guid stationId)
        {
            return Ok(await mediator.Send(request: new DischargePassenger(stationId)));
        }

        [HttpGet("GetPickUpPassengers")]
        public async Task<IActionResult> GetPickUpPassengers(Guid stationId)
        {
            return Ok(await mediator.Send(request: new PickUpPassenger(stationId)));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid PassengerId)
        {
            return Ok(await mediator.Send(request: new GetPassengerById(PassengerId)));
        }
        [HttpGet("GetTopN")]
        public async Task<IActionResult> GetToN(int n)
        {
            return Ok(await mediator.Send(request: new GetTopNPassenger(n)));
        }

        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return Ok(await mediator.Send(request: new GetPassengerByEmail(email)));
        }

        [HttpPut("ForgottenPassword")]
        public async Task<IActionResult> ForgottenPassword(string email)
        {
            throw new NotImplementedException();
        }
    }
}
