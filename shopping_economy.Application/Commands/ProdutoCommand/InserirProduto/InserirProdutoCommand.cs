using MediatR;

namespace shopping_economy.Application.Commands.ProdutoCommand.InserirProduto
{
    public class InserirProdutoCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int StoreId { get; set; }
    }
}