namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class GaleriaPerfilAlbum
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
        [Display(Name = "Perfil")]
        public int AppPerfilId { get; set; }
        public AppPerfil AppPerfil { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

