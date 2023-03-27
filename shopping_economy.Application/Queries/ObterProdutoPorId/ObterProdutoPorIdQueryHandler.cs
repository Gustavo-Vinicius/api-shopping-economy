using shopping_economy.Core.Entities;
using shopping_economy.Core.Interface;
using MediatR;

namespace shopping_economy.Application.Queries.ObterProdutoPorId
{
    public class ObterProdutoPorIdQueryHandler : IRequestHandler<ObterProdutoPorIdQuery, Product>
    {
        private readonly IProductRepository _repository;

        public ObterProdutoPorIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product> Handle(ObterProdutoPorIdQuery request, CancellationToken cancellationToken)
        {
            var produto = await _repository.SearchProductByIdAsync(request.Id);

            return produto;
        }
    }
}