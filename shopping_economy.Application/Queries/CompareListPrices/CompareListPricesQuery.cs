using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace shopping_economy.Application.Queries.ListOfTheMonthCommand.CompareListPrices
{
    public class CompareListPricesQuery: IRequest<decimal>
    {
        public string currentMonth { get; set; }
        public string lastMonth { get; set; }
        public int client_id { get; set; }
    }
}