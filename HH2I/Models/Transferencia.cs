namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class Transferencia
    {
        private DateTime? dthr;

        [Key]
        public int Id
        { get; set; }

        public DateTime DTHR
        {
            get
            {
                DateTime? nullable = this.dthr;
                return (nullable.HasValue ? nullable.GetValueOrDefault() : DateTime.Now);
            }
            set
            {
                this.dthr = new DateTime?(value);
            }
        }

        public double Valor
        { get; set; }

        public string URLComprovante
        { get; set; }

        public string IdUsu
        { get; set; }

        public int IdIncorporadora
        { get; set; }

        [Required(ErrorMessage = "O campo {0} \x00e9 requerido"), Display(Name = "Investimento")]
        public int BlocoProjInvestimentoId
        { get; set; }

        public BlocoProjInvestimento BlocoProjInvestimentos
        { get; set; }

        public DateTime DataLimite
        { get; set; }
    }
}

