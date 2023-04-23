using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.DTOs;
using MediatR;
using shopping_economy.Core.Models;

namespace shopping_economy.Application.Queries.ObterListagemDeProdutos
{
    public class ObterListagemProdutosQuery: IRequest<PaginationReturnModel<ProductDTO>>
    {
        public int CurrentPage { get; }
        public int ItemsPerPage { get; }

        public ObterListagemProdutosQuery(int currentPage, int itemsPerPage)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
        }

    }
}