using MediatR;
using shopping_economy.Application.Commands.ProdutoCommand.UpdateProduto;
using shopping_economy.Core.Interface;

namespace economia_compras.Application.Commands.ProdutoCommand.UpdateProduto
{
    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public UpdateProdutoCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            await _repository.ProductUpdateAsync(request.produto, request.id);

            return Unit.Value;
        }
    }
}