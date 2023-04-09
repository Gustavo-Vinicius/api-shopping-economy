using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace shopping_economy.Application.Commands.ListOfTheMonthCommand.CreateListTheMonth
{
    public class CreateListTheMonthCommand : IRequest<Unit>
    {
        public string ProductName { get; set; }
        public string Date { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int ClientId { get; set; }
    }
}