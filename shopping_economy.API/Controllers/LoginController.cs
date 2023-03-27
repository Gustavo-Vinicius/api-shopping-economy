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
        /// teste
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register-user")]
        public async Task<IActionResult> RegistrarUsuarioAsync([FromBody] CadastrarUsuarioCommand command)
        {
            await _mediator.Send(command);

            return Ok(new DefaultResponse("Successfully registered user ! "));

        }

        [AllowAnonymous]
        [HttpPost("sign-in-user")]
        public async Task<IActionResult> LoginDeUsuarioAsync([FromBody] SignInEmployeeCommand command)
        {
            string token = await _mediator.Send(command);

            return Ok(new SignInResponse(token));

        }
    }
}