namespace House2Invest.Models
{
    using System;
    using System.Runtime.CompilerServices;

    public class Indice_CotacaoMoeda
    {
        public string source { get; set; }
        public Indice_CotacaoMoedas_USD USD { get; set; }
        public Indice_CotacaoMoedas_EUR EUR { get; set; }
        public Indice_CotacaoMoedas_GBP GBP { get; set; }
        public Indice_CotacaoMoedas_ARS ARS { get; set; }
        public Indice_CotacaoMoedas_BTC BTC { get; set; }
    }
}

