using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.Models;

namespace shopping_economy.Shared.Utils
{
    public static class Extensions
    {
        public static PaginacaoModel ObterPaginacao(
            int pagina,
            int itensPorPagina,
            int totalDeRegistros
        )
        {
            var contagemDePaginas = (double)totalDeRegistros / itensPorPagina;

            var totalDePaginas = (int)Math.Ceiling(contagemDePaginas);

            return new PaginacaoModel(pagina, itensPorPagina, totalDePaginas, totalDeRegistros);
        }

    }
}