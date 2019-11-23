//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//namespace House2Invest.Models.ViewModels
//{
//    public class ObjVlrAportComSimula
//    {
//        public string Valor { get; set; }
//        public List<ObjTaxaGlobal> TaxasGlobais { get; set; }
//    }
//    public class ObjTaxaGlobal
//    {
//        public string Descricao { get; set; }
//        public string Valor { get; set; }
//    }
//    public class Select2BuscaPessoa
//    {
//        public int Id { get; set; }
//        public string Nome { get; set; }
//        public string Tipo { get; set; }
//    }
//    public class DropDownItem
//    {
//        public string Id { get; set; }
//        public string Descricao { get; set; }
//    }
//    public class AppConfig
//    {
//        public Aplicativo Aplicativo { get; set; }
//    }
//    public class Aplicativo
//    {
//        public string Nome { get; set; }
//        public string Descricao { get; set; }
//        public string Versao { get; set; }
//    }
//    public class AppConfig_AppViewModel : AppConfiguracoes_Aplicativo
//    {
//        [Display(Name = "Imagem Logotipo")]
//        public IFormFile App_ImagemLogo { get; set; }
//    }
//    public class ImagensEnvio : GaleriaPerfilImagem
//    {
//        public IFormFile Arquivo { get; set; }
//    }
//    public class BlocoProjInvestimentoViewModel : BlocoProjInvestimento
//    {
//        [Display(Name = "Imagem destaque")]
//        public IFormFile ImagemDestaque { get; set; }
//    }
//    public class INVEST_LancamentoImagemViewModel : INVEST_LancamentoImagem
//    {
//        [Display(Name = "Comprovante de transferência")]
//        public IFormFile ArquivoComprovTransf { get; set; }
//        //[Display(Name = "Perfil do Investidor")]
//        //public IFormFile ArquivoPerfilInvestidor { get; set; }

//    }


//    public class TransferenciaViewModel
//    {
//        [Display(Name = "Comprovante de transferência")]
//        public IFormFile ArquivoComprovTransf { get; set; }
//        public double Montante { get; set; }
//        public string IDUSU { get; set; }
//        public int Id { get; set; }
//    }

//    public class UsuarioAppViewModel : UsuarioApp
//    {
//        [Display(Name = "Documento digitalizado")]
//        public IFormFile ImagemDocDigitalizado { get; set; }

//        [Display(Name = "Sua selfie")]
//        public IFormFile ImagemSelfie { get; set; }

//        [Display(Name = "Comprovante de residência")]
//        public IFormFile ImagemComprovanteResidencia { get; set; }

//        [Required(ErrorMessage = "Campo {0} é requerido")]
//        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Senha")]
//        public string Password { get; set; }

//        [DataType(DataType.Password)]
//        [Display(Name = "Confirme sua Senha")]
//        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não correspondem.")]
//        public string ConfirmPassword { get; set; }

//        [Required(ErrorMessage = "Campo {0} é requerido")]
//        [Display(Name = "Li e Aceito os Termos de Uso")]
//        public bool Termos { get; set; }

//        [Display(Name = "Não desejo aparecer na lista de participantes do projeto.")]
//        public bool NaoAparecerListaProjetos { get; set; }

//        [Display(Name = "Sou uma pessoa politicamente exposta.")]
//        public bool PessoaPoliticamenteExposta { get; set; }

//    }
//    public class CMSUsuariosViewModel
//    {
//        public string Id { get; set; }
//        public DateTime Criado { get; set; }
//        public string Nome { get; set; }
//        public string Email { get; set; }
//        public bool EmailConfirmado { get; set; }
//        public bool AcessoBloqueado { get; set; }
//        public bool Lockout { get; set; }

//        //public string URLDocDigitalizado { get; set; }
//        //public string URLSelfieDigitalizado { get; set; }

//        public string Sistema_URLSelfieDocFRENTE { get; set; }
//        public string Sistema_URLSelfieDocVERSO { get; set; }

//        public string Financeiro_Investidor_Perfil { get; set; }
//    }
//    public class DropTema
//    {
//        public string Chave { get; set; }
//        public string Descricao { get; set; }
//    }
//    public class Calculadora
//    {
//        public string ChaveId { get; set; }
//        public string Titulo { get; set; }
//        public bool ExibTitulo { get; set; }
//        public string Valor { get; set; }
//        public string Lance { get; set; }
//        public string ValorMinimoDocs { get; set; }
//        public double Reservado { get; set; }
//        public int Id { get; set; }
//        public int Contador_DataFinal_Ano { get; set; }
//        public int Contador_DataFinal_Mes { get; set; }
//        public int Contador_DataFinal_Dia { get; set; }
//        public int Contador_DataFinal_Hor { get; set; }
//        public int Contador_DataFinal_Min { get; set; }
//        public int Contador_DataFinal_Seg { get; set; }
//    }
//    public class ConversaViewModel : UsuarioApp
//    {
//        public int conv_id { get; set; }
//        public string conv_cnxid { get; set; }
//        public DateTime conv_dthr { get; set; }
//    }
//    public class MeuPerfilViewModel : UsuarioApp
//    {
//        [Display(Name = "Documento digitalizado")]
//        public IFormFile ImagemDocDigitalizado { get; set; }

//        [Display(Name = "Sua selfie - Frente")]
//        public IFormFile ImagemSelfieFRENTE { get; set; }

//        [Display(Name = "Sua selfie - Verso")]
//        public IFormFile ImagemSelfieVERSO { get; set; }

//        [Display(Name = "Não desejo aparecer na lista de participantes do projeto.")]
//        public bool NaoAparecerListaProjetos { get; set; }

//        [Display(Name = "Sou uma pessoa politicamente exposta.")]
//        public bool PessoaPoliticamenteExposta { get; set; }

//    }
//    public class ConstrutoraViewModel : Construtora
//    {
//        [Display(Name = "Logotipo")]
//        public IFormFile Imagem { get; set; }
//    }
//    public class ObjetoIP2Loc
//    {
//        public string ip { get; set; }
//        public string codpais { get; set; }
//        public string nomepais { get; set; }
//        public string estado { get; set; }
//        public string cidade { get; set; }
//        public float lat { get; set; }
//        public float lon { get; set; }
//        public string cep { get; set; }
//        public string timezone { get; set; }
//    }
//    public class ObjetoCMS
//    {
//        public AppConfiguracoes AppConfiguracoes { get; set; }
//        public string nomeusuario { get; set; }
//        public string idusuario { get; set; }
//        public string avatarusuario { get; set; }
//        public string funcaousuario { get; set; }
//        public string empresausuario { get; set; }
//    }

//    public class CorpoPrincipalOferta
//    {
//        public BlocoProjInvestimento blocoProjInvestimento { get; set; }
//        public UsuarioApp usuarioObjeto { get; set; }
//        public IFormFile ArquivoComprovResid { get; set; }

//        public IFormFile ArquivoTermoDeUso { get; set; }
//        public IFormFile ArquivoCienciaRisco { get; set; }
//        public IFormFile ArquivoTermoDeAdesao { get; set; }
//        public IFormFile ArquivoContratoDeMutuo { get; set; }

//        public string ValorInvestido { get; set; }
//        public bool AceitouTermos { get; set; }
//        /// <summary>
//        /// "C" = não possuo crowdfunding de investimento superior a  R$ 10.000,00 (dez mil reais)
//        /// "B" = não possuo crowdfunding de investimento superior a 10% (dez por cento) do maior entre:<br /> (a) minha renda bruta anual;<br /> ou (b) o montante total de meus investimentos financeiros.
//        /// "A" = Sou investidor qualificado com investimentos financeiros em valor superior a R$ 1.000.000,00 (um milhão de reais)
//        /// </summary>
//        public string PerfilInvestidorInformado { get; set; }
//    }

//    public class ObjetoEmailEnvio
//    {
//        [Display(Name = "mail.From")]
//        public string mailFrom { get; set; }
//        //[Display(Name = "mail.To.Add")]
//        //public string mailToAdd { get; set; }
//        [Display(Name = "smtp.UseDefaultCredentials")]
//        public bool smtpUseDefaultCredentials { get; set; }
//        [Display(Name = "smtp.EnableSsl")]
//        public bool smtpEnableSsl { get; set; }
//        [Display(Name = "smtp.Host")]
//        public string smtpHost { get; set; }
//        [Display(Name = "smtp.Port")]
//        public int smtpPort { get; set; }
//        [Display(Name = "smtp.Credentials.Email")]
//        public string smtpCredentialsEmail { get; set; }
//        [Display(Name = "smtp.Credentials.Senha")]
//        public string smtpCredentialsSenha { get; set; }

//        [Display(Name = "PARA")]
//        public string PARA { get; set; }
//        [Display(Name = "CÓPIA")]
//        public string COPIA { get; set; }
//        [Display(Name = "ASSUNTO")]
//        public string ASSUNTO { get; set; }
//        [Display(Name = "MENSAGEM")]
//        public string MENSAGEM { get; set; }

//    }
//}