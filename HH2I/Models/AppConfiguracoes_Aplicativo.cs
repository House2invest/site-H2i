namespace House2Invest.Models
{
    using House2Invest;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

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
            get => CriptografiaHelper.Decriptar(textoEncriptado, chave, vetorInicializacao);
            set => _mailFrom = CriptografiaHelper.Encriptar(textoEncriptado, chave, vetorInicializacao);
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
        string smtpCredentialsEmail;
        [Encrypted(nameof(_smtpCredentialsEmail))]
        [Display(Name = "smtp.Credentials.Email")]
        public string smtpCredentialsEmail
        {
            get => CriptografiaHelper.Decriptar(smtpCredentialsEmail);
            set => smtpCredentialsEmail = CriptografiaHelper.Encriptar(value);
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
}

