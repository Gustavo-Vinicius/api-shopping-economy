using shopping_economy.Core.Entities;
using shopping_economy.Core.Interface;
using MediatR;

namespace shopping_economy.Application.Commands.ProdutoCommand.InserirProduto
{
    public class InserirProdutoCommandHandler : IRequestHandler<InserirProdutoCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public InserirProdutoCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(InserirProdutoCommand request, CancellationToken cancellationToken)
        {

            var id = _repository.GetIdAsync();

            if(id > 0){
                id++;
            }
            else{
                id = 1;
            }
            
            var insertProduct = new Product
            {
              Id = id,
              Name = request.Name,
              Price = request.Price,
              Description = request.Description,
              Stock = request.Stock,
              StoreId = request.StoreId
            };
            

            await _repository.InsertProductAsync(insertProduct);

            return Unit.Value;
        }
    }
}