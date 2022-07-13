using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailWayApp.Commands.UpdateStaffRefreshToken;
using RailWayApp.Queries.GetStaffByReshToken;
using RailWayApp.Response;
using RailWayApp.Utility;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Queries;
using RailWayAppLibrary.Utility;

namespace RailWayWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StaffController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IRefreshTokenGeneraror _refreshToken;
        private readonly IAuthenticationManager createToken;

        public StaffController(IMediator mediator, IRefreshTokenGeneraror refreshToken, IAuthenticationManager createToken)
        {
            this.mediator = mediator;
            _refreshToken = refreshToken;
            this.createToken = createToken;
        }
         [HttpPost]
         //[Authorize(Policy="AdminOnly")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateStaff([FromBody] CreateStaff staff)
        {
            return Ok(await mediator.Send(staff));
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginStaff staff)
        {
            var _staff= await mediator.Send(staff);
            if (_staff.IsSuccess)
            {
                var newRefreshToken = _refreshToken.GenerateRefreshToken();
                var cookiesOpt = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = newRefreshToken.Expires,
                };
                Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookiesOpt);
                var staf = new UpdateStaffRefreshTokenCommand(_staff.Id, newRefreshToken.Token, newRefreshToken.Expires);
                await mediator.Send(request: staf);
                return Ok(_staff.Message);
            }
                
            return BadRequest(_staff.Message);
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
        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (refreshToken == null)
            {
                return Unauthorized("UnAuthorize");
            }
            var st = await mediator.Send(new StaffByRefreshTokenQuery(refreshToken));
            if (st.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = createToken.AuthenticateStaff(st);
            var newRefreshToken = _refreshToken.GenerateRefreshToken();
            var cookiesOpt = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires,
            };

            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookiesOpt);
            var staf = new UpdateStaffRefreshTokenCommand(st.Id, newRefreshToken.Token, newRefreshToken.Expires);
            await mediator.Send(request: staf);

            return Ok(token);
        }
        
    }
}
