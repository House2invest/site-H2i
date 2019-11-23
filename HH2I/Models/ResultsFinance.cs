namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class ResultsFinance
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public Indice_CotacaoMoeda currencies { get; set; }
        public Indice_Mercado stocks { get; set; }
        public Indice_Bitcoin bitcoin { get; set; }
        public Indice_Taxas[] taxes { get; set; }
    }
}

