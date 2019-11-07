using System;
using System.ComponentModel.DataAnnotations;
namespace House2Invest.Models
{
    public class SEO_Visita
    {
        [Key]
        public int Id { get; set; }
        public string URL { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;
        public string IdUsu { get; set; }
    }
    public class AppPerfil
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
        [Display(Name = "Configuração padrão")]
        public int AppConfiguracoesId { get; set; }
        public AppConfiguracoes AppConfiguracoes { get; set; }
    }
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
    public class AppConfiguracoes_Aplicativo
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        [Display(Name = "Ícone do aplicativo")]
        public string LogotipoEmpresa { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Nome da empresa")]
        public string Empresa { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "CPF/CNPJ da empresa")]
        public string CPFCNPJ { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Telefone principal")]
        public string Fone { get; set; }
        [Display(Name = "Telefone recados")]
        public string FoneRecados { get; set; }
        [Display(Name = "Celular")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Email para contato")]
        public string EmailContato { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Email para suporte")]
        public string EmailSuporte { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Email para vendas")]
        public string EmailVendas { get; set; }

        [Display(Name = "smtp.UseDefaultCredentials")]
        public bool smtpUseDefaultCredentials { get; set; }
        [Display(Name = "smtp.EnableSsl")]
        public bool smtpEnableSsl { get; set; }
        [Display(Name = "smtp.Port")]
        public int smtpPort { get; set; }

        string _mailFrom;
        [Encrypted(nameof(_mailFrom))]
        [Display(Name = "mail.From")]
        public string mailFrom
        {
            get => CriptografiaHelper.Decriptar(_mailFrom);
            set => _mailFrom = CriptografiaHelper.Encriptar(value);
        }
        string _mailToAdd;
        [Encrypted(nameof(_mailToAdd))]
        [Display(Name = "mail.To.Add")]
        public string mailToAdd
        {
            get => CriptografiaHelper.Decriptar(_mailToAdd);
            set => _mailToAdd = CriptografiaHelper.Encriptar(value);
        }
        string _smtpHost;
        [Encrypted(nameof(_smtpHost))]
        [Display(Name = "smtp.Host")]
        public string smtpHost
        {
            get => CriptografiaHelper.Decriptar(_smtpHost);
            set => _smtpHost = CriptografiaHelper.Encriptar(value);
        }
        string _smtpCredentialsEmail;
        [Encrypted(nameof(_smtpCredentialsEmail))]
        [Display(Name = "smtp.Credentials.Email")]
        public string smtpCredentialsEmail
        {
            get => CriptografiaHelper.Decriptar(_smtpCredentialsEmail);
            set => _smtpCredentialsEmail = CriptografiaHelper.Encriptar(value);
        }
        string _smtpCredentialsSenha;
        [Encrypted(nameof(_smtpCredentialsSenha))]
        [Display(Name = "smtp.Credentials.Senha")]
        public string smtpCredentialsSenha
        {
            get => CriptografiaHelper.Decriptar(_smtpCredentialsSenha);
            set => _smtpCredentialsSenha = CriptografiaHelper.Encriptar(value);
        }
        string _dumpSQLHost;
        [Encrypted(nameof(_dumpSQLHost))]
        [Display(Name = "[DUMP SQL] HOST")]
        public string dumpSQLHost
        {
            get => CriptografiaHelper.Decriptar(_dumpSQLHost);
            set => _dumpSQLHost = CriptografiaHelper.Encriptar(value);
        }
        string _dumpSQLUser;
        [Encrypted(nameof(_dumpSQLUser))]
        [Display(Name = "[DUMP SQL] USER")]
        public string dumpSQLUser
        {
            get => CriptografiaHelper.Decriptar(_dumpSQLUser);
            set => _dumpSQLUser = CriptografiaHelper.Encriptar(value);
        }
        string _dumpSQLPass;
        [Encrypted(nameof(_dumpSQLPass))]
        [Display(Name = "[DUMP SQL] PASS")]
        public string dumpSQLPass
        {
            get => CriptografiaHelper.Decriptar(_dumpSQLPass);
            set => _dumpSQLPass = CriptografiaHelper.Encriptar(value);
        }

        string _temporizaLmiteMaximoOfertaSuspensa;
        [Encrypted(nameof(_temporizaLmiteMaximoOfertaSuspensa))]
        [Display(Name = "[TEMPORIZADORES] LIMITE MÁXIMO OFERTA SUSPENSA")]
        public string temporizaLmiteMaximoOfertaSuspensa
        {
            get => CriptografiaHelper.Decriptar(_temporizaLmiteMaximoOfertaSuspensa);
            set => _temporizaLmiteMaximoOfertaSuspensa = CriptografiaHelper.Encriptar(value);
        }

        string _temporizaLmiteMaximoRevogaInvestimento;
        [Encrypted(nameof(_temporizaLmiteMaximoRevogaInvestimento))]
        [Display(Name = "[TEMPORIZADORES] LIMITE MÁXIMO REVOGAÇÃO DE INVESTIMENTO")]
        public string temporizaLmiteMaximoRevogaInvestimento
        {
            get => CriptografiaHelper.Decriptar(_temporizaLmiteMaximoRevogaInvestimento);
            set => _temporizaLmiteMaximoRevogaInvestimento = CriptografiaHelper.Encriptar(value);
        }

        string _temporizaLmiteMaximoCancelaInvestimento;
        [Encrypted(nameof(_temporizaLmiteMaximoCancelaInvestimento))]
        [Display(Name = "[TEMPORIZADORES] LIMITE MÁXIMO CANCELAMENTO DE INVESTIMENTO")]
        public string temporizaLmiteMaximoCancelaInvestimento
        {
            get => CriptografiaHelper.Decriptar(_temporizaLmiteMaximoCancelaInvestimento);
            set => _temporizaLmiteMaximoCancelaInvestimento = CriptografiaHelper.Encriptar(value);
        }
    }
    public class AppConfiguracoes_Azure
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        [Display(Name = "Usar simulador de armazenamento local?")]
        public bool UsarSimuladorLocal { get; set; }

        string __azureblob_AccountName;
        [Encrypted(nameof(__azureblob_AccountName))]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Nome da conta")]
        public string _azureblob_AccountName
        {
            get => CriptografiaHelper.Decriptar(__azureblob_AccountName);
            set => __azureblob_AccountName = CriptografiaHelper.Encriptar(value);
        }

        string __azureblob_AccountKey;
        [Encrypted(nameof(__azureblob_AccountKey))]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Chave da conta")]
        public string _azureblob_AccountKey
        {
            get => CriptografiaHelper.Decriptar(__azureblob_AccountKey);
            set => __azureblob_AccountKey = CriptografiaHelper.Encriptar(value);
        }

        string __azureblob_ContainerRaiz;
        [Encrypted(nameof(__azureblob_ContainerRaiz))]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Nome do container")]
        public string _azureblob_ContainerRaiz
        {
            get => CriptografiaHelper.Decriptar(__azureblob_ContainerRaiz);
            set => __azureblob_ContainerRaiz = CriptografiaHelper.Encriptar(value);
        }

        string _EnderecoArmazLocal;
        [Encrypted(nameof(_EnderecoArmazLocal))]
        [Display(Name = "Endereço armazenamento local Blob")]
        public string EnderecoArmazLocal
        {
            get => CriptografiaHelper.Decriptar(_EnderecoArmazLocal);
            set => _EnderecoArmazLocal = CriptografiaHelper.Encriptar(value);
        }
    }
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
    public class BlocoProjInvestimentoValor
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
        [Display(Name = "Valor")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Investimento")]
        public int BlocoProjInvestimentoId { get; set; }
        public BlocoProjInvestimento BlocoProjInvestimentos { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Usuário")]
        public string UsuarioAppId { get; set; }
        public UsuarioApp UsuarioApps { get; set; }
    }
    public class BlocoProjInvestimentoComentario
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
        [Display(Name = "Investimento")]
        public int BlocoProjInvestimentoId { get; set; }
        public BlocoProjInvestimento BlocoProjInvestimentos { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Usuário")]
        public string UsuarioAppId { get; set; }
        public UsuarioApp UsuarioApps { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Comentario { get; set; }
    }
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

        /// <summary>
        /// INDEFINIDA, EM ANDAMENTO, CANCELADA, ENCERRADA, SUSPENSA (I,A,C,E,S)
        /// </summary>
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
    public class INVEST_ModeloDoc
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
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Texto")]
        public string Texto { get; set; }

        [Display(Name = "Hyperlink")]
        public string Hyperlink { get; set; }
    }
    public class BlocoProjInvestimento_ItemDoc
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
        [Display(Name = "Bloco de investimento")]
        public int BlocoProjInvestimentoId { get; set; }
        public BlocoProjInvestimento BlocoProjInvestimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Modelo de documentação / aceite de termos")]
        public int INVEST_ModeloDocId { get; set; }
        public INVEST_ModeloDoc INVEST_ModeloDoc { get; set; }
    }
    public class INVEST_Lancamento
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
        [Display(Name = "Investimento")]
        public int BlocoProjInvestimentosId { get; set; }
        public BlocoProjInvestimento BlocoProjInvestimentos { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Usuário")]
        public string UsuarioAppId { get; set; }
        public UsuarioApp UsuarioApp { get; set; }

        /// <summary>
        /// TP: E/S (Entrada/Saída)
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Tipo")]
        public string TP { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Valor")]
        public double Valor { get; set; }

        /// <summary>
        /// STATUS: P/A/C/R (Pendente/Aprovado/Cancelado/Revogado)
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        /// <summary>
        /// STATUS: C/B/A 
        /// C = Não possuo crowdfunding de investimento superior a  R$ 10.000,00 (dez mil reais)
        /// B = Não possuo crowdfunding de investimento superior a 10% (dez por cento) do maior entre: (a) minha renda bruta anual; ou (b) o montante total de meus investimentos financeiros.
        /// A = Sou investidor qualificado com investimentos financeiros em valor superior a R$ 1.000.000,00 (um milhão de reais)
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Perfil do Investidor")]
        public string PerfilInvestidorInformado { get; set; }

        [Display(Name = "Data limite cancelamento")]
        public DateTime DataLimiteCancelamento
        {
            get { return __datalimitecancelamento ?? DateTime.Now; }
            set { __datalimitecancelamento = value; }
        }
        private DateTime? __datalimitecancelamento = DateTime.Now.AddDays(7);
    }
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

        /// <summary>
        /// TP: D/A/I (Comprovação via documento enviado e assinado/Aceite pelo popup/Não necessita aceite)
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Tipo")]
        public string TP { get; set; }
    }
    public class INVEST_LancamentoImagem
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

        [Display(Name = "URL Comprovante de transferência")]
        public string URLComprovTransf { get; set; }

        [Display(Name = "URL Perfil do investidor")]
        public string URLPerfilInvest { get; set; }
    }
    public class LOGCENTRAL
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public string UsuarioAppCriadorId { get; set; }
        public UsuarioApp UsuarioAppCriador { get; set; }

        /// <summary>
        /// I,S,A,E (Informação, Sucesso, Atenção, Erro)
        /// </summary>
        string _TIPO;
        [Encrypted(nameof(_TIPO))]
        public string TIPO
        {
            get => CriptografiaHelper.Decriptar(_TIPO);
            set => _TIPO = CriptografiaHelper.Encriptar(value);
        }

        string _IP;
        [Encrypted(nameof(_IP))]
        public string IP
        {
            get => CriptografiaHelper.Decriptar(_IP);
            set => _IP = CriptografiaHelper.Encriptar(value);
        }
        //public int INVEST_LancamentoId { get; set; }
        //public int INVEST_ModeloDocId { get; set; }
        //public string URLDOC { get; set; }
        //public string TP { get; set; }
        public double VALOR { get; set; }

        string _ACAO;
        [Encrypted(nameof(_ACAO))]
        public string ACAO
        {
            get => CriptografiaHelper.Decriptar(_ACAO);
            set => _ACAO = CriptografiaHelper.Encriptar(value);
        }

        string _STATUS;
        [Encrypted(nameof(_STATUS))]
        public string STATUS
        {
            get => CriptografiaHelper.Decriptar(_STATUS);
            set => _STATUS = CriptografiaHelper.Encriptar(value);
        }

        string _MENSAGEM;
        [Encrypted(nameof(_MENSAGEM))]
        public string MENSAGEM
        {
            get => CriptografiaHelper.Decriptar(_MENSAGEM);
            set => _MENSAGEM = CriptografiaHelper.Encriptar(value);
        }

        string _ICOMENS;
        [Encrypted(nameof(_ICOMENS))]
        public string ICOMENS
        {
            get => CriptografiaHelper.Decriptar(_ICOMENS);
            set => _ICOMENS = CriptografiaHelper.Encriptar(value);
        }

        public string UsuarioAppId { get; set; }
        public UsuarioApp UsuarioApp { get; set; }
    }
    public class LOGACOESUSU
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;
        public string UsuarioAppId { get; set; }
        public string scrollLeft { get; set; }
        public string scrollTop { get; set; }
        public string Url { get; set; }
    }
    public class tblHubConversa
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public string De { get; set; }
        public string DeCnxId { get; set; }
        public string Para { get; set; }
        public string ParaCnxId { get; set; }

        string _Mensagem;
        [Encrypted(nameof(_Mensagem))]
        public string Mensagem
        {
            get => CriptografiaHelper.Decriptar(_Mensagem);
            set => _Mensagem = CriptografiaHelper.Encriptar(value);
        }

        public bool Lida { get; set; }
    }
    public class tblHubCliente
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;
        public string Email { get; set; }
        public string CnxId { get; set; }
        public string Status { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Usuário")]
        public string UsuarioAppId { get; set; }
        public UsuarioApp UsuarioApp { get; set; }
    }
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
    public class INVEST_ControleTransf
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
        [Display(Name = "Investimento")]
        public int BlocoProjInvestimentosId { get; set; }
        public BlocoProjInvestimento BlocoProjInvestimentos { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Usuário")]
        public string UsuarioAppId { get; set; }
        public UsuarioApp UsuarioApp { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Valor")]
        public double Valor { get; set; }

        /// <summary>
        /// STATUS: P/T/R (Pendente/Aprovado/Cancelado/Transferido/Revogado)
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        public int IdCompensacao { get; set; }
    }

    public class HgGeoIp
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public string by { get; set; }
        public bool valid_key { get; set; }
        public int ResultsGeoIpId { get; set; }
        public ResultsGeoIp results { get; set; }
        public float execution_time { get; set; }
        public bool from_cache { get; set; }
    }
    public class ResultsGeoIp
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public string address { get; set; }
        public string type { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country_name { get; set; }
        public string continent { get; set; }
        public string continent_code { get; set; }
        public string region_code { get; set; }
        public int HgGeoIp_PaisId { get; set; }
        public HgGeoIp_Pais country { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string woeid { get; set; }
    }
    public class HgGeoIp_Pais
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public string name { get; set; }
        public string code { get; set; }
        public string capital { get; set; }
        public int HgGeoIp_Pais_FlagId { get; set; }
        public HgGeoIp_Pais_Flag flag { get; set; }
        public string calling_code { get; set; }
    }
    public class HgGeoIp_Pais_Flag
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public string svg { get; set; }
        public string png_16 { get; set; }
    }

    public class HgFinance
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public string by { get; set; }
        public bool valid_key { get; set; }
        public int ResultsFinanceId { get; set; }
        public ResultsFinance results { get; set; }
        public float execution_time { get; set; }
        public bool from_cache { get; set; }
    }
    public class ResultsFinance
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public Indice_CotacaoMoeda currencies { get; set; }
        public Indice_Mercado stocks { get; set; }
        public Indice_Bitcoin bitcoin { get; set; }
        public Indice_Taxas[] taxes { get; set; }
    }
    public class Indice_CotacaoMoeda
    {
        public string source { get; set; }
        public Indice_CotacaoMoedas_USD USD { get; set; }
        public Indice_CotacaoMoedas_EUR EUR { get; set; }
        public Indice_CotacaoMoedas_GBP GBP { get; set; }
        public Indice_CotacaoMoedas_ARS ARS { get; set; }
        public Indice_CotacaoMoedas_BTC BTC { get; set; }
    }
    public class Indice_CotacaoMoedas_BASE
    {
        public string name { get; set; }
        public float buy { get; set; }
        public float? sell { get; set; }
        public float variation { get; set; }
    }
    public class Indice_CotacaoMoedas_USD : Indice_CotacaoMoedas_BASE { }
    public class Indice_CotacaoMoedas_EUR : Indice_CotacaoMoedas_BASE { }
    public class Indice_CotacaoMoedas_GBP : Indice_CotacaoMoedas_BASE { }
    public class Indice_CotacaoMoedas_ARS : Indice_CotacaoMoedas_BASE { }
    public class Indice_CotacaoMoedas_BTC : Indice_CotacaoMoedas_BASE { }
    public class Indice_Mercado
    {
        public Indice_Mercado_IBOVESPA IBOVESPA { get; set; }
        public Indice_Mercado_NASDAQ NASDAQ { get; set; }
        public Indice_Mercado_CAC CAC { get; set; }
        public Indice_Mercado_NIKKEI NIKKEI { get; set; }
    }
    public class Indice_Mercado_BASE
    {
        public string name { get; set; }
        public string location { get; set; }
        public float? points { get; set; }
        public float variation { get; set; }
    }
    public class Indice_Mercado_IBOVESPA : Indice_Mercado_BASE { }
    public class Indice_Mercado_NASDAQ : Indice_Mercado_BASE { }
    public class Indice_Mercado_CAC : Indice_Mercado_BASE { }
    public class Indice_Mercado_NIKKEI : Indice_Mercado_BASE { }
    public class Indice_Bitcoin
    {
        public Indice_Bitcoin_blockchain_info blockchain_info { get; set; }
        public Indice_Bitcoin_coinbase coinbase { get; set; }
        public Indice_Bitcoin_bitstamp bitstamp { get; set; }
        public Indice_Bitcoin_foxbit foxbit { get; set; }
        public Indice_Bitcoin_mercadobitcoin mercadobitcoin { get; set; }
        public Indice_Bitcoin_omnitrade omnitrade { get; set; }
        public Indice_Bitcoin_xdex xdex { get; set; }
    }
    public class Indice_Bitcoin_BASE
    {
        public string name { get; set; }
        public string[] format { get; set; }
        public float? last { get; set; }
        public float? buy { get; set; }
        public float? sell { get; set; }
        public float? variation { get; set; }
    }
    public class Indice_Bitcoin_blockchain_info : Indice_Bitcoin_BASE { }
    public class Indice_Bitcoin_coinbase : Indice_Bitcoin_BASE { }
    public class Indice_Bitcoin_bitstamp : Indice_Bitcoin_BASE { }
    public class Indice_Bitcoin_foxbit : Indice_Bitcoin_BASE { }
    public class Indice_Bitcoin_mercadobitcoin : Indice_Bitcoin_BASE { }
    public class Indice_Bitcoin_omnitrade : Indice_Bitcoin_BASE { }
    public class Indice_Bitcoin_xdex : Indice_Bitcoin_BASE { }

    public class Indice_Taxas
    {
        public string date { get; set; }
        public float? cdi { get; set; }
        public float? selic { get; set; }
        public float? daily_factor { get; set; }
    }
    public class TaxaMercado
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public string data { get; set; }
        public float cdi { get; set; }
        public float selic { get; set; }
        public float fator_diario { get; set; }
    }
    public class TaxaGLOBAL
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
        [Display(Name = "DESCRIÇÃO")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "VALOR")]
        public string valor { get; set; }

        [Display(Name = "PRÉ-SELECIONADO")]
        public bool pre_selec { get; set; }
        [Display(Name = "INFORMAÇÕES")]
        public string informacoes { get; set; }
    }

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

    public class InvestimentoDocUsuario
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;
        public int BlocoProjInvestimentoId { get; set; }
        public BlocoProjInvestimento BlocoProjInvestimentos { get; set; }
        public string UsuarioAppId { get; set; }
        public UsuarioApp UsuarioApps { get; set; }
        public string URL { get; set; }
    }
    public class InvestimentoConfirmacao
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;
        public int BlocoProjInvestimentoId { get; set; }
        public BlocoProjInvestimento BlocoProjInvestimentos { get; set; }
        public string UsuarioAppId { get; set; }
        public UsuarioApp UsuarioApps { get; set; }
        public double Valor { get; set; }
        public string Token { get; set; }
        public bool Confirmado { get; set; }
        public int INVEST_LancamentoId { get; set; }
        public INVEST_Lancamento INVEST_Lancamento { get; set; }
    }

    public class DUMPSQL
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;
        public string URLBAK { get; set; }
    }

    public class FAQ
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
    public class FAQItem
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public int Ordem { get; set; }

        public int FAQId { get; set; }
        public FAQ FAQ { get; set; }
    }

    public class Transferencia
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTHR
        {
            get { return __dthr ?? DateTime.Now; }
            set { __dthr = value; }
        }
        private DateTime? __dthr = null;

        public double Valor { get; set; }
        public string URLComprovante { get; set; }
        public string IdUsu { get; set; }
        public int IdIncorporadora { get; set; }
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Display(Name = "Investimento")]
        public int BlocoProjInvestimentoId { get; set; }
        public BlocoProjInvestimento BlocoProjInvestimentos { get; set; }

        public DateTime DataLimite { get; set; }
    }

    //public class FooBar
    //{
    //    public int Id { get; set; }

    //    string _secret;
    //    [Encrypted(nameof(_secret))]
    //    public string Secret
    //    {
    //        get => VerificadoresRetornos.DecryptString(_secret, "");
    //        set => _secret = VerificadoresRetornos.EncryptString(value, "");
    //    }
    //}

    //public static string Decrypt(string s) => new string(VerificadoresRetornos.DecryptString(s, ""));
    //public static string Encrypt(string s) => new string(VerificadoresRetornos.EncryptString(s, ""));

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class EncryptedAttribute : Attribute
    {
        readonly string _fieldName;
        public EncryptedAttribute(string fieldName)
        {
            _fieldName = fieldName;
        }
        public string FieldName => _fieldName;
    }
}