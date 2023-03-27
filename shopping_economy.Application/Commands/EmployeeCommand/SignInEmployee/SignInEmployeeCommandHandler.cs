using shopping_economy.Core.Interface;
using MediatR;
using shopping_economy.Core.Entities;
using shopping_economyShared.Utils;

namespace shopping_economy.Application.Commands.ClienteCommand.LoginUsuario
{
    public class SignInEmployeeCommandHandler : IRequestHandler<SignInEmployeeCommand, string>
    {
        private readonly ILoginEmployeeRepository _repository;
        private readonly ITokenService _tokenService;

        public SignInEmployeeCommandHandler(ILoginEmployeeRepository repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }
        public async Task<string> Handle(SignInEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee user = new Employee { Email = request.Email, Password = Cryptography.EncryptToSha256(request.Password) };

            Employee userEmployee = await _repository.CheckIfEmployeeExistsAsync(user);

            // if (voter == null)
            //     throw new ResponseException("Incorrect username or password.", HttpStatusCode.BadRequest);

            var token = _tokenService.GenerateAccessToken(userEmployee.Email);

            return token;
        }
    }
}