using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping_economy.Core.Models
{
    public class RetornoPaginacaoModel<T>
    {
        public RetornoPaginacaoModel() { }
        
        public RetornoPaginacaoModel(
            int pagina,
            int itensPorPagina,
            int totalDePaginas,
            int totalDeRegistros,
            List<T> registros
        )
        {
            Pagina = pagina;
            ItensPorPagina = itensPorPagina;
            TotalDePaginas = totalDePaginas;
            TotalDeRegistros = totalDeRegistros;
            Registros = registros;
        }

        public int Pagina { get; }
        public int ItensPorPagina { get; }
        public int TotalDePaginas { get; }
        public int TotalDeRegistros { get; }
        public List<T> Registros { get; }
    }

}