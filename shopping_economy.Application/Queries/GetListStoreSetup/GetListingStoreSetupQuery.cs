using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using shopping_economy.Core.DTOs;

namespace shopping_economy.Application.Queries.GetListStoreSetup
{
    public class GetListingStoreSetupQuery : IRequest<IEnumerable<StoreSetupDTO>>
    {
        
    }
}