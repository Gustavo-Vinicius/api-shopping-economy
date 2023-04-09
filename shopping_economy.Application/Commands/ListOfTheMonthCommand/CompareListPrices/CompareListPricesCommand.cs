using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace shopping_economy.Application.Commands.ListOfTheMonthCommand.CompareListPrices
{
    public class CompareListPricesCommand: IRequest<decimal>
    {
        public string currentMonth { get; set; }
        public string lastMonth { get; set; }
    }
}