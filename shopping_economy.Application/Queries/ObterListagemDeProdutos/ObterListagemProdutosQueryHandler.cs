using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.DTOs;
using shopping_economy.Core.Interface;
using MediatR;

namespace shopping_economy.Application.Queries.ObterListagemDeProdutos
{
    public class ObterListagemProdutosQueryHandler : IRequestHandler<ObterListagemProdutosQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository _repository;

        public ObterListagemProdutosQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(ObterListagemProdutosQuery request, CancellationToken cancellationToken)
        {
           return await _repository.SearchListOfRegisteredProductsAsync();
        }
    }
}