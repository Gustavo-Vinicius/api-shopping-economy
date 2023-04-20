using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.DTOs;
using MediatR;
using shopping_economy.Core.Models;

namespace shopping_economy.Application.Queries.ObterListagemDeProdutos
{
    public class ObterListagemProdutosQuery: IRequest<RetornoPaginacaoModel<ProductDTO>>
    {
        public int PaginaAtual { get; }
        public int ItensPorPagina { get; }

        public ObterListagemProdutosQuery(int paginaAtual, int itensPorPagina)
        {
            PaginaAtual = paginaAtual;
            ItensPorPagina = itensPorPagina;
        }

    }
}