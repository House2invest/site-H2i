namespace House2Invest.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;


    public class Construtora
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
        [Display(Name = "Razão social")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Nome fantasia")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }
        [Display(Name = "Número")]
        public string LogradouroNum { get; set; }
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
        [Display(Name = "CEP")]
        public string CEP { get; set; }
        [Display(Name = "UF")]
        public string Estado { get; set; }
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Fone")]
        public string Fone { get; set; }

        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Display(Name = "Logotipo")]
        public string Logotipo { get; set; }

        [Display(Name = "Setor de atuação e histórico")]
        public string SetorAtuacaoHist { get; set; }

        [Display(Name = "Sociedade e administradores")]
        public string SociedadeAdms { get; set; }

        [Display(Name = "Informações sobre o plano de negócios")]
        public string InfoPlanoNegocios { get; set; }

        [Display(Name = "Informações sobre o valor mobiliário ofertado")]
        public string InfoValorMobOfertado { get; set; }

        [Display(Name = "Comunicação sobre a prestação de informações contínuas após a oferta")]
        public string ComunPrestInfoContAposOferta { get; set; }

        [Display(Name = "Alertas sobre riscos")]
        public string AlertaSobreRiscos { get; set; }

        [Display(Name = "Informações sobre a remuneração da plataforma")]
        public string InfoRemunPlataforma { get; set; }

        [Display(Name = "Características da oferta e tributação aplicável")]
        public string CaracOfertaTribuAplicavel { get; set; }

        [Display(Name = "Incorporadora e construtora")]
        public string IncorpConstrut { get; set; }

        [Display(Name = "Estudo de viabilidade econômico-financeira")]
        public string EstudoViabEcoFinanc { get; set; }

        [Display(Name = "Outras informações")]
        public string OutrasInfos { get; set; }





    }
}

