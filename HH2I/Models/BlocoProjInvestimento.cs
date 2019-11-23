namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class BlocoProjInvestimento
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public bool Ativo { get; set; }

        public string UrlImgPrinc { get; set; }
        public string Valor { get; set; }

        [Display(Name = "Lance mínimo")]
        public string LanceMinimo { get; set; }

        [Required(ErrorMessage = "Campo {0} é requerido")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Display(Name = "Exibir contador?")]
        public bool Contador_Exib { get; set; }
        [Display(Name = "Data limite do contador")]
        public string Contador_DataFinal { get; set; }
        [Display(Name = "Exibir título?")]
        public bool BlocoProjInvest_ExibTitulo { get; set; }

        [Display(Name = "Saldo reservado")]
        public double SaldoReservado { get; set; }
        [Display(Name = "Exigir documentação de acordo com o perfil do investidor")]
        public string ValorMinimoDocs { get; set; }

          // <summary>
          // INDEFINIDA, EM ANDAMENTO, CANCELADA, ENCERRADA, SUSPENSA (I, A, C, E, S)
          // </summary>
         [Display(Name = "Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Álbum de Fotos")]
        public int GaleriaPerfilAlbumId { get; set; }
        public GaleriaPerfilAlbum GaleriaPerfilAlbum { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Construtora")]
        public int ConstrutoraId { get; set; }
        public Construtora Construtora { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Descrição detalhada do projeto")]
        public string DescricaoDetalhadaProjeto { get; set; }
        [Display(Name = "Link para vídeo do projeto")]
        public string LinkVideoProjeto { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Logradouro")]
        public string Contato_Logradouro { get; set; }
        [Display(Name = "Número")]
        public string Contato_LogradouroNum { get; set; }
        [Display(Name = "Complemento")]
        public string Contato_Complemento { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Bairro")]
        public string Contato_Bairro { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Cidade")]
        public string Contato_Cidade { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "CEP")]
        public string Contato_CEP { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "UF")]
        public string Contato_Estado { get; set; }

        [Display(Name = "Rentabilidade anual projetada (TIR)")]
        public string Rentabilidade_TIR_TIT { get; set; }
        [Display(Name = "Rentabilidade mínima pré-fixada")]
        public string Rentabilidade_PRE_TIT { get; set; }
        [Display(Name = "Rentabilidade projetada (ROI)")]
        public string Rentabilidade_ROI_TIT { get; set; }

        [Display(Name = "VALOR DE")]
        public string Rentabilidade_TIR_INI { get; set; }
        [Display(Name = "VALOR ATÉ")]
        public string Rentabilidade_TIR_FIM { get; set; }
        [Display(Name = "VALOR DE")]
        public string Rentabilidade_PRE_INI { get; set; }
        [Display(Name = "VALOR ATÉ")]
        public string Rentabilidade_PRE_FIM { get; set; }
        [Display(Name = "VALOR ATÉ")]
        public string Rentabilidade_ROI_INI { get; set; }
        [Display(Name = "VALOR ATÉ")]
        public string Rentabilidade_ROI_FIM { get; set; }

        public DateTime DataLimiteSuspensao { get; set; }

        public string AndamentoObra { get; set; }
        public string AndamentoObraAcabamento { get; set; }
    }
}

