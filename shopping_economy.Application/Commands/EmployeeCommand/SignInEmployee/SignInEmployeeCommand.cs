using MediatR;

namespace shopping_economy.Application.Commands.ClienteCommand.LoginUsuario
{
    public class SignInEmployeeCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}