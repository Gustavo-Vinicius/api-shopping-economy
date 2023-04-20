using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping_economy.Core.Models
{
    public class PaginacaoModel
    {
        public PaginacaoModel() { }

        public PaginacaoModel(
            int pagina,
            int itensPorPagina,
            int totalDePaginas,
            int totalDeRegistros
        )
        {
            Pagina = pagina;
            ItensPorPagina = itensPorPagina;
            TotalDePaginas = totalDePaginas;
            TotalDeRegistros = totalDeRegistros;
        }

        public int Pagina { get; }
        public int ItensPorPagina { get; }
        public int TotalDePaginas { get; }
        public int TotalDeRegistros { get; }

    }
}