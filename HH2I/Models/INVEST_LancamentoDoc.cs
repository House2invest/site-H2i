namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;


    public class INVEST_LancamentoDoc
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

        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int INVEST_ModeloDocId { get; set; }
        public INVEST_ModeloDoc INVEST_ModeloDoc { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "URL Documento")]
        public string URLDoc { get; set; }

        // <summary>
        // TP: D//A//I (Comprovação via documento enviado e assinado//Aceite pelo popup//Não necessita aceite)
        // <//summary>
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Tipo")]
        public string TP { get; set; }
    }
}

