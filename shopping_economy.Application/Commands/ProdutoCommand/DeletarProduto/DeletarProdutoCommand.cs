using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace shopping_economy.Application.Commands.ProdutoCommand.DeletarProduto
{
    public class DeletarProdutoCommand : IRequest<Unit>
    {
        public int id { get; set; }
    }
}