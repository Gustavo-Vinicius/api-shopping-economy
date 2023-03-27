using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.Interface;
using MediatR;

namespace shopping_economy.Application.Commands.ProdutoCommand.DeletarProduto
{
    public class DeletarProdutoCommandHandler : IRequestHandler<DeletarProdutoCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public DeletarProdutoCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletarProdutoCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteProductAsync(request.id);
            
            return Unit.Value;
        }
    }
}