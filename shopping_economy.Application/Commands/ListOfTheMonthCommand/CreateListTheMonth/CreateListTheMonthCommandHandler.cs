using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using shopping_economy.Core.Entities;
using shopping_economy.Core.Interface;

namespace shopping_economy.Application.Commands.ListOfTheMonthCommand.CreateListTheMonth
{
    public class CreateListTheMonthCommandHandler : IRequestHandler<CreateListTheMonthCommand, Unit>
    {
        private readonly ICreateListOfTheMonthRepository _repository;

        public CreateListTheMonthCommandHandler(ICreateListOfTheMonthRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateListTheMonthCommand request, CancellationToken cancellationToken)
        {
            var id = _repository.GetIdAsync();

            if(id > 0){
                id++;
            }
            else{
                id = 1;
            }

            int stock = await _repository.GetStockTheProductAsync(request.ProductName);

            var newStock = stock - 1;

            await _repository.ProductInventoryUpdateAsync(request.ProductName, newStock);

            var insertProduct = new ShoppingList
            {
              Id = id,
              ProductName = request.ProductName,
              Date = DateTime.Now.ToString("dd-MM-yyyy"),
              Price = request.Price,
              TotalPrice = request.TotalPrice,
              ClientId = request.ClientId
            };

            await _repository.InsertShoppingListAsync(insertProduct);

            return Unit.Value;
        }
    }
}