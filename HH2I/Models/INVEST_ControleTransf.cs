namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class INVEST_ControleTransf
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

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Valor")]
        public double Valor { get; set; }

        // <summary>
        // STATUS: P//T//R (Pendente//Aprovado//Cancelado//Transferido//Revogado)
        // <//summary>
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        public int IdCompensacao { get; set; }
    }
}

