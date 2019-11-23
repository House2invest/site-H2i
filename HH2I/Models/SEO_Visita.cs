namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class SEO_Visita
    {
        private DateTime? dthr;

        public int Id { get; set; }
        public string URL { get; set; }
        public DateTime DTHR
        {
            get { return dthr ?? DateTime.Now; }
            set { dthr = value; }
        }
        private DateTime? __dthr = null;
        public string IdUsu { get; set; }
    }
}


