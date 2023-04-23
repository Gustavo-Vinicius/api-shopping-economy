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
    public class ObterListagemProdutosQueryHandler : IRequestHandler<ObterListagemProdutosQuery,PaginationReturnModel<ProductDTO>>
    {
        private readonly IProductRepository _repository;

        public ObterListagemProdutosQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginationReturnModel<ProductDTO>> Handle(ObterListagemProdutosQuery request, CancellationToken cancellationToken)
        {
           int totalproducts = await _repository.GetCountProductsAsync();

           List<ProductDTO> totalProductsList = await _repository.SearchListOfRegisteredProductsAsync(
            request.CurrentPage,
            request.ItemsPerPage
           );

            PaginationModel pagination = Extensions.ObterPaginacao(
                request.CurrentPage,
                request.ItemsPerPage,
                totalproducts
            );

            return new PaginationReturnModel<ProductDTO>(
                pagination.Page,
                pagination.ItemsPerPage,
                pagination.TotalPage,
                pagination.TotalRecords,
                totalProductsList
            );


        }
    }
}