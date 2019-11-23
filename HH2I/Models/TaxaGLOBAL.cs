namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class TaxaGLOBAL
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
        [Display(Name = "DESCRIÇÃO")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "VALOR")]
        public string valor { get; set; }

        [Display(Name = "PRÉ-SELECIONADO")]
        public bool pre_selec { get; set; }
        [Display(Name = "INFORMAÇÕES")]
        public string informacoes { get; set; }
    }

}

