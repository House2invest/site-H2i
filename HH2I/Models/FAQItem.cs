namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class FAQItem
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public int Ordem { get; set; }

        public int FAQId { get; set; }
        public FAQ FAQ { get; set; }
    }
}

