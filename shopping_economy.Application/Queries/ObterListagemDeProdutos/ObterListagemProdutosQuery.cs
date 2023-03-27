using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.DTOs;
using MediatR;

namespace shopping_economy.Application.Queries.ObterListagemDeProdutos
{
    public class ObterListagemProdutosQuery: IRequest<IEnumerable<ProductDTO>>
    {
        
    }
}