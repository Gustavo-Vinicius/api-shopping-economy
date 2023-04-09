using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using shopping_economy.Core.DTOs;
using shopping_economy.Core.Interface;

namespace shopping_economy.Application.Queries.GetListStoreSetup
{
    public class GetListingStoreSetupQueryHandler : IRequestHandler<GetListingStoreSetupQuery, IEnumerable<StoreSetupDTO>>
    {
        private readonly IStoreSetupRepository _repository;

        public GetListingStoreSetupQueryHandler(IStoreSetupRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StoreSetupDTO>> Handle(GetListingStoreSetupQuery request, CancellationToken cancellationToken)
        {
            var listingStoreSetup = await _repository.SearchListOfRegisteredStoreSetupAsync();

            return listingStoreSetup;
        }
    }
}