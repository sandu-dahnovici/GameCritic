using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GameCritic.API.Filters;
using Microsoft.AspNetCore.Authorization;
using GameCritic.Application.App.Commands.Users;

namespace GameCritic.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    [HttpResponseExceptionFilter]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand loginUserdto)
        {
            var result = await _mediator.Send(loginUserdto);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand registerUserdto)
        {
            var result = await _mediator.Send(registerUserdto);
            return Ok(result);
        }


    }
}

