using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using shopping_economy.Core.Interface;

namespace shopping_economy.Application.Queries.ListOfTheMonthCommand.CompareListPrices
{
    public class CompareListPricesQueryHandler : IRequestHandler<CompareListPricesQuery, decimal>
    {

        private readonly ICreateListOfTheMonthRepository _repository;

        public CompareListPricesQueryHandler(ICreateListOfTheMonthRepository repository)
        {
            _repository = repository;
        }
        public async Task<decimal> Handle(CompareListPricesQuery request, CancellationToken cancellationToken)
        {
            var currentMonth = await _repository.SearchTotalPriceOfTheCurrentMonthAsync(request.currentMonth, request.client_id);

            var lastMonth = await _repository.SearchTotalPriceOfTheLastMonthAsync(request.lastMonth, request.client_id);

            var resultPrice = lastMonth - currentMonth;

            return resultPrice;
        }
    }
}