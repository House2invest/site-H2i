namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class BlocoProjInvestimento_ItemDoc
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
        [Display(Name = "Bloco de investimento")]
        public int BlocoProjInvestimentoId { get; set; }
        public BlocoProjInvestimento BlocoProjInvestimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Modelo de documentação / aceite de termos")]
        public int INVEST_ModeloDocId { get; set; }
        public INVEST_ModeloDoc INVEST_ModeloDoc { get; set; }
    }
}

