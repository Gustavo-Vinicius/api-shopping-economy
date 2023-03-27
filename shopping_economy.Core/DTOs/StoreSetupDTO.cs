using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping_economy.Core.DTOs
{
    public class StoreSetupDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Manager { get; set; }

        public TimeOnly OpeningHours { get; set; }

        public TimeOnly ClosingTime { get; set; }
    }
}