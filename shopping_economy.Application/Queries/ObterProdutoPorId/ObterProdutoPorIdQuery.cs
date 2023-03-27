using shopping_economy.Core.Entities;
using MediatR;

namespace shopping_economy.Application.Queries.ObterProdutoPorId
{
    public class ObterProdutoPorIdQuery: IRequest<Product>
    {
        public int Id { get; set; }
    }
}