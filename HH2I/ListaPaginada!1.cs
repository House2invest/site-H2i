namespace House2Invest
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public class ListaPaginada<T> : List<T>
    {

        public ListaPaginada(List<T> itens, int contagem, int pagInd, int pagTam)
        {
            this.PagIND = pagInd;
            this.PagTOT = (int)Math.Ceiling((double)(((double)contagem) / ((double)pagTam)));
            base.AddRange((IEnumerable<T>)itens);
        }
    }
}

