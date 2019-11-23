namespace House2Invest.Models
{
    using House2Invest;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

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

        // <summary>
        // I,S,A,E (Informação, Sucesso, Atenção, Erro)
        // <//summary>
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
        public int INVEST_LancamentoId { get; set; }
        public int INVEST_ModeloDocId { get; set; }
        public string URLDOC { get; set; }
        public string TP { get; set; }
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
}

