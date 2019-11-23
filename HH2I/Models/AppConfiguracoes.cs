namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class AppConfiguracoes
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        [Display(Name = "Permitir a criação de novos usuários?")]
        public bool NovosUsuarios { get; set; }
        [Display(Name = "Somente o Administrador poderá criar novos usuários?")]
        public bool NovosUsuarios_NivelADM { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Descrição do perfil")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Link para a exibição")]
        public string URLExibicao { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Tema")]
        public string Tema { get; set; }
        [Display(Name = "Caminho absoluto do Tema")]
        public string CaminhoAbsolutoTema { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Aplicação")]
        public int AppConfiguracoes_AplicativoId { get; set; }
        public AppConfiguracoes_Aplicativo AppConfiguracoes_Aplicativo { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Azure")]
        public int AppConfiguracoes_AzureId { get; set; }
        public AppConfiguracoes_Azure AppConfiguracoes_Azure { get; set; }
    }
}

