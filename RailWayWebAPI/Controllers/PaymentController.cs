﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Queries;

namespace RailWayWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator mediator;

        public PaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost("MakePayment")]
        public async Task<IActionResult> MakePayment([FromBody] CreatePayment payment)
        {
            return Ok(await mediator.Send(request: payment));
        }

        [HttpPut("ApprovePayment")]
        public async Task<IActionResult> ApprovePayment(Guid id)
        {
            return Ok(await mediator.Send(request: new ApprovePayment(id)));
        }

        [HttpGet("GetPaymentByPassenger")]
        public async Task<IActionResult> GetPaymentByPassenger(Guid Id)
        {
            return Ok(await mediator.Send(request:new GetAllPaymentByPassenger(Id)));
        }

        [HttpGet("GetPaymentByDate")]
        public async Task<IActionResult> GetPaymentByDate(DateTime date)
        {
            return Ok(await mediator.Send(request: new GetAllPaymentByDay(date)));
        }
        [HttpGet("GetUnapprovePayment")]
        public async Task<IActionResult> GetUnapprovePayment()
        {
            return Ok(await mediator.Send(request: new GetAllUnapprovePayment()));
        }

       // [HttpDelete("RemoveUnapprovedPayment")]

    }
}
