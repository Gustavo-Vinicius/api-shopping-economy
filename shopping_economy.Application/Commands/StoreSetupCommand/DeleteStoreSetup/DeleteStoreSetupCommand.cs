using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace shopping_economy.Application.Commands.StoreSetupCommand.DeleteStoreSetup
{
    public class DeleteStoreSetupCommand : IRequest<Unit>
    {
        public int id { get; set; }
    }
}