using shopping_economy.Core.DTOs;
using MediatR;

namespace shopping_economy.Application.Commands.ProdutoCommand.UpdateProduto
{
    public class UpdateProdutoCommand : IRequest<Unit>
    {
     public ProductDTO produto { get; set; }
     public int id { get; set; }
    }
}