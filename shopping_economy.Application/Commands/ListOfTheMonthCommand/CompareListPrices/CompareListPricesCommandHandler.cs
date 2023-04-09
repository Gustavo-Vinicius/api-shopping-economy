using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using shopping_economy.Core.Interface;

namespace shopping_economy.Application.Commands.ListOfTheMonthCommand.CompareListPrices
{
    public class CompareListPricesCommandHandler : IRequestHandler<CompareListPricesCommand, decimal>
    {

        private readonly ICreateListOfTheMonthRepository _repository;

        public CompareListPricesCommandHandler(ICreateListOfTheMonthRepository repository)
        {
            _repository = repository;
        }
        public async Task<decimal> Handle(CompareListPricesCommand request, CancellationToken cancellationToken)
        {
            var currentMonth = await _repository.SearchTotalPriceOfTheCurrentMonthAsync(request.currentMonth);

            var lastMonth = await _repository.SearchTotalPriceOfTheLastMonthAsync(request.lastMonth);

            var resultPrice = lastMonth - currentMonth;

            return resultPrice;
        }
    }
}