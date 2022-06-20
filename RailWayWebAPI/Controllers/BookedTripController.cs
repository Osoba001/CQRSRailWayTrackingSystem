using MediatR;
using Microsoft.AspNetCore.Mvc;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Queries;

namespace RailWayWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookedTripController : ControllerBase
    {
        private readonly IMediator mediatr;

        public BookedTripController(IMediator _mediatr)
        {
            mediatr = _mediatr;
        }
        [HttpPost]

        public async Task<IActionResult> PostBookTrip([FromBody] CreateBookedTrip bookedTrip)
        {
        
                return Ok(await mediatr.Send(request: bookedTrip));
        }

        [HttpPut("ResheduleTrip")]
        public async Task<IActionResult> RescheduleTrip(Guid tripId,DateTime newdate)
        {
            return Ok(await mediatr.Send(request: new RescheduleTrip(tripId, newdate)));
        }
        [HttpGet("GetTripApprovedByDate")]
        public async Task<IActionResult> GetApprovedTripByDay(DateTime date)
        {
            return Ok(await mediatr.Send(request: new GetBookedTripApprovedByDay(date)));
        }
        [HttpGet("GetTripByPassenger")]
        public async Task<IActionResult> GetTripByPassengerId(Guid passengerId)
        {
            return Ok(await mediatr.Send(request: new GetBookedTripByPassenger(passengerId)));
        }
       
        [HttpGet("GetUnapprovedTripByDay")]
        public async Task<IActionResult> GetUnapprovedTripByDay(DateTime date)
        {
            return Ok(await mediatr.Send(request: new GetBookedTripUnapproveByDay(date)));
        }
        [HttpGet("GetBookedTripByDay")]
        public async Task<IActionResult> GetBookedTripByDay(DateTime date)
        {
            return Ok(await mediatr.Send(request: new GetBookedTripByDay(date)));
        }
        [HttpDelete("DeletePastUnapproveTrips")]
        public async Task<IActionResult> DeletePastUnapproveTrips()
        {
            return Ok(await mediatr.Send(request: new DeletePastUnapproveTrip()));
        }
        [HttpPut("SettleTrip")]
        public async Task<IActionResult> SettleTrip(Guid tripId)
        {
            return Ok(await mediatr.Send(request: new SettleTrip(tripId)));
        }
    }
}
