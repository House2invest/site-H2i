namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class AppPerfil
    {
        private DateTime? dthr = null;

        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return dthr ?? DateTime.Now; }
            set { dthr = value; }
        }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Configuração padrão")]
        public int AppConfiguracoesId { get; set; }
        public AppConfiguracoes AppConfiguracoes { get; set; }
    }
}

