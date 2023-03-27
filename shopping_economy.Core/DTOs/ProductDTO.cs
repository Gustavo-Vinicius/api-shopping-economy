using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping_economy.Core.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int StoreId { get; set; }
    }
}