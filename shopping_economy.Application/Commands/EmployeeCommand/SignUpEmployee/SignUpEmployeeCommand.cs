using MediatR;

namespace shopping_economy.Application.Commands.ClienteCommand.CadastrarUsuario
{
    public class CadastrarUsuarioCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public string Office { get; set; }

        public decimal Salary { get; set; }

        public DateTime AdmissionDate { get; set; }

        public int StoreId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}