namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class INVEST_LancamentoImagem
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int INVEST_LancamentoId { get; set; }
        public INVEST_Lancamento INVEST_Lancamento { get; set; }

        [Display(Name = "URL Comprovante de transferência")]
        public string URLComprovTransf { get; set; }

        [Display(Name = "URL Perfil do investidor")]
        public string URLPerfilInvest { get; set; }
    }
}

