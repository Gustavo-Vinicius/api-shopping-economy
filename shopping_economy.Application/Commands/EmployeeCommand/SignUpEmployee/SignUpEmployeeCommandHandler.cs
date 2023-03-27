using MediatR;
using shopping_economy.Core.Entities;
using shopping_economy.Core.Interface;
using shopping_economyShared.Utils;

namespace shopping_economy.Application.Commands.ClienteCommand.CadastrarUsuario
{
    public class CadastrarUsuarioCommandHandler : IRequestHandler<CadastrarUsuarioCommand>
    {
        private readonly ILoginEmployeeRepository _repository;

        public CadastrarUsuarioCommandHandler(ILoginEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            bool emailEmployeeExist = await _repository.CheckIfEmailAlreadyExistsAsync(request.Email);

            // If

            var encryptedSenha = Cryptography.EncryptToSha256(request.Password);

            var id = await _repository.BuscarIdAsync();

            if (id > 0)
            {
                id++;
            }
            else
            {
                id = 1;
            }

            var user = new Employee
            {
                Id = id,
                Name = request.Name,
                Office = request.Office,
                Salary = request.Salary,
                AdmissionDate = DateOnly.FromDateTime(request.AdmissionDate),
                StoreId = request.StoreId,
                Email = request.Email,
                Password = encryptedSenha
            };

            await _repository.RegisterEmployeeAsync(user);

            return Unit.Value;
        }
    }
}