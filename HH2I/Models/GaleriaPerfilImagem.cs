namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class GaleriaPerfilImagem
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
        [Display(Name = "Álbum")]
        public int GaleriaPerfilAlbumId { get; set; }
        public GaleriaPerfilAlbum GaleriaPerfilAlbum { get; set; }

        public string Descricao { get; set; }
        public string Url { get; set; }
    }
}

