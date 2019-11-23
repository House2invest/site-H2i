namespace House2Invest.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class Indice_Mercado
    {
        public Indice_Mercado_IBOVESPA IBOVESPA { get; set; }
        public Indice_Mercado_NASDAQ NASDAQ { get; set; }
        public Indice_Mercado_CAC CAC { get; set; }
        public Indice_Mercado_NIKKEI NIKKEI { get; set; }
    }
}

