using shopping_economy.Application.Commands.ClienteCommand.CadastrarUsuario;
using shopping_economy.Application.Commands.ClienteCommand.LoginUsuario;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopping_economy.Shared.Responses;

namespace shopping_economy.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Register a new user with your password and unique username
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [ProducesResponseType(typeof(DefaultResponse), 200)]
        [ProducesResponseType(typeof(DefaultResponse), 400)]
        [HttpPost("register-user")]
        public async Task<IActionResult> RegistrarUsuarioAsync([FromBody] CadastrarUsuarioCommand command)
        {
            await _mediator.Send(command);

            return Ok(new DefaultResponse("Successfully registered user ! "));

        }
        /// <summary>
        /// Generates a new access token to user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("sign-in-user")]
        [ProducesResponseType(typeof(SignInResponse), 200)]
        [ProducesResponseType(typeof(DefaultResponse), 400)]
        public async Task<IActionResult> LoginDeUsuarioAsync([FromBody] SignInEmployeeCommand command)
        {
            string token = await _mediator.Send(command);

            return Ok(new SignInResponse(token));

        }
    }
}