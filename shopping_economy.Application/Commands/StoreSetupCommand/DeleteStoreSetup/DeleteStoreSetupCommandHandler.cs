using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using shopping_economy.Core.Interface;

namespace shopping_economy.Application.Commands.StoreSetupCommand.DeleteStoreSetup
{
    public class DeleteStoreSetupCommandHandler : IRequestHandler<DeleteStoreSetupCommand, Unit>
    {
        private readonly IStoreSetupRepository _repository;

        public DeleteStoreSetupCommandHandler(IStoreSetupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteStoreSetupCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteStoreSetupAsync(request.id);

            return Unit.Value;
        }
    }
}