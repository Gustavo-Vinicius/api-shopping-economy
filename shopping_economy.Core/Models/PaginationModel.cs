using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping_economy.Core.Models
{
    public class PaginationModel
    {
        public PaginationModel() { }

        public PaginationModel(
            int page,
            int itemsPerPage,
            int totalPage,
            int totalRecords
        )
        {
            Page = page;
            ItemsPerPage = itemsPerPage;
            TotalPage = totalPage;
            TotalRecords = totalRecords;
        }

        public int Page { get; }
        public int ItemsPerPage { get; }
        public int TotalPage { get; }
        public int TotalRecords { get; }

    }
}