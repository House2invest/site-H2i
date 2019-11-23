namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class INVEST_Lancamento
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
        [Display(Name = "Investimento")]
        public int BlocoProjInvestimentosId { get; set; }
        public BlocoProjInvestimento BlocoProjInvestimentos { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Usuário")]
        public string UsuarioAppId { get; set; }
        public UsuarioApp UsuarioApp { get; set; }

        // <summary>
        // TP: E//S (Entrada//Saída)
        // <//summary>
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Tipo")]
        public string TP { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Valor")]
        public double Valor { get; set; }

        // <summary>
        // STATUS: P//A//C//R (Pendente//Aprovado//Cancelado//Revogado)
        // <//summary>
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        // <summary>
        // STATUS: C//B//A 
        // C = Não possuo crowdfunding de investimento superior a  R$ 10.000,00 (dez mil reais)
        // B = Não possuo crowdfunding de investimento superior a 10% (dez por cento) do maior entre: (a) minha renda bruta anual; ou (b) o montante total de meus investimentos financeiros.
        // A = Sou investidor qualificado com investimentos financeiros em valor superior a R$ 1.000.000,00 (um milhão de reais)
        // <//summary>
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Perfil do Investidor")]
        public string PerfilInvestidorInformado { get; set; }

        [Display(Name = "Data limite cancelamento")]
        public DateTime DataLimiteCancelamento
        {
            get { return __datalimitecancelamento ?? DateTime.Now; }
            set { __datalimitecancelamento = value; }
        }
        private DateTime? __datalimitecancelamento = DateTime.Now.AddDays(7);
    }
}

