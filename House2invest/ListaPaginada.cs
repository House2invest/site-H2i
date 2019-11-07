using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace House2Invest
{
    public class ListaPaginada<T> : List<T>
    {
        public int PagIND { get; private set; }
        public int PagTOT { get; private set; }
        public ListaPaginada(List<T> itens, int contagem, int pagInd, int pagTam)
        {
            PagIND = pagInd;
            PagTOT = (int)Math.Ceiling(contagem / (double)pagTam);

            this.AddRange(itens);
        }

        public bool TemPaginaAnterior { get { return (PagIND > 1); } }
        public bool TemProximaPagina { get { return (PagIND < PagTOT); } }
        public static async Task<ListaPaginada<T>> CriarAsync(IQueryable<T> origem, int pagInd, int pagTam)
        {
            var total = await origem.CountAsync();
            var itens = await origem.Skip((pagInd - 1) * pagTam).Take(pagTam).ToListAsync();
            return new ListaPaginada<T>(itens, total, pagInd, pagTam);
        }
    }
}