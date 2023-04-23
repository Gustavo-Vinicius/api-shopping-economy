using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping_economy.Core.Models
{
    public class PaginationReturnModel<T>
    {
        public PaginationReturnModel() { }
        
        public PaginationReturnModel(
            int page,
            int itemsPerPage,
            int totalPage,
            int totalRecords,
            List<T> records
        )
        {
            Page = page;
            ItemsPerPage = itemsPerPage;
            TotalPage = totalPage;
            TotalRecords = totalRecords;
            Records = records;
        }

        public int Page { get; }
        public int ItemsPerPage { get; }
        public int TotalPage { get; }
        public int TotalRecords { get; }
        public List<T> Records { get; }
    }

}