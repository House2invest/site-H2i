namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class tblUsuSalaVIP
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;
        public string CnxId { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Usuário")]
        public string UsuarioAppId { get; set; }
        public UsuarioApp UsuarioApp { get; set; }

        public string Status { get; set; }
    }
}

