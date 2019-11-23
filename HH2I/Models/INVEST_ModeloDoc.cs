namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class INVEST_ModeloDoc
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
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Texto")]
        public string Texto { get; set; }

        [Display(Name = "Hyperlink")]
        public string Hyperlink { get; set; }
    }
}

