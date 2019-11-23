namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class PreferSalaVIP
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
        [Display(Name = "Usuário")]
        public string UsuarioAppId { get; set; }
        public UsuarioApp UsuarioApp { get; set; }

        public bool CabecalhoFixo { get; set; }
        public bool BarrasFixas { get; set; }
        public bool TopoFixo { get; set; }
        public bool RodapeFixo { get; set; }
        public bool FormatoCaixa { get; set; }
        public bool MenuFixo { get; set; }

        public string Tema { get; set; }
    }
}

