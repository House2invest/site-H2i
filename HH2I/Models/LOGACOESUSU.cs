namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class LOGACOESUSU
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;
        public string UsuarioAppId { get; set; }
        public string scrollLeft { get; set; }
        public string scrollTop { get; set; }
        public string Url { get; set; }
    }
}

