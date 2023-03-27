using MediatR;
using shopping_economy.Core.Entities;
using shopping_economy.Core.Interface;

namespace shopping_economy.Application.Commands.StoreSetupCommand.InsertStoreSetup
{
    public class StoreSetupCommandHandler : IRequestHandler<StoreSetupCommand, Unit>
    {
        private readonly IStoreSetupRepository _repository;
        public StoreSetupCommandHandler(IStoreSetupRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(StoreSetupCommand request, CancellationToken cancellationToken)
        {
            var id = await _repository.GetIdAsync();

            if (id > 0)
            {
                id++;
            }
            else
            {
                id = 1;
            }
            

            var insertStoreSetup = new StoreSetup
            {
                Id = id,
                Name = request.Name,
                Address = request.Address,
                Telephone = request.Telephone,
                Email = request.Email,
                Manager = request.Manager,
                OpeningHours = TimeOnly.FromDateTime(request.OpeningHours),
                ClosingTime = TimeOnly.FromDateTime(request.ClosingTime)
            };


            await _repository.InsertStoreSetupAsync(insertStoreSetup);

            return Unit.Value;
        }
    }
}