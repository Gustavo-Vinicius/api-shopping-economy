using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping_economy.Core.Models
{
    public class PaginationDataInputModel
    {
        public int Currentpage { get; set; }

        public int ItemsPerPage { get; set; }

    }
}