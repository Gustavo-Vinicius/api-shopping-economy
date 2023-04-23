using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.Models;

namespace shopping_economy.Shared.Utils
{
    public static class Extensions
    {
        public static PaginationModel ObterPaginacao(
            int page,
            int itemsPerPage,
            int totalRecords
        )
        {
            var contagemDePaginas = (double)totalRecords / itemsPerPage;

            var totalDePaginas = (int)Math.Ceiling(contagemDePaginas);

            return new PaginationModel(page, itemsPerPage, totalDePaginas, totalRecords);
        }

    }
}