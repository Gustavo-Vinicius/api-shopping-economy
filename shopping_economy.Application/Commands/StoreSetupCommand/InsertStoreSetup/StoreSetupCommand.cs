using MediatR;

namespace shopping_economy.Application.Commands.StoreSetupCommand.InsertStoreSetup
{
    public class StoreSetupCommand  : IRequest<Unit>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Manager { get; set; }

        public DateTime OpeningHours { get; set; }

        public DateTime ClosingTime { get; set; }
    }
}