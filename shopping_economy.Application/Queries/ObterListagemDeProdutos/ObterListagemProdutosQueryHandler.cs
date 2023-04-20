using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.DTOs;
using shopping_economy.Core.Interface;
using MediatR;
using shopping_economy.Core.Models;
using shopping_economy.Shared.Utils;

namespace shopping_economy.Application.Queries.ObterListagemDeProdutos
{
    public class ObterListagemProdutosQueryHandler : IRequestHandler<ObterListagemProdutosQuery,RetornoPaginacaoModel<ProductDTO>>
    {
        private readonly IProductRepository _repository;

        public ObterListagemProdutosQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<RetornoPaginacaoModel<ProductDTO>> Handle(ObterListagemProdutosQuery request, CancellationToken cancellationToken)
        {
           int totalproducts = await _repository.GetCountProductsAsync();

           List<ProductDTO> totalProductsList = await _repository.SearchListOfRegisteredProductsAsync(
            request.PaginaAtual,
            request.ItensPorPagina
           );

            PaginacaoModel paginacao = Extensions.ObterPaginacao(
                request.PaginaAtual,
                request.ItensPorPagina,
                totalproducts
            );

            return new RetornoPaginacaoModel<ProductDTO>(
                paginacao.Pagina,
                paginacao.ItensPorPagina,
                paginacao.TotalDePaginas,
                paginacao.TotalDeRegistros,
                totalProductsList
            );


        }
    }
}